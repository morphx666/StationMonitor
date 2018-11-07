Imports System.Threading
Imports FPDataManager
Imports TracksManager.TrackAnalyzer

Public Class TracksManagerForm
    Private fpData As DataManager
    Private hashDataLib As HashLib

    Private ignoreChangeEvents As Boolean
    Private playingPositionUpdateTimer As Timer = New Timer(New TimerCallback(AddressOf UpdatePlaybackPosition), Nothing, Timeout.Infinite, Timeout.Infinite)

    Private Sub SongsManagerForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        fpvCtrl.ShowPlayStopButtons = True
    End Sub

    Private Sub SongsManagerForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub

    Private Sub dxvuCtrl_ControlIsReady() Handles dxvuCtrl.ControlIsReady
        InitializeSystem()
    End Sub

    Private Function IsDraggingFiles(data As IDataObject) As Boolean
        Dim files As String() = CType(data.GetData("FileDrop"), String())
        For Each file As String In files
            If Not IO.File.Exists(file) AndAlso IO.Directory.Exists(file) Then
                Return True
            ElseIf Not IsFileSupported(file) Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Function IsFileSupported(file As String) As Boolean
        Return HashLib.SupportedFileTypes.Contains(IO.Path.GetExtension(file).Replace(".", "").ToLower())
    End Function

    Private Sub AddFiles(files() As String)
        Static recursiveCount As Integer = 0
        If recursiveCount = 0 Then lvFiles.SuspendLayout()
        recursiveCount += 1

        For i As Integer = 0 To files.Length - 1
            Dim file = files(i)

            If Not IO.File.Exists(file) AndAlso IO.Directory.Exists(file) Then
                Dim subFiles As List(Of String) = New List(Of String)

                For Each subDir As IO.DirectoryInfo In New IO.DirectoryInfo(file).GetDirectories()
                    subFiles.Add(subDir.FullName)
                Next

                For Each subFile As IO.FileInfo In New IO.DirectoryInfo(file).GetFiles()
                    subFiles.Add(subFile.FullName)
                Next

                AddFiles(subFiles.ToArray())
            ElseIf IsFileSupported(file) Then
                Dim item As ListViewItem = lvFiles.Items.Add("")
                With item
                    .SubItems.Add("")
                    .SubItems.Add("")
                    .SubItems.Add("")
                    .SubItems.Add("")
                    .SubItems.Add(file)
                    .Tag = file

                    .Checked = Not IsTrackInDB(file)
                End With

                SetItemDataFromID3Tags(item)
            End If

            If i Mod 200 = 0 Then
                lvFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                Application.DoEvents()
            End If
        Next

        recursiveCount -= 1
        If recursiveCount = 0 Then
            lvFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            lvFiles.ResumeLayout()
        End If
    End Sub

    Private Sub lvFiles_DoubleClick(sender As Object, e As System.EventArgs) Handles lvFiles.DoubleClick
        StartPlayback()
    End Sub

    Private Sub lvFiles_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragDrop
        If gbPlayer.Enabled Then
            If e.Data.GetFormats().Contains("FileDrop") AndAlso IsDraggingFiles(e.Data) Then
                Dim files As String() = CType(e.Data.GetData("FileDrop"), String())
                Array.Sort(files)
                AddFiles(files)
            End If
        End If

        UpdateQueuedTracksLabel()
    End Sub

    Private Sub lvFiles_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lvFiles.DragOver
        If gbPlayer.Enabled Then
            If e.Data.GetFormats().Contains("FileDrop") Then
                If IsDraggingFiles(e.Data) Then
                    e.Effect = DragDropEffects.Copy
                Else
                    e.Effect = DragDropEffects.None
                End If
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub InitializeSystem()
        fpData = New DataManager()
        hashDataLib = New HashLib(dxvuCtrl)

        lblSongName.Text = ""
        gbItemProperties.Enabled = False

        LoadData(cbArtist, fpData.Data.Artists)
        LoadData(cbAlbum, fpData.Data.Albums)
        LoadData(cbGenre, fpData.Data.Genres)
        ConfigureSongsDataGrid()

        'Un4seen.Bass.Bass.BASS_Init(-1, 44100, Un4seen.Bass.BASSInit.BASS_DEVICE_DEFAULT, Me.Handle)
        'Un4seen.Bass.AddOn.Mix.BassMix.LoadMe()

        AddHandler hashDataLib.Status, Sub(sender As Object, e As HashLib.StatusEventArgs)
                                           Select Case e.Status
                                               Case FPDataManager.HashLib.StatusFlags.Playing
                                                   If tcTracks.SelectedTab.Name = tpTracksToAnalyze.Name Then lblSongName.Tag = lvFiles.SelectedItems(0)
                                                   SetPlayingFileName()
                                                   playingPositionUpdateTimer.Change(100, 500)
                                               Case FPDataManager.HashLib.StatusFlags.Stopping
                                                   lblSongName.Tag = Nothing
                                                   SetPlayingFileName()
                                                   playingPositionUpdateTimer.Change(Timeout.Infinite, Timeout.Infinite)
                                           End Select
                                       End Sub

        fpvCtrl.AttachToHashDataLib(hashDataLib)
    End Sub

    Private Sub StartAnalyzing()
        StopPlayback()

        Dim dirtyTracks As New List(Of DirtyTrack)

        For Each item As ListViewItem In lvFiles.CheckedItems
            If item.SubItems(0).Text = "" OrElse item.SubItems(1).Text = "" OrElse
                item.SubItems(2).Text = "" OrElse item.SubItems(3).Text = "" Then

                MsgBox("The track '" + item.SubItems(5).Text + "' is missing some metadata." + vbCrLf + vbCrLf + "All fields, except 'Year', need to be filled for all tracks.", vbInformation)
                item.Selected = True
                item.EnsureVisible()
                Exit Sub
            Else
                dirtyTracks.Add(New DirtyTrack(item, item.SubItems(0).Text, item.SubItems(1).Text, item.SubItems(2).Text, item.SubItems(3).Text, item.SubItems(4).Text, item.SubItems(5).Text))
            End If
        Next

        If dirtyTracks.Count > 0 Then
            Using frm As New AnalyzerForm()
                frm.DirtyTracks = dirtyTracks

                frm.ShowDialog(Me)
            End Using

            For Each dt In dirtyTracks
                Select Case dt.AnalysisResult
                    Case ResultEventArgs.Results.Done
                        lvFiles.Items.Remove(dt.Item)
                    Case Else
                        dt.Item.ForeColor = Color.Red
                End Select
            Next
        End If

        UpdateQueuedTracksLabel()
    End Sub

    Private Sub SaveItemID3Tags(item As ListViewItem)
        Dim file As TagLib.File = TagLib.File.Create(item.SubItems(5).Text)
        Dim id3 As TagLib.Id3v2.Tag = file.GetTag(TagLib.TagTypes.Id3v2)
        With item
            id3.AlbumArtists = {.SubItems(0).Text}
            id3.Performers = {.SubItems(0).Text}
            id3.Title = .SubItems(1).Text
            id3.Album = .SubItems(2).Text
            id3.Genres = {.SubItems(3).Text}
            id3.Year = UInteger.Parse(.SubItems(4).Text)
        End With

        file.Save()
        file.Dispose()
    End Sub

    Private Sub lvFiles_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvFiles.KeyUp
        If e.KeyCode = Keys.Delete Then
            For Each item As ListViewItem In lvFiles.SelectedItems
                item.Remove()
            Next

            UpdateQueuedTracksLabel()
        End If
    End Sub

    Private Sub lvFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvFiles.SelectedIndexChanged
        If lvFiles.SelectedItems.Count = 0 Then
            gbItemProperties.Enabled = False
            Exit Sub
        Else
            gbItemProperties.Enabled = gbPlayer.Enabled
        End If

        ignoreChangeEvents = True

        Dim isSameArtist As Boolean = True
        Dim isSameTitle As Boolean = True
        Dim isSameAlbum As Boolean = True
        Dim isSameGenre As Boolean = True
        Dim isSameYear As Boolean = True

        For i As Integer = 1 To lvFiles.SelectedItems.Count - 1
            If lvFiles.SelectedItems(i - 1).SubItems(0).Text <> lvFiles.SelectedItems(i).SubItems(0).Text Then isSameArtist = False
            If lvFiles.SelectedItems(i - 1).SubItems(1).Text <> lvFiles.SelectedItems(i).SubItems(1).Text Then isSameTitle = False
            If lvFiles.SelectedItems(i - 1).SubItems(2).Text <> lvFiles.SelectedItems(i).SubItems(2).Text Then isSameAlbum = False
            If lvFiles.SelectedItems(i - 1).SubItems(3).Text <> lvFiles.SelectedItems(i).SubItems(3).Text Then isSameGenre = False
            If lvFiles.SelectedItems(i - 1).SubItems(4).Text <> lvFiles.SelectedItems(i).SubItems(4).Text Then isSameYear = False
        Next

        Dim item As ListViewItem = lvFiles.SelectedItems(0)
        cbArtist.Text = If(isSameArtist, item.SubItems(0).Text, "")
        txtTitle.Text = If(isSameTitle, item.SubItems(1).Text, "")
        cbAlbum.Text = If(isSameAlbum, item.SubItems(2).Text, "")
        cbGenre.Text = If(isSameGenre, item.SubItems(3).Text, "")
        txtYear.Text = If(isSameYear, item.SubItems(4).Text, "")

        txtTitle.Enabled = (lvFiles.SelectedItems.Count = 1)
        btnAuto.Enabled = (lvFiles.SelectedItems.Count = 1)

        ignoreChangeEvents = False
    End Sub

    Private Sub LoadData(ByRef comboBox As ComboBox, data As Object)
        Dim dataACS = New AutoCompleteStringCollection()

        comboBox.DataSource = data
        comboBox.DisplayMember = "name"
        comboBox.ValueMember = "id"

        For Each s In data
            dataACS.Add(s.name)
        Next

        comboBox.AutoCompleteCustomSource = dataACS
        comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        comboBox.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub ItemProperties_TextChanged(sender As Object, e As System.EventArgs) Handles cbArtist.TextChanged, txtTitle.TextChanged, cbAlbum.TextChanged, cbGenre.TextChanged, txtYear.TextChanged
        If ignoreChangeEvents Then Exit Sub

        If TypeOf sender Is TextBox Then
            Dim tb As TextBox = DirectCast(sender, TextBox)
            For Each item As ListViewItem In lvFiles.SelectedItems
                Select Case tb.Name
                    Case "txtTitle" : item.SubItems(1).Text = tb.Text
                    Case "txtYear" : item.SubItems(4).Text = tb.Text
                End Select
            Next
        Else
            Dim cb As ComboBox = DirectCast(sender, ComboBox)
            For Each item As ListViewItem In lvFiles.SelectedItems
                Select Case cb.Name
                    Case "cbArtist" : item.SubItems(0).Text = cb.Text
                    Case "cbAlbum" : item.SubItems(2).Text = If(cb.Text = "", "Unknown", cb.Text)
                    Case "cbGenre" : item.SubItems(3).Text = cb.Text
                End Select
            Next
        End If

        SetPlayingFileName()
    End Sub

    Private Sub SetPlayingFileName()
        If lblSongName.Tag Is Nothing Then
            lblSongName.Text = ""
        Else
            Dim item As ListViewItem = CType(lblSongName.Tag, ListViewItem)
            lblSongName.Text = item.SubItems(0).Text + " - " + item.SubItems(1).Text
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        For Each item As ListViewItem In lvFiles.SelectedItems
            SetItemDataFromID3Tags(item)
        Next
    End Sub

    Private Sub SetItemDataFromID3Tags(item As ListViewItem)
        Dim id3 As TagLib.Id3v2.Tag
        Dim fileName As String = item.SubItems(chFileName.Index).Text

        Try
            id3 = TagLib.File.Create(fileName).GetTag(TagLib.TagTypes.Id3v2)
        Catch ex As Exception
            MsgBox("Unable to read ID3 tags from:" + vbCrLf + "'" + fileName + "'", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
            item.ForeColor = Color.Red
            item.Checked = False
            Exit Sub
        End Try

        Try
            item.SubItems(0).Text = If(id3.FirstPerformer = "", GetArtistFromFileName(fileName), id3.FirstPerformer)
            item.SubItems(1).Text = If(id3.Title = "", GetTitleFromFileName(fileName), id3.Title)
            item.SubItems(2).Text = If(id3.Album = "", "Unknown", id3.Album)
            item.SubItems(3).Text = id3.FirstGenre
            item.SubItems(4).Text = id3.Year
        Catch
        End Try
    End Sub

    Private Function GetTitleFromFileName(fileName As String) As String
        fileName = (New IO.FileInfo(fileName)).Name
        If fileName.Contains(" - ") Then
            Return fileName.Split(" - ")(1)
        Else
            Return ""
        End If
    End Function

    Private Function GetArtistFromFileName(fileName As String) As String
        fileName = (New IO.FileInfo(fileName)).Name
        If fileName.Contains(" - ") Then
            Return fileName.Split(" - ")(0)
        Else
            Return ""
        End If
    End Function

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        StartPlayback()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopPlayback()
    End Sub

    Private Sub StartPlayback()
        StopPlayback()

        If lvFiles.SelectedItems.Count = 1 Then
            hashDataLib.StartPlayback(lvFiles.SelectedItems(0).SubItems(5).Text)
        End If
    End Sub

    Private Sub StopPlayback()
        hashDataLib.StopPlayback()
    End Sub

    Private Sub UpdatePlaybackPosition()
        Me.Invoke(New MethodInvoker(Sub() tbPosition.Value = hashDataLib.PlaybackPosition / hashDataLib.PlaybackFileLength * 100))
    End Sub

    Private Sub tbPosition_Scroll(sender As Object, e As EventArgs) Handles tbPosition.Scroll
        hashDataLib.PlaybackPosition = CLng(tbPosition.Value / 100 * hashDataLib.PlaybackFileLength)
    End Sub

    Private Sub EditDataFromButtons_Click(sender As Object, e As EventArgs) Handles btnEditGenres.Click, btnEditAlbums.Click, btnEditArtists.Click
        Using frm = New DataEditorForm()
            Select Case CType(sender, Button).Name
                Case btnEditArtists.Name
                    frm.EditorDataGridView.DataSource = fpData.Data.Artists
                    frm.lblTableName.Text = "Artists"
                Case btnEditAlbums.Name
                    frm.EditorDataGridView.DataSource = fpData.Data.Albums
                    frm.lblTableName.Text = "Albums"
                Case btnEditGenres.Name
                    frm.EditorDataGridView.DataSource = fpData.Data.Genres
                    frm.lblTableName.Text = "Genres"
            End Select

            frm.EditorDataGridView.Columns(0).Visible = False
            frm.EditorDataGridView.Columns(2).Visible = False
            frm.EditorDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            frm.ShowDialog()

            fpData.Data.SaveChanges()
        End Using
    End Sub

    Private Sub ConfigureSongsDataGrid()
        dbDataGridView.AutoGenerateColumns = False
        dbDataGridView.AllowUserToAddRows = False

        If tbFilter.Text = "" Then
            dbDataGridView.DataSource = fpData.Data.Tracks.AsQueryable()
        Else
            Dim filter As String = tbFilter.Text
            dbDataGridView.DataSource = From s In fpData.Data.Tracks Where
                                        s.Title.Contains(filter) OrElse
                                        s.Artist.Name.Contains(filter) OrElse
                                        s.Album.Name.Contains(filter) OrElse
                                        s.Genre.Name.Contains(filter) OrElse
                                        CStr(s.Year).Contains(filter)
                                        Select s
        End If

        If dbDataGridView.Columns.Count = 0 Then
            Dim ct As DataGridViewTextBoxColumn
            Dim cb As DataGridViewComboBoxColumn

            cb = New DataGridViewComboBoxColumn()
            SetupComboBoxColumn(cb, fpData.Data.Artists, "name", "id", "artistID", "Artist")
            dbDataGridView.Columns.Add(cb)

            ct = New DataGridViewTextBoxColumn()
            ct.DataPropertyName = "title"
            ct.HeaderText = "Title"
            ct.SortMode = DataGridViewColumnSortMode.Automatic
            dbDataGridView.Columns.Add(ct)

            cb = New DataGridViewComboBoxColumn()
            SetupComboBoxColumn(cb, fpData.Data.Albums, "name", "id", "albumID", "Albums")
            dbDataGridView.Columns.Add(cb)

            cb = New DataGridViewComboBoxColumn()
            SetupComboBoxColumn(cb, fpData.Data.Genres, "name", "id", "genreID", "Genres")
            dbDataGridView.Columns.Add(cb)

            ct = New DataGridViewTextBoxColumn()
            ct.DataPropertyName = "year"
            ct.HeaderText = "Year"
            ct.SortMode = DataGridViewColumnSortMode.Automatic
            dbDataGridView.Columns.Add(ct)

            'ct = New DataGridViewTextBoxColumn()
            'ct.DataPropertyName = "fileName"
            'ct.HeaderText = "File Name"
            'ct.ReadOnly = True
            'ct.SortMode = DataGridViewColumnSortMode.Automatic
            'dbDataGridView.Columns.Add(ct)

            dbDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If

        dbDataGridView.AutoResizeColumns()

        lblTracksInDB.Text = fpData.Data.Tracks.Count.ToString("N0") + " Tracks in Database"
    End Sub

    Private Sub SetupComboBoxColumn(cb As DataGridViewComboBoxColumn, dataSource As Object, displayMember As String, valueMember As String, dataPropertyName As String, headerText As String)
        cb.DataSource = Nothing
        cb.DataSource = dataSource
        cb.ValueType = GetType(String)
        cb.DataPropertyName = dataPropertyName
        cb.ValueMember = valueMember
        cb.DisplayMember = displayMember
        cb.HeaderText = headerText
        cb.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        cb.SortMode = DataGridViewColumnSortMode.Automatic
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        cmsEditMenu.Show(btnEdit, New Point(0, btnEdit.Height))
    End Sub

    Private Sub EditDataFromMenu_Click(sender As Object, e As EventArgs) Handles cmsEditMenuArtists.Click, cmsEditMenuAlbums.Click, cmsEditMenuGenres.Click
        Select Case CType(sender, ToolStripMenuItem).Name
            Case cmsEditMenuArtists.Name : EditDataFromButtons_Click(btnEditArtists, Nothing)
            Case cmsEditMenuAlbums.Name : EditDataFromButtons_Click(btnEditAlbums, Nothing)
            Case cmsEditMenuGenres.Name : EditDataFromButtons_Click(btnEditGenres, Nothing)
        End Select
        dbDataGridView.Refresh()
    End Sub

    Private Sub tbFilter_TextChanged(sender As Object, e As EventArgs) Handles tbFilter.TextChanged
        ConfigureSongsDataGrid()
    End Sub

    Private Sub dbDataGridView_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dbDataGridView.DataError
        e.Cancel = True
    End Sub

    Private Sub dbDataGridView_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dbDataGridView.EditingControlShowing
        If TypeOf e.Control Is ComboBox Then
            With DirectCast(e.Control, ComboBox)
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems

                AddHandler .Validating, Sub(sender1 As Object, e1 As System.ComponentModel.CancelEventArgs)
                                            Dim cmb = CType(e.Control, ComboBox)
                                            Dim value As String = cmb.Text

                                            For Each item In cmb.Items
                                                If item.name = value Then Exit Sub
                                            Next

                                            Dim cb As DataGridViewComboBoxColumn = dbDataGridView.Columns(dbDataGridView.CurrentCell.ColumnIndex)

                                            Select Case cb.HeaderText
                                                Case "Artist"
                                                    Dim artist = New Artist()
                                                    artist.Name = value
                                                    fpData.Data.Artists.AddObject(artist)
                                                Case "Album"
                                                    Dim album = New Album()
                                                    album.Name = value
                                                    fpData.Data.Albums.AddObject(album)
                                                    fpData.Data.SaveChanges()
                                                Case "Genre"
                                                    Dim genre = New Genre()
                                                    genre.Name = value
                                                    fpData.Data.Genres.AddObject(genre)
                                                    fpData.Data.SaveChanges()
                                            End Select
                                            fpData.Data.SaveChanges()
                                        End Sub
            End With
        End If
    End Sub

    Private Sub dbDataGridView_SelectionChanged(sender As Object, e As System.EventArgs) Handles dbDataGridView.SelectionChanged
        If dbDataGridView.SelectedRows.Count = 1 Then
            fpvCtrl.Track = CType(dbDataGridView.SelectedRows(0).DataBoundItem, Track)
        Else
            fpvCtrl.Track = Nothing
        End If
    End Sub

    Private Sub UpdateQueuedTracksLabel()
        Dim label = "{0} Tracks Queued"
        Dim validItems As Integer = (From item As ListViewItem In lvFiles.CheckedItems Where item.ForeColor = lvFiles.ForeColor Select item).Count
        Dim failedItems As Integer = (From item As ListViewItem In lvFiles.Items Where item.ForeColor = Color.Red Select item).Count

        If failedItems > 0 Then label += " / {1} Failed"

        lblQueuedTracks.Text = String.Format(label, validItems, failedItems)
    End Sub

    Private Sub btnSelAll_Click(sender As Object, e As EventArgs) Handles btnSelAll.Click
        For Each item As ListViewItem In lvFiles.Items
            item.Checked = True
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Sub btnInv_Click(sender As Object, e As EventArgs) Handles btnSelInv.Click
        For Each item As ListViewItem In lvFiles.Items
            item.Checked = Not item.Checked
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Sub btnNon_Click(sender As Object, e As EventArgs) Handles btnSelNon.Click
        For Each item As ListViewItem In lvFiles.Items
            item.Checked = False
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Sub btnMis_Click(sender As Object, e As EventArgs) Handles btnSelMis.Click
        For Each item As ListViewItem In lvFiles.Items
            item.Checked = Not IsTrackInDB(item.SubItems(chFileName.Index).Text)
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Function IsTrackInDB(fileName As String) As Boolean
        Return (From t In fpData.Data.Tracks Where t.FileName = fileName Select t).Count() <> 0
    End Function

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        StartAnalyzing()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lvFiles.Items.Clear()
    End Sub

    Private Sub btnAuto_Click(sender As Object, e As EventArgs) Handles btnAuto.Click
        Dim fileName As String = lvFiles.SelectedItems(0).SubItems(chFileName.Index).Text
        Dim fi As New IO.FileInfo(fileName)
        fileName = fi.Name.Replace(fi.Extension, "")
        If fileName.Contains("-") Then
            cbArtist.Text = fileName.Split("-")(0).Trim()
            txtTitle.Text = fileName.Split("-")(1).Trim()
            cbAlbum.Text = "Unknown"
        End If
    End Sub
End Class
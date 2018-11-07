Imports System.Threading
Imports FPDataManager
Imports TracksManager.TrackAnalyzer

Public Class TracksManagerForm
    Private fpData As DataManager
    Private hashDataLib As HashLib

    Private ignoreChangeEvents As Boolean
    Private playingPositionUpdateTimer As Timer = New Timer(New TimerCallback(AddressOf UpdatePlaybackPosition), Nothing, Timeout.Infinite, Timeout.Infinite)

    Private Sub SongsManagerForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        FpvCtrl.ShowPlayStopButtons = True
    End Sub

    Private Sub SongsManagerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub

    Private Sub DxvuCtrl_ControlIsReady() Handles DxvuCtrl.ControlIsReady
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
        If recursiveCount = 0 Then LvFiles.SuspendLayout()
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
                Dim item As ListViewItem = LvFiles.Items.Add("")
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
                LvFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
                Application.DoEvents()
            End If
        Next

        recursiveCount -= 1
        If recursiveCount = 0 Then
            LvFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            LvFiles.ResumeLayout()
        End If
    End Sub

    Private Sub LvFiles_DoubleClick(sender As Object, e As EventArgs) Handles LvFiles.DoubleClick
        StartPlayback()
    End Sub

    Private Sub LvFiles_DragDrop(sender As Object, e As DragEventArgs) Handles LvFiles.DragDrop
        If GbPlayer.Enabled Then
            If e.Data.GetFormats().Contains("FileDrop") AndAlso IsDraggingFiles(e.Data) Then
                Dim files As String() = CType(e.Data.GetData("FileDrop"), String())
                Array.Sort(files)
                AddFiles(files)
            End If
        End If

        UpdateQueuedTracksLabel()
    End Sub

    Private Sub LvFiles_DragOver(sender As Object, e As DragEventArgs) Handles LvFiles.DragOver
        If GbPlayer.Enabled Then
            If e.Data.GetFormats().Contains("FileDrop") Then
                e.Effect = If(IsDraggingFiles(e.Data), DragDropEffects.Copy, DragDropEffects.None)
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub InitializeSystem()
        fpData = New DataManager()
        hashDataLib = New HashLib(DxvuCtrl)

        LblSongName.Text = ""
        GbItemProperties.Enabled = False

        LoadData(CbArtist, fpData.Data.Artists)
        LoadData(CbAlbum, fpData.Data.Albums)
        LoadData(CbGenre, fpData.Data.Genres)
        ConfigureSongsDataGrid()

        'Un4seen.Bass.Bass.BASS_Init(-1, 44100, Un4seen.Bass.BASSInit.BASS_DEVICE_DEFAULT, Me.Handle)
        'Un4seen.Bass.AddOn.Mix.BassMix.LoadMe()

        AddHandler hashDataLib.Status, Sub(sender As Object, e As HashLib.StatusEventArgs)
                                           Select Case e.Status
                                               Case FPDataManager.HashLib.StatusFlags.Playing
                                                   If TcTracks.SelectedTab.Name = TpTracksToAnalyze.Name Then LblSongName.Tag = LvFiles.SelectedItems(0)
                                                   SetPlayingFileName()
                                                   playingPositionUpdateTimer.Change(100, 500)
                                               Case FPDataManager.HashLib.StatusFlags.Stopping
                                                   LblSongName.Tag = Nothing
                                                   SetPlayingFileName()
                                                   playingPositionUpdateTimer.Change(Timeout.Infinite, Timeout.Infinite)
                                           End Select
                                       End Sub

        FpvCtrl.AttachToHashDataLib(hashDataLib)
    End Sub

    Private Sub StartAnalyzing()
        StopPlayback()

        Dim dirtyTracks As New List(Of DirtyTrack)

        For Each item As ListViewItem In LvFiles.CheckedItems
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
                        LvFiles.Items.Remove(dt.Item)
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
            id3.AlbumArtists = { .SubItems(0).Text}
            id3.Performers = { .SubItems(0).Text}
            id3.Title = .SubItems(1).Text
            id3.Album = .SubItems(2).Text
            id3.Genres = { .SubItems(3).Text}
            id3.Year = UInteger.Parse(.SubItems(4).Text)
        End With

        file.Save()
        file.Dispose()
    End Sub

    Private Sub LvFiles_KeyUp(sender As Object, e As KeyEventArgs) Handles LvFiles.KeyUp
        If e.KeyCode = Keys.Delete Then
            For Each item As ListViewItem In LvFiles.SelectedItems
                item.Remove()
            Next

            UpdateQueuedTracksLabel()
        End If
    End Sub

    Private Sub LvFiles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvFiles.SelectedIndexChanged
        If LvFiles.SelectedItems.Count = 0 Then
            GbItemProperties.Enabled = False
            Exit Sub
        Else
            GbItemProperties.Enabled = GbPlayer.Enabled
        End If

        ignoreChangeEvents = True

        Dim isSameArtist As Boolean = True
        Dim isSameTitle As Boolean = True
        Dim isSameAlbum As Boolean = True
        Dim isSameGenre As Boolean = True
        Dim isSameYear As Boolean = True

        For i As Integer = 1 To LvFiles.SelectedItems.Count - 1
            If LvFiles.SelectedItems(i - 1).SubItems(0).Text <> LvFiles.SelectedItems(i).SubItems(0).Text Then isSameArtist = False
            If LvFiles.SelectedItems(i - 1).SubItems(1).Text <> LvFiles.SelectedItems(i).SubItems(1).Text Then isSameTitle = False
            If LvFiles.SelectedItems(i - 1).SubItems(2).Text <> LvFiles.SelectedItems(i).SubItems(2).Text Then isSameAlbum = False
            If LvFiles.SelectedItems(i - 1).SubItems(3).Text <> LvFiles.SelectedItems(i).SubItems(3).Text Then isSameGenre = False
            If LvFiles.SelectedItems(i - 1).SubItems(4).Text <> LvFiles.SelectedItems(i).SubItems(4).Text Then isSameYear = False
        Next

        Dim item As ListViewItem = LvFiles.SelectedItems(0)
        CbArtist.Text = If(isSameArtist, item.SubItems(0).Text, "")
        TxtTitle.Text = If(isSameTitle, item.SubItems(1).Text, "")
        CbAlbum.Text = If(isSameAlbum, item.SubItems(2).Text, "")
        CbGenre.Text = If(isSameGenre, item.SubItems(3).Text, "")
        TxtYear.Text = If(isSameYear, item.SubItems(4).Text, "")

        TxtTitle.Enabled = (LvFiles.SelectedItems.Count = 1)
        BtnAuto.Enabled = (LvFiles.SelectedItems.Count = 1)

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

    Private Sub ItemProperties_TextChanged(sender As Object, e As EventArgs) Handles CbArtist.TextChanged, TxtTitle.TextChanged, CbAlbum.TextChanged, CbGenre.TextChanged, TxtYear.TextChanged
        If ignoreChangeEvents Then Exit Sub

        If TypeOf sender Is TextBox Then
            Dim tb As TextBox = DirectCast(sender, TextBox)
            For Each item As ListViewItem In LvFiles.SelectedItems
                Select Case tb.Name
                    Case "txtTitle" : item.SubItems(1).Text = tb.Text
                    Case "txtYear" : item.SubItems(4).Text = tb.Text
                End Select
            Next
        Else
            Dim cb As ComboBox = DirectCast(sender, ComboBox)
            For Each item As ListViewItem In LvFiles.SelectedItems
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
        If LblSongName.Tag Is Nothing Then
            LblSongName.Text = ""
        Else
            Dim item As ListViewItem = CType(LblSongName.Tag, ListViewItem)
            LblSongName.Text = item.SubItems(0).Text + " - " + item.SubItems(1).Text
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        For Each item As ListViewItem In LvFiles.SelectedItems
            SetItemDataFromID3Tags(item)
        Next
    End Sub

    Private Sub SetItemDataFromID3Tags(item As ListViewItem)
        Dim id3 As TagLib.Id3v2.Tag
        Dim fileName As String = item.SubItems(ChFileName.Index).Text

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
        Return If(fileName.Contains(" - "), fileName.Split(" - ")(1), "")
    End Function

    Private Function GetArtistFromFileName(fileName As String) As String
        fileName = (New IO.FileInfo(fileName)).Name
        Return If(fileName.Contains(" - "), fileName.Split(" - ")(0), "")
    End Function

    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles BtnPlay.Click
        StartPlayback()
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        StopPlayback()
    End Sub

    Private Sub StartPlayback()
        StopPlayback()

        If LvFiles.SelectedItems.Count = 1 Then
            hashDataLib.StartPlayback(LvFiles.SelectedItems(0).SubItems(5).Text)
        End If
    End Sub

    Private Sub StopPlayback()
        hashDataLib.StopPlayback()
    End Sub

    Private Sub UpdatePlaybackPosition()
        Me.Invoke(New MethodInvoker(Sub() TbPosition.Value = hashDataLib.PlaybackPosition / hashDataLib.PlaybackFileLength * 100))
    End Sub

    Private Sub TbPosition_Scroll(sender As Object, e As EventArgs) Handles TbPosition.Scroll
        hashDataLib.PlaybackPosition = CLng(TbPosition.Value / 100 * hashDataLib.PlaybackFileLength)
    End Sub

    Private Sub EditDataFromButtons_Click(sender As Object, e As EventArgs) Handles BtnEditGenres.Click, BtnEditAlbums.Click, BtnEditArtists.Click
        Using frm = New DataEditorForm()
            Select Case CType(sender, Button).Name
                Case BtnEditArtists.Name
                    frm.EditorDataGridView.DataSource = fpData.Data.Artists
                    frm.LblTableName.Text = "Artists"
                Case BtnEditAlbums.Name
                    frm.EditorDataGridView.DataSource = fpData.Data.Albums
                    frm.LblTableName.Text = "Albums"
                Case BtnEditGenres.Name
                    frm.EditorDataGridView.DataSource = fpData.Data.Genres
                    frm.LblTableName.Text = "Genres"
            End Select

            frm.EditorDataGridView.Columns(0).Visible = False
            frm.EditorDataGridView.Columns(2).Visible = False
            frm.EditorDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            frm.ShowDialog()

            fpData.Data.SaveChanges()
        End Using
    End Sub

    Private Sub ConfigureSongsDataGrid()
        DbDataGridView.AutoGenerateColumns = False
        DbDataGridView.AllowUserToAddRows = False

        If TbFilter.Text = "" Then
            DbDataGridView.DataSource = fpData.Data.Tracks.AsQueryable()
        Else
            Dim filter As String = TbFilter.Text
            DbDataGridView.DataSource = From s In fpData.Data.Tracks Where
                                        s.Title.Contains(filter) OrElse
                                        s.Artist.Name.Contains(filter) OrElse
                                        s.Album.Name.Contains(filter) OrElse
                                        s.Genre.Name.Contains(filter) OrElse
                                        CStr(s.Year).Contains(filter)
                                        Select s
        End If

        If DbDataGridView.Columns.Count = 0 Then
            Dim ct As DataGridViewTextBoxColumn
            Dim cb As DataGridViewComboBoxColumn

            cb = New DataGridViewComboBoxColumn()
            SetupComboBoxColumn(cb, fpData.Data.Artists, "name", "id", "artistID", "Artist")
            DbDataGridView.Columns.Add(cb)

            ct = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "title",
                .HeaderText = "Title",
                .SortMode = DataGridViewColumnSortMode.Automatic
            }
            DbDataGridView.Columns.Add(ct)

            cb = New DataGridViewComboBoxColumn()
            SetupComboBoxColumn(cb, fpData.Data.Albums, "name", "id", "albumID", "Albums")
            DbDataGridView.Columns.Add(cb)

            cb = New DataGridViewComboBoxColumn()
            SetupComboBoxColumn(cb, fpData.Data.Genres, "name", "id", "genreID", "Genres")
            DbDataGridView.Columns.Add(cb)

            ct = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "year",
                .HeaderText = "Year",
                .SortMode = DataGridViewColumnSortMode.Automatic
            }
            DbDataGridView.Columns.Add(ct)

            'ct = New DataGridViewTextBoxColumn()
            'ct.DataPropertyName = "fileName"
            'ct.HeaderText = "File Name"
            'ct.ReadOnly = True
            'ct.SortMode = DataGridViewColumnSortMode.Automatic
            'dbDataGridView.Columns.Add(ct)

            DbDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If

        DbDataGridView.AutoResizeColumns()

        LblTracksInDB.Text = fpData.Data.Tracks.Count.ToString("N0") + " Tracks in Database"
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

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        CmsEditMenu.Show(BtnEdit, New Point(0, BtnEdit.Height))
    End Sub

    Private Sub EditDataFromMenu_Click(sender As Object, e As EventArgs) Handles CmsEditMenuArtists.Click, CmsEditMenuAlbums.Click, CmsEditMenuGenres.Click
        Select Case CType(sender, ToolStripMenuItem).Name
            Case CmsEditMenuArtists.Name : EditDataFromButtons_Click(BtnEditArtists, Nothing)
            Case CmsEditMenuAlbums.Name : EditDataFromButtons_Click(BtnEditAlbums, Nothing)
            Case CmsEditMenuGenres.Name : EditDataFromButtons_Click(BtnEditGenres, Nothing)
        End Select
        DbDataGridView.Refresh()
    End Sub

    Private Sub TbFilter_TextChanged(sender As Object, e As EventArgs) Handles TbFilter.TextChanged
        ConfigureSongsDataGrid()
    End Sub

    Private Sub DbDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DbDataGridView.DataError
        e.Cancel = True
    End Sub

    Private Sub DbDataGridView_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DbDataGridView.EditingControlShowing
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

                                            Dim cb As DataGridViewComboBoxColumn = DbDataGridView.Columns(DbDataGridView.CurrentCell.ColumnIndex)

                                            Select Case cb.HeaderText
                                                Case "Artist"
                                                    Dim artist = New Artist With {.Name = value}
                                                    fpData.Data.Artists.AddObject(artist)
                                                Case "Album"
                                                    Dim album = New Album With {.Name = value}
                                                    fpData.Data.Albums.AddObject(album)
                                                    fpData.Data.SaveChanges()
                                                Case "Genre"
                                                    Dim genre = New Genre With {.Name = value}
                                                    fpData.Data.Genres.AddObject(genre)
                                                    fpData.Data.SaveChanges()
                                            End Select
                                            fpData.Data.SaveChanges()
                                        End Sub
            End With
        End If
    End Sub

    Private Sub DbDataGridView_SelectionChanged(sender As Object, e As EventArgs) Handles DbDataGridView.SelectionChanged
        FpvCtrl.Track = If(DbDataGridView.SelectedRows.Count = 1, CType(DbDataGridView.SelectedRows(0).DataBoundItem, Track), Nothing)
    End Sub

    Private Sub UpdateQueuedTracksLabel()
        Dim label = "{0} Tracks Queued"
        Dim validItems As Integer = (From item As ListViewItem In LvFiles.CheckedItems Where item.ForeColor = LvFiles.ForeColor Select item).Count
        Dim failedItems As Integer = (From item As ListViewItem In LvFiles.Items Where item.ForeColor = Color.Red Select item).Count

        If failedItems > 0 Then label += " / {1} Failed"

        LblQueuedTracks.Text = String.Format(label, validItems, failedItems)
    End Sub

    Private Sub BtnSelAll_Click(sender As Object, e As EventArgs) Handles BtnSelAll.Click
        For Each item As ListViewItem In LvFiles.Items
            item.Checked = True
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Sub BtnInv_Click(sender As Object, e As EventArgs) Handles BtnSelInv.Click
        For Each item As ListViewItem In LvFiles.Items
            item.Checked = Not item.Checked
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Sub BtnNon_Click(sender As Object, e As EventArgs) Handles BtnSelNon.Click
        For Each item As ListViewItem In LvFiles.Items
            item.Checked = False
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Sub BtnMis_Click(sender As Object, e As EventArgs) Handles BtnSelMis.Click
        For Each item As ListViewItem In LvFiles.Items
            item.Checked = Not IsTrackInDB(item.SubItems(ChFileName.Index).Text)
        Next
        UpdateQueuedTracksLabel()
    End Sub

    Private Function IsTrackInDB(fileName As String) As Boolean
        Return (From t In fpData.Data.Tracks Where t.FileName = fileName Select t).Count() <> 0
    End Function

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        StartAnalyzing()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        LvFiles.Items.Clear()
    End Sub

    Private Sub BtnAuto_Click(sender As Object, e As EventArgs) Handles BtnAuto.Click
        Dim fileName As String = LvFiles.SelectedItems(0).SubItems(ChFileName.Index).Text
        Dim fi As New IO.FileInfo(fileName)
        fileName = fi.Name.Replace(fi.Extension, "")
        If fileName.Contains("-") Then
            CbArtist.Text = fileName.Split("-")(0).Trim()
            TxtTitle.Text = fileName.Split("-")(1).Trim()
            CbAlbum.Text = "Unknown"
        End If
    End Sub
End Class
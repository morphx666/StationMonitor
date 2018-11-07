<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TracksManagerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                playingPositionUpdateTimer.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lvFiles = New TracksManager.TracksListView()
        Me.chArtist = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAlbum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chGenre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chYear = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chFileName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbItemProperties = New System.Windows.Forms.GroupBox()
        Me.btnAuto = New System.Windows.Forms.Button()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.cbGenre = New System.Windows.Forms.ComboBox()
        Me.btnEditGenres = New System.Windows.Forms.Button()
        Me.btnEditAlbums = New System.Windows.Forms.Button()
        Me.btnEditArtists = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAlbum = New System.Windows.Forms.ComboBox()
        Me.cbArtist = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.gbPlayer = New System.Windows.Forms.GroupBox()
        Me.tbPosition = New System.Windows.Forms.TrackBar()
        Me.lblSongName = New System.Windows.Forms.Label()
        Me.dxvuCtrl = New NDXVUMeterNET.DXVUMeterNETGDI()
        Me.tcTracks = New System.Windows.Forms.TabControl()
        Me.tpTracksToAnalyze = New System.Windows.Forms.TabPage()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnSelMis = New System.Windows.Forms.Button()
        Me.btnSelNon = New System.Windows.Forms.Button()
        Me.btnSelInv = New System.Windows.Forms.Button()
        Me.btnSelAll = New System.Windows.Forms.Button()
        Me.tpTracksInDB = New System.Windows.Forms.TabPage()
        Me.fpvCtrl = New FPDataManager.FingerprintViewer()
        Me.tbFilter = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.dbDataGridView = New System.Windows.Forms.DataGridView()
        Me.cmsEditMenu = New System.Windows.Forms.ContextMenuStrip()
        Me.cmsEditMenuArtists = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsEditMenuAlbums = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsEditMenuGenres = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTracksInDB = New System.Windows.Forms.Label()
        Me.lblQueuedTracks = New System.Windows.Forms.Label()
        Me.gbItemProperties.SuspendLayout()
        Me.gbPlayer.SuspendLayout()
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcTracks.SuspendLayout()
        Me.tpTracksToAnalyze.SuspendLayout()
        Me.tpTracksInDB.SuspendLayout()
        CType(Me.dbDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEditMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvFiles
        '
        Me.lvFiles.AllowDrop = True
        Me.lvFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFiles.CheckBoxes = True
        Me.lvFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chArtist, Me.chTitle, Me.chAlbum, Me.chGenre, Me.chYear, Me.chFileName})
        Me.lvFiles.FullRowSelect = True
        Me.lvFiles.GridLines = True
        Me.lvFiles.HideSelection = False
        Me.lvFiles.Location = New System.Drawing.Point(6, 6)
        Me.lvFiles.Name = "lvFiles"
        Me.lvFiles.Size = New System.Drawing.Size(517, 488)
        Me.lvFiles.TabIndex = 0
        Me.lvFiles.UseCompatibleStateImageBehavior = False
        Me.lvFiles.View = System.Windows.Forms.View.Details
        '
        'chArtist
        '
        Me.chArtist.Text = "Artist"
        '
        'chTitle
        '
        Me.chTitle.Text = "Title"
        '
        'chAlbum
        '
        Me.chAlbum.Text = "Album"
        '
        'chGenre
        '
        Me.chGenre.Text = "Genre"
        '
        'chYear
        '
        Me.chYear.Text = "Year"
        Me.chYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chFileName
        '
        Me.chFileName.Text = "File Name"
        '
        'gbItemProperties
        '
        Me.gbItemProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbItemProperties.Controls.Add(Me.btnAuto)
        Me.gbItemProperties.Controls.Add(Me.txtYear)
        Me.gbItemProperties.Controls.Add(Me.Label5)
        Me.gbItemProperties.Controls.Add(Me.btnReset)
        Me.gbItemProperties.Controls.Add(Me.cbGenre)
        Me.gbItemProperties.Controls.Add(Me.btnEditGenres)
        Me.gbItemProperties.Controls.Add(Me.btnEditAlbums)
        Me.gbItemProperties.Controls.Add(Me.btnEditArtists)
        Me.gbItemProperties.Controls.Add(Me.Label6)
        Me.gbItemProperties.Controls.Add(Me.cbAlbum)
        Me.gbItemProperties.Controls.Add(Me.cbArtist)
        Me.gbItemProperties.Controls.Add(Me.Label4)
        Me.gbItemProperties.Controls.Add(Me.txtTitle)
        Me.gbItemProperties.Controls.Add(Me.Label3)
        Me.gbItemProperties.Controls.Add(Me.Label2)
        Me.gbItemProperties.Location = New System.Drawing.Point(558, 12)
        Me.gbItemProperties.Name = "gbItemProperties"
        Me.gbItemProperties.Size = New System.Drawing.Size(386, 260)
        Me.gbItemProperties.TabIndex = 14
        Me.gbItemProperties.TabStop = False
        Me.gbItemProperties.Text = "Item Properties"
        '
        'btnAuto
        '
        Me.btnAuto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAuto.Location = New System.Drawing.Point(69, 227)
        Me.btnAuto.Name = "btnAuto"
        Me.btnAuto.Size = New System.Drawing.Size(87, 27)
        Me.btnAuto.TabIndex = 17
        Me.btnAuto.Text = "Auto"
        Me.btnAuto.UseVisualStyleBackColor = True
        '
        'txtYear
        '
        Me.txtYear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYear.Location = New System.Drawing.Point(69, 145)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(310, 23)
        Me.txtYear.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Year"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(292, 227)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(87, 27)
        Me.btnReset.TabIndex = 15
        Me.btnReset.Text = "Reset Data"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'cbGenre
        '
        Me.cbGenre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbGenre.FormattingEnabled = True
        Me.cbGenre.Location = New System.Drawing.Point(69, 114)
        Me.cbGenre.Name = "cbGenre"
        Me.cbGenre.Size = New System.Drawing.Size(273, 23)
        Me.cbGenre.TabIndex = 10
        '
        'btnEditGenres
        '
        Me.btnEditGenres.Location = New System.Drawing.Point(350, 114)
        Me.btnEditGenres.Name = "btnEditGenres"
        Me.btnEditGenres.Size = New System.Drawing.Size(29, 24)
        Me.btnEditGenres.TabIndex = 12
        Me.btnEditGenres.Text = "..."
        Me.btnEditGenres.UseVisualStyleBackColor = True
        '
        'btnEditAlbums
        '
        Me.btnEditAlbums.Location = New System.Drawing.Point(350, 83)
        Me.btnEditAlbums.Name = "btnEditAlbums"
        Me.btnEditAlbums.Size = New System.Drawing.Size(29, 24)
        Me.btnEditAlbums.TabIndex = 12
        Me.btnEditAlbums.Text = "..."
        Me.btnEditAlbums.UseVisualStyleBackColor = True
        '
        'btnEditArtists
        '
        Me.btnEditArtists.Location = New System.Drawing.Point(350, 22)
        Me.btnEditArtists.Name = "btnEditArtists"
        Me.btnEditArtists.Size = New System.Drawing.Size(29, 24)
        Me.btnEditArtists.TabIndex = 12
        Me.btnEditArtists.Text = "..."
        Me.btnEditArtists.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Genre"
        '
        'cbAlbum
        '
        Me.cbAlbum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAlbum.FormattingEnabled = True
        Me.cbAlbum.Location = New System.Drawing.Point(69, 83)
        Me.cbAlbum.Name = "cbAlbum"
        Me.cbAlbum.Size = New System.Drawing.Size(273, 23)
        Me.cbAlbum.TabIndex = 8
        '
        'cbArtist
        '
        Me.cbArtist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbArtist.FormattingEnabled = True
        Me.cbArtist.Location = New System.Drawing.Point(69, 22)
        Me.cbArtist.Name = "cbArtist"
        Me.cbArtist.Size = New System.Drawing.Size(273, 23)
        Me.cbArtist.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Album"
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTitle.Location = New System.Drawing.Point(69, 53)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(310, 23)
        Me.txtTitle.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Title"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Artist"
        '
        'btnPlay
        '
        Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPlay.Location = New System.Drawing.Point(7, 261)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(49, 27)
        Me.btnPlay.TabIndex = 16
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Location = New System.Drawing.Point(63, 261)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(49, 27)
        Me.btnStop.TabIndex = 16
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'gbPlayer
        '
        Me.gbPlayer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPlayer.Controls.Add(Me.tbPosition)
        Me.gbPlayer.Controls.Add(Me.lblSongName)
        Me.gbPlayer.Controls.Add(Me.btnStop)
        Me.gbPlayer.Controls.Add(Me.btnPlay)
        Me.gbPlayer.Controls.Add(Me.dxvuCtrl)
        Me.gbPlayer.Location = New System.Drawing.Point(558, 278)
        Me.gbPlayer.Name = "gbPlayer"
        Me.gbPlayer.Size = New System.Drawing.Size(386, 295)
        Me.gbPlayer.TabIndex = 17
        Me.gbPlayer.TabStop = False
        Me.gbPlayer.Text = "Player"
        '
        'tbPosition
        '
        Me.tbPosition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPosition.AutoSize = False
        Me.tbPosition.LargeChange = 10
        Me.tbPosition.Location = New System.Drawing.Point(7, 42)
        Me.tbPosition.Maximum = 100
        Me.tbPosition.Name = "tbPosition"
        Me.tbPosition.Size = New System.Drawing.Size(372, 23)
        Me.tbPosition.TabIndex = 18
        Me.tbPosition.TickFrequency = 2
        '
        'lblSongName
        '
        Me.lblSongName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSongName.AutoEllipsis = True
        Me.lblSongName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSongName.Location = New System.Drawing.Point(10, 18)
        Me.lblSongName.Name = "lblSongName"
        Me.lblSongName.Size = New System.Drawing.Size(369, 18)
        Me.lblSongName.TabIndex = 17
        Me.lblSongName.Text = "Playing Song Information"
        Me.lblSongName.UseMnemonic = False
        '
        'dxvuCtrl
        '
        Me.dxvuCtrl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dxvuCtrl.BackColor = System.Drawing.Color.Black
        Me.dxvuCtrl.BitDepth = CType(16, Short)
        Me.dxvuCtrl.Channels = CType(2, Short)
        Me.dxvuCtrl.EnableRendering = True
        Me.dxvuCtrl.FFTDetectDTMF = False
        Me.dxvuCtrl.FFTHighPrecisionMode = False
        Me.dxvuCtrl.FFTHistorySize = 4
        Me.dxvuCtrl.FFTHoldMaxPeaks = False
        Me.dxvuCtrl.FFTHoldMinPeaks = False
        Me.dxvuCtrl.FFTLineChannelMode = NDXVUMeterNET.DXVUMeterNETGDI.FFTLineChannelModeConstants.Normal
        Me.dxvuCtrl.FFTNormalized = True
        Me.dxvuCtrl.FFTPeaksDecayDelay = 10
        Me.dxvuCtrl.FFTPeaksDecaySpeed = 20
        Me.dxvuCtrl.FFTPlotNoiseReduction = 0
        Me.dxvuCtrl.FFTRenderScales = NDXVUMeterNET.DXVUMeterNETGDI.FFTRenderScalesConstants.Both
        Me.dxvuCtrl.FFTScaleFont = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dxvuCtrl.FFTShowDecay = False
        Me.dxvuCtrl.FFTShowMinMaxRange = False
        Me.dxvuCtrl.FFTSize = NDXVUMeterNET.FFT.FFTSizeConstants.FFTs512
        Me.dxvuCtrl.FFTSmoothing = 0
        Me.dxvuCtrl.FFTStyle = NDXVUMeterNET.DXVUMeterNETGDI.FFTStyleConstants.Line
        Me.dxvuCtrl.FFTWindow = NDXVUMeterNET.FFT.FFTWindowConstants.None
        Me.dxvuCtrl.FFTXMax = 22050
        Me.dxvuCtrl.FFTXMin = 0
        Me.dxvuCtrl.FFTXScale = NDXVUMeterNET.DXVUMeterNETGDI.FFTXScaleConstants.Normal
        Me.dxvuCtrl.FFTXZoom = False
        Me.dxvuCtrl.FFTXZoomWindowPos = 0
        Me.dxvuCtrl.FFTYScale = NDXVUMeterNET.DXVUMeterNETGDI.FFTYScaleConstants.dB
        Me.dxvuCtrl.FFTYScaleMultiplier = 1.0R
        Me.dxvuCtrl.Frequency = 44100
        Me.dxvuCtrl.GreenOff = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dxvuCtrl.GreenOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dxvuCtrl.LeftChannelMute = False
        Me.dxvuCtrl.LinesThickness = 1
        Me.dxvuCtrl.Location = New System.Drawing.Point(7, 72)
        Me.dxvuCtrl.Name = "dxvuCtrl"
        Me.dxvuCtrl.NoiseFilter = 0
        Me.dxvuCtrl.NumVUs = CType(32, Short)
        Me.dxvuCtrl.Orientation = NDXVUMeterNET.DXVUMeterNETGDI.OrientationConstants.Horizontal
        Me.dxvuCtrl.Overlap = 0.0R
        Me.dxvuCtrl.PlaybackPosition = CType(0, Long)
        Me.dxvuCtrl.PlaybackTime = ""
        Me.dxvuCtrl.PlaybackVolume = CType(0, Short)
        Me.dxvuCtrl.RedOff = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dxvuCtrl.RedOn = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dxvuCtrl.RightChannelMute = False
        Me.dxvuCtrl.Size = New System.Drawing.Size(372, 183)
        Me.dxvuCtrl.Style = NDXVUMeterNET.DXVUMeterNETGDI.StyleConstants.Oscilloscope
        Me.dxvuCtrl.TabIndex = 0
        Me.dxvuCtrl.YellowOff = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dxvuCtrl.YellowOn = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'tcTracks
        '
        Me.tcTracks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcTracks.Controls.Add(Me.tpTracksToAnalyze)
        Me.tcTracks.Controls.Add(Me.tpTracksInDB)
        Me.tcTracks.Location = New System.Drawing.Point(14, 12)
        Me.tcTracks.MinimumSize = New System.Drawing.Size(367, 410)
        Me.tcTracks.Name = "tcTracks"
        Me.tcTracks.SelectedIndex = 0
        Me.tcTracks.Size = New System.Drawing.Size(537, 561)
        Me.tcTracks.TabIndex = 19
        '
        'tpTracksToAnalyze
        '
        Me.tpTracksToAnalyze.Controls.Add(Me.btnClear)
        Me.tpTracksToAnalyze.Controls.Add(Me.btnStart)
        Me.tpTracksToAnalyze.Controls.Add(Me.btnSelMis)
        Me.tpTracksToAnalyze.Controls.Add(Me.btnSelNon)
        Me.tpTracksToAnalyze.Controls.Add(Me.btnSelInv)
        Me.tpTracksToAnalyze.Controls.Add(Me.btnSelAll)
        Me.tpTracksToAnalyze.Controls.Add(Me.lvFiles)
        Me.tpTracksToAnalyze.Location = New System.Drawing.Point(4, 24)
        Me.tpTracksToAnalyze.Name = "tpTracksToAnalyze"
        Me.tpTracksToAnalyze.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTracksToAnalyze.Size = New System.Drawing.Size(529, 533)
        Me.tpTracksToAnalyze.TabIndex = 0
        Me.tpTracksToAnalyze.Text = "Analyze Tracks"
        Me.tpTracksToAnalyze.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(302, 500)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(60, 27)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(463, 500)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(60, 27)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnSelMis
        '
        Me.btnSelMis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelMis.Location = New System.Drawing.Point(204, 500)
        Me.btnSelMis.Name = "btnSelMis"
        Me.btnSelMis.Size = New System.Drawing.Size(60, 27)
        Me.btnSelMis.TabIndex = 2
        Me.btnSelMis.Text = "Missing"
        Me.btnSelMis.UseVisualStyleBackColor = True
        '
        'btnSelNon
        '
        Me.btnSelNon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelNon.Location = New System.Drawing.Point(138, 500)
        Me.btnSelNon.Name = "btnSelNon"
        Me.btnSelNon.Size = New System.Drawing.Size(60, 27)
        Me.btnSelNon.TabIndex = 2
        Me.btnSelNon.Text = "None"
        Me.btnSelNon.UseVisualStyleBackColor = True
        '
        'btnSelInv
        '
        Me.btnSelInv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelInv.Location = New System.Drawing.Point(72, 500)
        Me.btnSelInv.Name = "btnSelInv"
        Me.btnSelInv.Size = New System.Drawing.Size(60, 27)
        Me.btnSelInv.TabIndex = 2
        Me.btnSelInv.Text = "Inv"
        Me.btnSelInv.UseVisualStyleBackColor = True
        '
        'btnSelAll
        '
        Me.btnSelAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelAll.Location = New System.Drawing.Point(6, 500)
        Me.btnSelAll.Name = "btnSelAll"
        Me.btnSelAll.Size = New System.Drawing.Size(60, 27)
        Me.btnSelAll.TabIndex = 2
        Me.btnSelAll.Text = "All"
        Me.btnSelAll.UseVisualStyleBackColor = True
        '
        'tpTracksInDB
        '
        Me.tpTracksInDB.Controls.Add(Me.fpvCtrl)
        Me.tpTracksInDB.Controls.Add(Me.tbFilter)
        Me.tpTracksInDB.Controls.Add(Me.Label7)
        Me.tpTracksInDB.Controls.Add(Me.btnEdit)
        Me.tpTracksInDB.Controls.Add(Me.dbDataGridView)
        Me.tpTracksInDB.Location = New System.Drawing.Point(4, 24)
        Me.tpTracksInDB.Name = "tpTracksInDB"
        Me.tpTracksInDB.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTracksInDB.Size = New System.Drawing.Size(529, 533)
        Me.tpTracksInDB.TabIndex = 1
        Me.tpTracksInDB.Text = "Tracks In Database"
        Me.tpTracksInDB.UseVisualStyleBackColor = True
        '
        'fpvCtrl
        '
        Me.fpvCtrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fpvCtrl.HashBands = 32
        Me.fpvCtrl.Location = New System.Drawing.Point(403, 6)
        Me.fpvCtrl.Mode = FPDataManager.FingerprintViewer.Modes.Hashes
        Me.fpvCtrl.Name = "fpvCtrl"
        Me.fpvCtrl.ShowCursor = True
        Me.fpvCtrl.ShowPlayStopButtons = False
        Me.fpvCtrl.Size = New System.Drawing.Size(120, 439)
        Me.fpvCtrl.TabIndex = 6
        '
        'tbFilter
        '
        Me.tbFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFilter.Location = New System.Drawing.Point(6, 454)
        Me.tbFilter.Name = "tbFilter"
        Me.tbFilter.Size = New System.Drawing.Size(252, 23)
        Me.tbFilter.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 518)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Filter"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Location = New System.Drawing.Point(436, 451)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(87, 27)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'dbDataGridView
        '
        Me.dbDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dbDataGridView.Location = New System.Drawing.Point(6, 6)
        Me.dbDataGridView.Name = "dbDataGridView"
        Me.dbDataGridView.Size = New System.Drawing.Size(391, 439)
        Me.dbDataGridView.TabIndex = 0
        '
        'cmsEditMenu
        '
        Me.cmsEditMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsEditMenuArtists, Me.cmsEditMenuAlbums, Me.cmsEditMenuGenres})
        Me.cmsEditMenu.Name = "cmsEditMenu"
        Me.cmsEditMenu.Size = New System.Drawing.Size(125, 70)
        '
        'cmsEditMenuArtists
        '
        Me.cmsEditMenuArtists.Name = "cmsEditMenuArtists"
        Me.cmsEditMenuArtists.Size = New System.Drawing.Size(124, 22)
        Me.cmsEditMenuArtists.Text = "Artists..."
        '
        'cmsEditMenuAlbums
        '
        Me.cmsEditMenuAlbums.Name = "cmsEditMenuAlbums"
        Me.cmsEditMenuAlbums.Size = New System.Drawing.Size(124, 22)
        Me.cmsEditMenuAlbums.Text = "Albums..."
        '
        'cmsEditMenuGenres
        '
        Me.cmsEditMenuGenres.Name = "cmsEditMenuGenres"
        Me.cmsEditMenuGenres.Size = New System.Drawing.Size(124, 22)
        Me.cmsEditMenuGenres.Text = "Genres..."
        '
        'lblTracksInDB
        '
        Me.lblTracksInDB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTracksInDB.BackColor = System.Drawing.SystemColors.Control
        Me.lblTracksInDB.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblTracksInDB.Location = New System.Drawing.Point(339, 576)
        Me.lblTracksInDB.Name = "lblTracksInDB"
        Me.lblTracksInDB.Size = New System.Drawing.Size(212, 15)
        Me.lblTracksInDB.TabIndex = 6
        Me.lblTracksInDB.Text = "0 Tracks in Database"
        Me.lblTracksInDB.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblQueuedTracks
        '
        Me.lblQueuedTracks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQueuedTracks.AutoSize = True
        Me.lblQueuedTracks.BackColor = System.Drawing.SystemColors.Control
        Me.lblQueuedTracks.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblQueuedTracks.Location = New System.Drawing.Point(12, 576)
        Me.lblQueuedTracks.Name = "lblQueuedTracks"
        Me.lblQueuedTracks.Size = New System.Drawing.Size(95, 15)
        Me.lblQueuedTracks.TabIndex = 20
        Me.lblQueuedTracks.Text = "0 Tracks Queued"
        '
        'TracksManagerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 600)
        Me.Controls.Add(Me.lblQueuedTracks)
        Me.Controls.Add(Me.lblTracksInDB)
        Me.Controls.Add(Me.tcTracks)
        Me.Controls.Add(Me.gbPlayer)
        Me.Controls.Add(Me.gbItemProperties)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TracksManagerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tracks Manager"
        Me.gbItemProperties.ResumeLayout(False)
        Me.gbItemProperties.PerformLayout()
        Me.gbPlayer.ResumeLayout(False)
        CType(Me.tbPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcTracks.ResumeLayout(False)
        Me.tpTracksToAnalyze.ResumeLayout(False)
        Me.tpTracksInDB.ResumeLayout(False)
        Me.tpTracksInDB.PerformLayout()
        CType(Me.dbDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEditMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvFiles As TracksListView
    Friend WithEvents chFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents dxvuCtrl As NDXVUMeterNET.DXVUMeterNETGDI
    Friend WithEvents chArtist As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAlbum As System.Windows.Forms.ColumnHeader
    Friend WithEvents chGenre As System.Windows.Forms.ColumnHeader
    Friend WithEvents chYear As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbItemProperties As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbGenre As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbAlbum As System.Windows.Forms.ComboBox
    Friend WithEvents cbArtist As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents gbPlayer As System.Windows.Forms.GroupBox
    Friend WithEvents tbPosition As System.Windows.Forms.TrackBar
    Friend WithEvents lblSongName As System.Windows.Forms.Label
    Friend WithEvents btnEditGenres As System.Windows.Forms.Button
    Friend WithEvents btnEditAlbums As System.Windows.Forms.Button
    Friend WithEvents btnEditArtists As System.Windows.Forms.Button
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents tcTracks As System.Windows.Forms.TabControl
    Friend WithEvents tpTracksToAnalyze As System.Windows.Forms.TabPage
    Friend WithEvents tpTracksInDB As System.Windows.Forms.TabPage
    Friend WithEvents dbDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents cmsEditMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsEditMenuArtists As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsEditMenuAlbums As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsEditMenuGenres As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTracksInDB As System.Windows.Forms.Label
    Friend WithEvents fpvCtrl As FPDataManager.FingerprintViewer
    Friend WithEvents lblQueuedTracks As System.Windows.Forms.Label
    Friend WithEvents btnSelMis As System.Windows.Forms.Button
    Friend WithEvents btnSelNon As System.Windows.Forms.Button
    Friend WithEvents btnSelInv As System.Windows.Forms.Button
    Friend WithEvents btnSelAll As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnAuto As System.Windows.Forms.Button
End Class

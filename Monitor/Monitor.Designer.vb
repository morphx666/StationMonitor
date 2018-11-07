<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Monitor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Monitor))
        Me.lblStationName = New System.Windows.Forms.Label()
        Me.btnPlayedTracks = New System.Windows.Forms.Button()
        Me.btnDetectedTracks = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ResultLabel5 = New StationMonitor.ResultLabel()
        Me.ResultLabel4 = New StationMonitor.ResultLabel()
        Me.ResultLabel3 = New StationMonitor.ResultLabel()
        Me.ResultLabel2 = New StationMonitor.ResultLabel()
        Me.ResultLabel1 = New StationMonitor.ResultLabel()
        Me.dxvuCtrl = New NDXVUMeterNET.DXVUMeterNETGDI()
        Me.rlLockedTrack = New StationMonitor.ResultLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStationName
        '
        Me.lblStationName.AutoSize = True
        Me.lblStationName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationName.Location = New System.Drawing.Point(34, 6)
        Me.lblStationName.Name = "lblStationName"
        Me.lblStationName.Size = New System.Drawing.Size(92, 17)
        Me.lblStationName.TabIndex = 57
        Me.lblStationName.Text = "Station Name"
        Me.lblStationName.UseMnemonic = False
        '
        'btnPlayedTracks
        '
        Me.btnPlayedTracks.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnPlayedTracks.FlatAppearance.BorderSize = 0
        Me.btnPlayedTracks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnPlayedTracks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnPlayedTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlayedTracks.Image = Global.StationMonitor.My.Resources.Resources.PlayedTracksIcon
        Me.btnPlayedTracks.Location = New System.Drawing.Point(3, 86)
        Me.btnPlayedTracks.Name = "btnPlayedTracks"
        Me.btnPlayedTracks.Size = New System.Drawing.Size(25, 21)
        Me.btnPlayedTracks.TabIndex = 7
        Me.btnPlayedTracks.UseVisualStyleBackColor = True
        '
        'btnDetectedTracks
        '
        Me.btnDetectedTracks.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDetectedTracks.FlatAppearance.BorderSize = 0
        Me.btnDetectedTracks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnDetectedTracks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnDetectedTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetectedTracks.Image = CType(resources.GetObject("btnDetectedTracks.Image"), System.Drawing.Image)
        Me.btnDetectedTracks.Location = New System.Drawing.Point(3, 59)
        Me.btnDetectedTracks.Name = "btnDetectedTracks"
        Me.btnDetectedTracks.Size = New System.Drawing.Size(25, 21)
        Me.btnDetectedTracks.TabIndex = 7
        Me.btnDetectedTracks.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Image = Global.StationMonitor.My.Resources.Resources.SettingsIcon
        Me.btnSettings.Location = New System.Drawing.Point(3, 4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(25, 21)
        Me.btnSettings.TabIndex = 7
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Image = Global.StationMonitor.My.Resources.Resources.StopIcon
        Me.btnStop.Location = New System.Drawing.Point(489, 23)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(50, 32)
        Me.btnStop.TabIndex = 7
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Image = Global.StationMonitor.My.Resources.Resources.PlayIcon
        Me.btnStart.Location = New System.Drawing.Point(433, 23)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(50, 32)
        Me.btnStart.TabIndex = 7
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ResultLabel5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ResultLabel4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ResultLabel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ResultLabel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ResultLabel1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(34, 59)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(197, 102)
        Me.TableLayoutPanel1.TabIndex = 59
        '
        'ResultLabel5
        '
        Me.ResultLabel5.AutoSize = True
        Me.ResultLabel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ResultLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ResultLabel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultLabel5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultLabel5.ForeColor = System.Drawing.Color.LightGray
        Me.ResultLabel5.Location = New System.Drawing.Point(3, 83)
        Me.ResultLabel5.Name = "ResultLabel5"
        Me.ResultLabel5.Size = New System.Drawing.Size(191, 16)
        Me.ResultLabel5.TabIndex = 64
        '
        'ResultLabel4
        '
        Me.ResultLabel4.AutoSize = True
        Me.ResultLabel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ResultLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ResultLabel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultLabel4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultLabel4.ForeColor = System.Drawing.Color.Silver
        Me.ResultLabel4.Location = New System.Drawing.Point(3, 63)
        Me.ResultLabel4.Name = "ResultLabel4"
        Me.ResultLabel4.Size = New System.Drawing.Size(191, 14)
        Me.ResultLabel4.TabIndex = 63
        '
        'ResultLabel3
        '
        Me.ResultLabel3.AutoSize = True
        Me.ResultLabel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ResultLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ResultLabel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultLabel3.ForeColor = System.Drawing.Color.DarkGray
        Me.ResultLabel3.Location = New System.Drawing.Point(3, 43)
        Me.ResultLabel3.Name = "ResultLabel3"
        Me.ResultLabel3.Size = New System.Drawing.Size(191, 14)
        Me.ResultLabel3.TabIndex = 62
        '
        'ResultLabel2
        '
        Me.ResultLabel2.AutoSize = True
        Me.ResultLabel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ResultLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ResultLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultLabel2.ForeColor = System.Drawing.Color.Gray
        Me.ResultLabel2.Location = New System.Drawing.Point(3, 23)
        Me.ResultLabel2.Name = "ResultLabel2"
        Me.ResultLabel2.Size = New System.Drawing.Size(191, 14)
        Me.ResultLabel2.TabIndex = 61
        '
        'ResultLabel1
        '
        Me.ResultLabel1.AutoSize = True
        Me.ResultLabel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ResultLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ResultLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResultLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultLabel1.ForeColor = System.Drawing.Color.DimGray
        Me.ResultLabel1.Location = New System.Drawing.Point(3, 3)
        Me.ResultLabel1.Name = "ResultLabel1"
        Me.ResultLabel1.Size = New System.Drawing.Size(191, 14)
        Me.ResultLabel1.TabIndex = 60
        '
        'dxvuCtrl
        '
        Me.dxvuCtrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
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
        Me.dxvuCtrl.FFTRenderScales = NDXVUMeterNET.DXVUMeterNETGDI.FFTRenderScalesConstants.None
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
        Me.dxvuCtrl.Location = New System.Drawing.Point(237, 59)
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
        Me.dxvuCtrl.Size = New System.Drawing.Size(302, 102)
        Me.dxvuCtrl.Style = NDXVUMeterNET.DXVUMeterNETGDI.StyleConstants.FFT
        Me.dxvuCtrl.TabIndex = 56
        Me.dxvuCtrl.YellowOff = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dxvuCtrl.YellowOn = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'rlLockedTrack
        '
        Me.rlLockedTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rlLockedTrack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.rlLockedTrack.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlLockedTrack.ForeColor = System.Drawing.Color.DimGray
        Me.rlLockedTrack.Location = New System.Drawing.Point(37, 23)
        Me.rlLockedTrack.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rlLockedTrack.Name = "rlLockedTrack"
        Me.rlLockedTrack.Size = New System.Drawing.Size(390, 32)
        Me.rlLockedTrack.TabIndex = 60
        '
        'Monitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.rlLockedTrack)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblStationName)
        Me.Controls.Add(Me.btnPlayedTracks)
        Me.Controls.Add(Me.btnDetectedTracks)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.dxvuCtrl)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(4000, 168)
        Me.MinimumSize = New System.Drawing.Size(546, 168)
        Me.Name = "Monitor"
        Me.Size = New System.Drawing.Size(546, 168)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents dxvuCtrl As NDXVUMeterNET.DXVUMeterNETGDI
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents lblStationName As System.Windows.Forms.Label
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents btnDetectedTracks As System.Windows.Forms.Button
    Friend WithEvents btnPlayedTracks As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ResultLabel1 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel5 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel4 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel3 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel2 As StationMonitor.ResultLabel
    Friend WithEvents rlLockedTrack As StationMonitor.ResultLabel

End Class

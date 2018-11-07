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
        Me.LblStationName = New System.Windows.Forms.Label()
        Me.BtnPlayedTracks = New System.Windows.Forms.Button()
        Me.BtnDetectedTracks = New System.Windows.Forms.Button()
        Me.BtnSettings = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ResultLabel5 = New StationMonitor.ResultLabel()
        Me.ResultLabel4 = New StationMonitor.ResultLabel()
        Me.ResultLabel3 = New StationMonitor.ResultLabel()
        Me.ResultLabel2 = New StationMonitor.ResultLabel()
        Me.ResultLabel1 = New StationMonitor.ResultLabel()
        Me.DxvuCtrl = New NDXVUMeterNET.DXVUMeterNETGDI()
        Me.RlLockedTrack = New StationMonitor.ResultLabel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStationName
        '
        Me.LblStationName.AutoSize = True
        Me.LblStationName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStationName.Location = New System.Drawing.Point(34, 6)
        Me.LblStationName.Name = "lblStationName"
        Me.LblStationName.Size = New System.Drawing.Size(92, 17)
        Me.LblStationName.TabIndex = 57
        Me.LblStationName.Text = "Station Name"
        Me.LblStationName.UseMnemonic = False
        '
        'btnPlayedTracks
        '
        Me.BtnPlayedTracks.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.BtnPlayedTracks.FlatAppearance.BorderSize = 0
        Me.BtnPlayedTracks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnPlayedTracks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnPlayedTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPlayedTracks.Image = Global.StationMonitor.My.Resources.Resources.PlayedTracksIcon
        Me.BtnPlayedTracks.Location = New System.Drawing.Point(3, 86)
        Me.BtnPlayedTracks.Name = "btnPlayedTracks"
        Me.BtnPlayedTracks.Size = New System.Drawing.Size(25, 21)
        Me.BtnPlayedTracks.TabIndex = 7
        Me.BtnPlayedTracks.UseVisualStyleBackColor = True
        '
        'btnDetectedTracks
        '
        Me.BtnDetectedTracks.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.BtnDetectedTracks.FlatAppearance.BorderSize = 0
        Me.BtnDetectedTracks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnDetectedTracks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnDetectedTracks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDetectedTracks.Image = CType(resources.GetObject("btnDetectedTracks.Image"), System.Drawing.Image)
        Me.BtnDetectedTracks.Location = New System.Drawing.Point(3, 59)
        Me.BtnDetectedTracks.Name = "btnDetectedTracks"
        Me.BtnDetectedTracks.Size = New System.Drawing.Size(25, 21)
        Me.BtnDetectedTracks.TabIndex = 7
        Me.BtnDetectedTracks.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.BtnSettings.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.BtnSettings.FlatAppearance.BorderSize = 0
        Me.BtnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSettings.Image = Global.StationMonitor.My.Resources.Resources.SettingsIcon
        Me.BtnSettings.Location = New System.Drawing.Point(3, 4)
        Me.BtnSettings.Name = "btnSettings"
        Me.BtnSettings.Size = New System.Drawing.Size(25, 21)
        Me.BtnSettings.TabIndex = 7
        Me.BtnSettings.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.BtnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStop.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.BtnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStop.Image = Global.StationMonitor.My.Resources.Resources.StopIcon
        Me.BtnStop.Location = New System.Drawing.Point(489, 23)
        Me.BtnStop.Name = "btnStop"
        Me.BtnStop.Size = New System.Drawing.Size(50, 32)
        Me.BtnStop.TabIndex = 7
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.BtnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStart.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.BtnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStart.Image = Global.StationMonitor.My.Resources.Resources.PlayIcon
        Me.BtnStart.Location = New System.Drawing.Point(433, 23)
        Me.BtnStart.Name = "btnStart"
        Me.BtnStart.Size = New System.Drawing.Size(50, 32)
        Me.BtnStart.TabIndex = 7
        Me.BtnStart.UseVisualStyleBackColor = True
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
        Me.DxvuCtrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DxvuCtrl.BackColor = System.Drawing.Color.Black
        Me.DxvuCtrl.BitDepth = CType(16, Short)
        Me.DxvuCtrl.Channels = CType(2, Short)
        Me.DxvuCtrl.EnableRendering = True
        Me.DxvuCtrl.FFTDetectDTMF = False
        Me.DxvuCtrl.FFTHighPrecisionMode = False
        Me.DxvuCtrl.FFTHistorySize = 4
        Me.DxvuCtrl.FFTHoldMaxPeaks = False
        Me.DxvuCtrl.FFTHoldMinPeaks = False
        Me.DxvuCtrl.FFTLineChannelMode = NDXVUMeterNET.DXVUMeterNETGDI.FFTLineChannelModeConstants.Normal
        Me.DxvuCtrl.FFTNormalized = True
        Me.DxvuCtrl.FFTPeaksDecayDelay = 10
        Me.DxvuCtrl.FFTPeaksDecaySpeed = 20
        Me.DxvuCtrl.FFTPlotNoiseReduction = 0
        Me.DxvuCtrl.FFTRenderScales = NDXVUMeterNET.DXVUMeterNETGDI.FFTRenderScalesConstants.None
        Me.DxvuCtrl.FFTScaleFont = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DxvuCtrl.FFTShowDecay = False
        Me.DxvuCtrl.FFTShowMinMaxRange = False
        Me.DxvuCtrl.FFTSize = NDXVUMeterNET.FFT.FFTSizeConstants.FFTs512
        Me.DxvuCtrl.FFTSmoothing = 0
        Me.DxvuCtrl.FFTStyle = NDXVUMeterNET.DXVUMeterNETGDI.FFTStyleConstants.Line
        Me.DxvuCtrl.FFTWindow = NDXVUMeterNET.FFT.FFTWindowConstants.None
        Me.DxvuCtrl.FFTXMax = 22050
        Me.DxvuCtrl.FFTXMin = 0
        Me.DxvuCtrl.FFTXScale = NDXVUMeterNET.DXVUMeterNETGDI.FFTXScaleConstants.Normal
        Me.DxvuCtrl.FFTXZoom = False
        Me.DxvuCtrl.FFTXZoomWindowPos = 0
        Me.DxvuCtrl.FFTYScale = NDXVUMeterNET.DXVUMeterNETGDI.FFTYScaleConstants.dB
        Me.DxvuCtrl.FFTYScaleMultiplier = 1.0R
        Me.DxvuCtrl.Frequency = 44100
        Me.DxvuCtrl.GreenOff = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DxvuCtrl.GreenOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DxvuCtrl.LeftChannelMute = False
        Me.DxvuCtrl.LinesThickness = 1
        Me.DxvuCtrl.Location = New System.Drawing.Point(237, 59)
        Me.DxvuCtrl.Name = "dxvuCtrl"
        Me.DxvuCtrl.NoiseFilter = 0
        Me.DxvuCtrl.NumVUs = CType(32, Short)
        Me.DxvuCtrl.Orientation = NDXVUMeterNET.DXVUMeterNETGDI.OrientationConstants.Horizontal
        Me.DxvuCtrl.Overlap = 0.0R
        Me.DxvuCtrl.PlaybackPosition = CType(0, Long)
        Me.DxvuCtrl.PlaybackTime = ""
        Me.DxvuCtrl.PlaybackVolume = CType(0, Short)
        Me.DxvuCtrl.RedOff = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DxvuCtrl.RedOn = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DxvuCtrl.RightChannelMute = False
        Me.DxvuCtrl.Size = New System.Drawing.Size(302, 102)
        Me.DxvuCtrl.Style = NDXVUMeterNET.DXVUMeterNETGDI.StyleConstants.FFT
        Me.DxvuCtrl.TabIndex = 56
        Me.DxvuCtrl.YellowOff = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DxvuCtrl.YellowOn = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'rlLockedTrack
        '
        Me.RlLockedTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RlLockedTrack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.RlLockedTrack.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RlLockedTrack.ForeColor = System.Drawing.Color.DimGray
        Me.RlLockedTrack.Location = New System.Drawing.Point(37, 23)
        Me.RlLockedTrack.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RlLockedTrack.Name = "rlLockedTrack"
        Me.RlLockedTrack.Size = New System.Drawing.Size(390, 32)
        Me.RlLockedTrack.TabIndex = 60
        '
        'Monitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RlLockedTrack)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LblStationName)
        Me.Controls.Add(Me.BtnPlayedTracks)
        Me.Controls.Add(Me.BtnDetectedTracks)
        Me.Controls.Add(Me.BtnSettings)
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.DxvuCtrl)
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
    Friend WithEvents BtnStart As Button
    Friend WithEvents DxvuCtrl As NDXVUMeterNET.DXVUMeterNETGDI
    Friend WithEvents BtnStop As Button
    Friend WithEvents LblStationName As Label
    Friend WithEvents BtnSettings As Button
    Friend WithEvents BtnDetectedTracks As Button
    Friend WithEvents BtnPlayedTracks As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ResultLabel1 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel5 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel4 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel3 As StationMonitor.ResultLabel
    Friend WithEvents ResultLabel2 As StationMonitor.ResultLabel
    Friend WithEvents RlLockedTrack As StationMonitor.ResultLabel

End Class

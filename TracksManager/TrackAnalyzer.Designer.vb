<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrackAnalyzer
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
        Me.lblCurTrackStatus = New System.Windows.Forms.Label()
        Me.pbCurrentTrack = New System.Windows.Forms.ProgressBar()
        Me.lblCurTrackProgress = New System.Windows.Forms.Label()
        Me.dxvuCtrl = New NDXVUMeterNET.DXVUMeterNETGDI()
        Me.SuspendLayout()
        '
        'lblCurTrackStatus
        '
        Me.lblCurTrackStatus.AutoSize = True
        Me.lblCurTrackStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurTrackStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurTrackStatus.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblCurTrackStatus.Location = New System.Drawing.Point(25, 18)
        Me.lblCurTrackStatus.Name = "lblCurTrackStatus"
        Me.lblCurTrackStatus.Size = New System.Drawing.Size(110, 13)
        Me.lblCurTrackStatus.TabIndex = 10
        Me.lblCurTrackStatus.Text = "Current Track Status"
        '
        'pbCurrentTrack
        '
        Me.pbCurrentTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCurrentTrack.Location = New System.Drawing.Point(28, 34)
        Me.pbCurrentTrack.Name = "pbCurrentTrack"
        Me.pbCurrentTrack.Size = New System.Drawing.Size(562, 13)
        Me.pbCurrentTrack.TabIndex = 8
        '
        'lblCurTrackProgress
        '
        Me.lblCurTrackProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurTrackProgress.AutoEllipsis = True
        Me.lblCurTrackProgress.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurTrackProgress.Location = New System.Drawing.Point(25, 3)
        Me.lblCurTrackProgress.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.lblCurTrackProgress.Name = "lblCurTrackProgress"
        Me.lblCurTrackProgress.Size = New System.Drawing.Size(565, 15)
        Me.lblCurTrackProgress.TabIndex = 9
        Me.lblCurTrackProgress.Text = "Current Track Progress"
        Me.lblCurTrackProgress.UseMnemonic = False
        '
        'dxvuCtrl
        '
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
        Me.dxvuCtrl.FFTScaleFont = New System.Drawing.Font("Tahoma", 8.0!)
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
        Me.dxvuCtrl.Location = New System.Drawing.Point(6, 6)
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
        Me.dxvuCtrl.Size = New System.Drawing.Size(13, 10)
        Me.dxvuCtrl.Style = NDXVUMeterNET.DXVUMeterNETGDI.StyleConstants.DigitalVU
        Me.dxvuCtrl.TabIndex = 11
        Me.dxvuCtrl.Text = "DxvuMeterNETGDI1"
        Me.dxvuCtrl.YellowOff = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dxvuCtrl.YellowOn = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'TrackAnalyzer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dxvuCtrl)
        Me.Controls.Add(Me.lblCurTrackStatus)
        Me.Controls.Add(Me.pbCurrentTrack)
        Me.Controls.Add(Me.lblCurTrackProgress)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TrackAnalyzer"
        Me.Size = New System.Drawing.Size(593, 52)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblCurTrackStatus As System.Windows.Forms.Label
    Private WithEvents pbCurrentTrack As System.Windows.Forms.ProgressBar
    Private WithEvents lblCurTrackProgress As System.Windows.Forms.Label
    Friend WithEvents dxvuCtrl As NDXVUMeterNET.DXVUMeterNETGDI

End Class

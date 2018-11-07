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
        Me.LblCurTrackStatus = New System.Windows.Forms.Label()
        Me.PbCurrentTrack = New System.Windows.Forms.ProgressBar()
        Me.LblCurTrackProgress = New System.Windows.Forms.Label()
        Me.DxvuCtrl = New NDXVUMeterNET.DXVUMeterNETGDI()
        Me.SuspendLayout()
        '
        'lblCurTrackStatus
        '
        Me.LblCurTrackStatus.AutoSize = True
        Me.LblCurTrackStatus.BackColor = System.Drawing.SystemColors.Control
        Me.LblCurTrackStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurTrackStatus.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LblCurTrackStatus.Location = New System.Drawing.Point(25, 18)
        Me.LblCurTrackStatus.Name = "lblCurTrackStatus"
        Me.LblCurTrackStatus.Size = New System.Drawing.Size(110, 13)
        Me.LblCurTrackStatus.TabIndex = 10
        Me.LblCurTrackStatus.Text = "Current Track Status"
        '
        'pbCurrentTrack
        '
        Me.PbCurrentTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PbCurrentTrack.Location = New System.Drawing.Point(28, 34)
        Me.PbCurrentTrack.Name = "pbCurrentTrack"
        Me.PbCurrentTrack.Size = New System.Drawing.Size(562, 13)
        Me.PbCurrentTrack.TabIndex = 8
        '
        'lblCurTrackProgress
        '
        Me.LblCurTrackProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCurTrackProgress.AutoEllipsis = True
        Me.LblCurTrackProgress.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurTrackProgress.Location = New System.Drawing.Point(25, 3)
        Me.LblCurTrackProgress.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LblCurTrackProgress.Name = "lblCurTrackProgress"
        Me.LblCurTrackProgress.Size = New System.Drawing.Size(565, 15)
        Me.LblCurTrackProgress.TabIndex = 9
        Me.LblCurTrackProgress.Text = "Current Track Progress"
        Me.LblCurTrackProgress.UseMnemonic = False
        '
        'dxvuCtrl
        '
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
        Me.DxvuCtrl.FFTRenderScales = NDXVUMeterNET.DXVUMeterNETGDI.FFTRenderScalesConstants.Both
        Me.DxvuCtrl.FFTScaleFont = New System.Drawing.Font("Tahoma", 8.0!)
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
        Me.DxvuCtrl.Location = New System.Drawing.Point(6, 6)
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
        Me.DxvuCtrl.Size = New System.Drawing.Size(13, 10)
        Me.DxvuCtrl.Style = NDXVUMeterNET.DXVUMeterNETGDI.StyleConstants.DigitalVU
        Me.DxvuCtrl.TabIndex = 11
        Me.DxvuCtrl.Text = "DxvuMeterNETGDI1"
        Me.DxvuCtrl.YellowOff = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DxvuCtrl.YellowOn = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'TrackAnalyzer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DxvuCtrl)
        Me.Controls.Add(Me.LblCurTrackStatus)
        Me.Controls.Add(Me.PbCurrentTrack)
        Me.Controls.Add(Me.LblCurTrackProgress)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TrackAnalyzer"
        Me.Size = New System.Drawing.Size(593, 52)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents LblCurTrackStatus As Label
    Private WithEvents PbCurrentTrack As ProgressBar
    Private WithEvents LblCurTrackProgress As Label
    Friend WithEvents DxvuCtrl As NDXVUMeterNET.DXVUMeterNETGDI

End Class

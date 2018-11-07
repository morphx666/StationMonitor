<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StationMonitorForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StationMonitorForm))
        Me.fpvDiff = New FPDataManager.FingerprintViewer()
        Me.fpvReference = New FPDataManager.FingerprintViewer()
        Me.fpvSampled = New FPDataManager.FingerprintViewer()
        Me.Monitor1 = New StationMonitor.Monitor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fpvDiff
        '
        Me.fpvDiff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fpvDiff.HashBands = 25
        Me.fpvDiff.Location = New System.Drawing.Point(763, 201)
        Me.fpvDiff.Mode = FPDataManager.FingerprintViewer.Modes.Hashes
        Me.fpvDiff.Name = "fpvDiff"
        Me.fpvDiff.ShowCursor = False
        Me.fpvDiff.ShowPlayStopButtons = False
        Me.fpvDiff.Size = New System.Drawing.Size(120, 270)
        Me.fpvDiff.TabIndex = 59
        '
        'fpvReference
        '
        Me.fpvReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fpvReference.HashBands = 25
        Me.fpvReference.Location = New System.Drawing.Point(511, 201)
        Me.fpvReference.Mode = FPDataManager.FingerprintViewer.Modes.Hashes
        Me.fpvReference.Name = "fpvReference"
        Me.fpvReference.ShowCursor = False
        Me.fpvReference.ShowPlayStopButtons = False
        Me.fpvReference.Size = New System.Drawing.Size(120, 270)
        Me.fpvReference.TabIndex = 58
        '
        'fpvSampled
        '
        Me.fpvSampled.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fpvSampled.HashBands = 25
        Me.fpvSampled.Location = New System.Drawing.Point(637, 201)
        Me.fpvSampled.Mode = FPDataManager.FingerprintViewer.Modes.Hashes
        Me.fpvSampled.Name = "fpvSampled"
        Me.fpvSampled.ShowCursor = False
        Me.fpvSampled.ShowPlayStopButtons = False
        Me.fpvSampled.Size = New System.Drawing.Size(120, 270)
        Me.fpvSampled.TabIndex = 58
        '
        'Monitor1
        '
        Me.Monitor1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Monitor1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Monitor1.Location = New System.Drawing.Point(13, 12)
        Me.Monitor1.MaximumSize = New System.Drawing.Size(4000, 168)
        Me.Monitor1.MinimumSize = New System.Drawing.Size(546, 168)
        Me.Monitor1.Name = "Monitor1"
        Me.Monitor1.SelectedStation = Nothing
        Me.Monitor1.Size = New System.Drawing.Size(869, 168)
        Me.Monitor1.TabIndex = 60
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(511, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Original"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(637, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Sampled"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(763, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Difference"
        '
        'StationMonitorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 483)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Monitor1)
        Me.Controls.Add(Me.fpvDiff)
        Me.Controls.Add(Me.fpvReference)
        Me.Controls.Add(Me.fpvSampled)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 200)
        Me.Name = "StationMonitorForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Station Monitor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fpvSampled As FPDataManager.FingerprintViewer
    Friend WithEvents fpvReference As FPDataManager.FingerprintViewer
    Friend WithEvents fpvDiff As FPDataManager.FingerprintViewer
    Friend WithEvents Monitor1 As StationMonitor.Monitor
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class

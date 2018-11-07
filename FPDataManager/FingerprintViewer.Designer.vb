<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FingerprintViewer
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
        Me.vsbOffset = New System.Windows.Forms.VScrollBar()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'vsbOffset
        '
        Me.vsbOffset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsbOffset.Location = New System.Drawing.Point(124, 21)
        Me.vsbOffset.Maximum = 10
        Me.vsbOffset.Name = "vsbOffset"
        Me.vsbOffset.Size = New System.Drawing.Size(17, 219)
        Me.vsbOffset.TabIndex = 0
        '
        'btnPlay
        '
        Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPlay.Location = New System.Drawing.Point(0, 276)
        Me.btnPlay.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(42, 23)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Location = New System.Drawing.Point(42, 276)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(0)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(42, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'FingerprintViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.vsbOffset)
        Me.Name = "FingerprintViewer"
        Me.Size = New System.Drawing.Size(161, 299)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents vsbOffset As System.Windows.Forms.VScrollBar
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button

End Class

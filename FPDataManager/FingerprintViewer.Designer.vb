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
        Me.VsbOffset = New System.Windows.Forms.VScrollBar()
        Me.BtnPlay = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'vsbOffset
        '
        Me.VsbOffset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VsbOffset.Location = New System.Drawing.Point(124, 21)
        Me.VsbOffset.Maximum = 10
        Me.VsbOffset.Name = "vsbOffset"
        Me.VsbOffset.Size = New System.Drawing.Size(17, 219)
        Me.VsbOffset.TabIndex = 0
        '
        'btnPlay
        '
        Me.BtnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnPlay.Location = New System.Drawing.Point(0, 276)
        Me.BtnPlay.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnPlay.Name = "btnPlay"
        Me.BtnPlay.Size = New System.Drawing.Size(42, 23)
        Me.BtnPlay.TabIndex = 1
        Me.BtnPlay.Text = "Play"
        Me.BtnPlay.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.BtnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnStop.Location = New System.Drawing.Point(42, 276)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnStop.Name = "btnStop"
        Me.BtnStop.Size = New System.Drawing.Size(42, 23)
        Me.BtnStop.TabIndex = 1
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'FingerprintViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtnStop)
        Me.Controls.Add(Me.BtnPlay)
        Me.Controls.Add(Me.VsbOffset)
        Me.Name = "FingerprintViewer"
        Me.Size = New System.Drawing.Size(161, 299)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VsbOffset As Windows.Forms.VScrollBar
    Friend WithEvents BtnPlay As Windows.Forms.Button
    Friend WithEvents BtnStop As Windows.Forms.Button
End Class

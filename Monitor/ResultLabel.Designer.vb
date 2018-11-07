<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultLabel
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
        Me.lblTrack = New System.Windows.Forms.Label()
        Me.lblPercentage = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTrack
        '
        Me.lblTrack.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTrack.AutoEllipsis = True
        Me.lblTrack.BackColor = System.Drawing.Color.Transparent
        Me.lblTrack.Location = New System.Drawing.Point(3, 0)
        Me.lblTrack.Name = "lblTrack"
        Me.lblTrack.Size = New System.Drawing.Size(513, 15)
        Me.lblTrack.TabIndex = 0
        Me.lblTrack.Text = "Artist - Title"
        Me.lblTrack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTrack.UseMnemonic = False
        '
        'lblPercentage
        '
        Me.lblPercentage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPercentage.AutoSize = True
        Me.lblPercentage.BackColor = System.Drawing.Color.Transparent
        Me.lblPercentage.Location = New System.Drawing.Point(522, 0)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(23, 15)
        Me.lblPercentage.TabIndex = 1
        Me.lblPercentage.Text = "0%"
        Me.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ResultLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.lblPercentage)
        Me.Controls.Add(Me.lblTrack)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ResultLabel"
        Me.Size = New System.Drawing.Size(548, 15)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTrack As System.Windows.Forms.Label
    Friend WithEvents lblPercentage As System.Windows.Forms.Label

End Class

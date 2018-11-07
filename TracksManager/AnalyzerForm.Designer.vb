<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnalyzerForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.lblGlobalProgress = New System.Windows.Forms.Label()
        Me.pbGlobalProgress = New System.Windows.Forms.ProgressBar()
        Me.lblEleapsed = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblGlobalProgress
        '
        Me.lblGlobalProgress.AutoSize = True
        Me.lblGlobalProgress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGlobalProgress.Location = New System.Drawing.Point(12, 9)
        Me.lblGlobalProgress.Name = "lblGlobalProgress"
        Me.lblGlobalProgress.Size = New System.Drawing.Size(98, 17)
        Me.lblGlobalProgress.TabIndex = 0
        Me.lblGlobalProgress.Text = "Global Process"
        '
        'pbGlobalProgress
        '
        Me.pbGlobalProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbGlobalProgress.Location = New System.Drawing.Point(15, 29)
        Me.pbGlobalProgress.Name = "pbGlobalProgress"
        Me.pbGlobalProgress.Size = New System.Drawing.Size(436, 19)
        Me.pbGlobalProgress.TabIndex = 1
        '
        'lblEleapsed
        '
        Me.lblEleapsed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEleapsed.AutoSize = True
        Me.lblEleapsed.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEleapsed.Location = New System.Drawing.Point(402, 9)
        Me.lblEleapsed.Name = "lblEleapsed"
        Me.lblEleapsed.Size = New System.Drawing.Size(49, 15)
        Me.lblEleapsed.TabIndex = 2
        Me.lblEleapsed.Text = "00:00:00"
        '
        'AnalyzerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 385)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblEleapsed)
        Me.Controls.Add(Me.pbGlobalProgress)
        Me.Controls.Add(Me.lblGlobalProgress)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "AnalyzerForm"
        Me.Text = "Analyzer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGlobalProgress As System.Windows.Forms.Label
    Friend WithEvents pbGlobalProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblEleapsed As System.Windows.Forms.Label
End Class

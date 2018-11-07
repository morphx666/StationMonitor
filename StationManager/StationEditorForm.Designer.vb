<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StationEditorForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtFrequency = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbCity = New System.Windows.Forms.ComboBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.TxtName.Location = New System.Drawing.Point(129, 14)
        Me.TxtName.Name = "txtName"
        Me.TxtName.Size = New System.Drawing.Size(220, 23)
        Me.TxtName.TabIndex = 1
        '
        'txtFrequency
        '
        Me.TxtFrequency.Location = New System.Drawing.Point(129, 44)
        Me.TxtFrequency.Name = "txtFrequency"
        Me.TxtFrequency.Size = New System.Drawing.Size(220, 23)
        Me.TxtFrequency.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Frequency"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City"
        '
        'cbCity
        '
        Me.CbCity.FormattingEnabled = True
        Me.CbCity.Location = New System.Drawing.Point(129, 74)
        Me.CbCity.Name = "cbCity"
        Me.CbCity.Size = New System.Drawing.Size(220, 23)
        Me.CbCity.Sorted = True
        Me.CbCity.TabIndex = 5
        '
        'btnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(168, 130)
        Me.BtnOK.Name = "btnOK"
        Me.BtnOK.Size = New System.Drawing.Size(87, 27)
        Me.BtnOK.TabIndex = 6
        Me.BtnOK.Text = "OK"
        Me.BtnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(262, 130)
        Me.BtnCancel.Name = "btnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(87, 27)
        Me.BtnCancel.TabIndex = 7
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'StationEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 171)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.CbCity)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtFrequency)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StationEditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Station Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtName As TextBox
    Friend WithEvents TxtFrequency As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CbCity As ComboBox
    Friend WithEvents BtnOK As Button
    Friend WithEvents BtnCancel As Button
End Class

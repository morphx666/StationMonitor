<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataEditorForm
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
        Me.EditorDataGridView = New System.Windows.Forms.DataGridView()
        Me.LblTableName = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        CType(Me.EditorDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EditorDataGridView
        '
        Me.EditorDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EditorDataGridView.Location = New System.Drawing.Point(14, 29)
        Me.EditorDataGridView.Name = "EditorDataGridView"
        Me.EditorDataGridView.Size = New System.Drawing.Size(358, 382)
        Me.EditorDataGridView.TabIndex = 0
        '
        'lblTableName
        '
        Me.LblTableName.AutoSize = True
        Me.LblTableName.Location = New System.Drawing.Point(14, 10)
        Me.LblTableName.Name = "lblTableName"
        Me.LblTableName.Size = New System.Drawing.Size(71, 15)
        Me.LblTableName.TabIndex = 1
        Me.LblTableName.Text = "Table Name"
        '
        'btnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Location = New System.Drawing.Point(284, 418)
        Me.BtnClose.Name = "btnClose"
        Me.BtnClose.Size = New System.Drawing.Size(87, 27)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'DataEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 456)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.LblTableName)
        Me.Controls.Add(Me.EditorDataGridView)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DataEditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Data Editor"
        CType(Me.EditorDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EditorDataGridView As DataGridView
    Friend WithEvents LblTableName As Label
    Friend WithEvents BtnClose As Button
End Class

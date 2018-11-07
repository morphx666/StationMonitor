<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.LvStations = New System.Windows.Forms.ListView()
        Me.StNameCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StFrequencyCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StCityCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvStations
        '
        Me.LvStations.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LvStations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.StNameCol, Me.StFrequencyCol, Me.StCityCol})
        Me.LvStations.FullRowSelect = True
        Me.LvStations.GridLines = True
        Me.LvStations.HideSelection = False
        Me.LvStations.Location = New System.Drawing.Point(14, 14)
        Me.LvStations.Name = "lvStations"
        Me.LvStations.Size = New System.Drawing.Size(700, 498)
        Me.LvStations.TabIndex = 0
        Me.LvStations.UseCompatibleStateImageBehavior = False
        Me.LvStations.View = System.Windows.Forms.View.Details
        '
        'stNameCol
        '
        Me.StNameCol.Text = "Name"
        '
        'stFrequencyCol
        '
        Me.StFrequencyCol.Text = "Frequency"
        Me.StFrequencyCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stCityCol
        '
        Me.StCityCol.Text = "City"
        '
        'btnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Location = New System.Drawing.Point(722, 14)
        Me.BtnAdd.Name = "btnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(87, 27)
        Me.BtnAdd.TabIndex = 1
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.BtnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEdit.Location = New System.Drawing.Point(722, 47)
        Me.BtnEdit.Name = "btnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(87, 27)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.BtnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelete.Location = New System.Drawing.Point(722, 81)
        Me.BtnDelete.Name = "btnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(87, 27)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 526)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.LvStations)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Station Manager"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LvStations As ListView
    Friend WithEvents StNameCol As ColumnHeader
    Friend WithEvents StFrequencyCol As ColumnHeader
    Friend WithEvents StCityCol As ColumnHeader
    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnDelete As Button
End Class

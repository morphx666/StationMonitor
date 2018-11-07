Imports FPDataManager

Public Class MainForm
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fpdata = New DataManager()
        LoadStations()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using frm = New StationEditorForm()
            frm.StationID = -1
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then LoadStations()
        End Using
    End Sub

    Private Sub LoadStations()
        Dim selID As Integer = -1
        If lvStations.SelectedItems.Count = 1 Then
            selID = CType(lvStations.SelectedItems(0).Tag, Station).ID
        End If

        lvStations.Items.Clear()

        For Each s In fpdata.Data.Stations
            Dim item As ListViewItem = lvStations.Items.Add(s.Name)
            With item
                .SubItems.Add(s.Frequency)
                .SubItems.Add(s.City.Name)
                .Tag = s
            End With

            If selID = s.ID Then
                item.Selected = True
                item.EnsureVisible()
            End If
        Next

        lvStations.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditStation()
    End Sub

    Private Sub EditStation()
        If lvStations.SelectedItems.Count = 0 Then Exit Sub

        Dim s = CType(lvStations.SelectedItems(0).Tag, Station)
        Using frm = New StationEditorForm()
            frm.StationID = s.ID
            frm.txtName.Text = s.Name
            frm.txtFrequency.Text = s.Frequency
            frm.LoadCities()
            frm.cbCity.SelectedItem = s.City
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then LoadStations()
        End Using
    End Sub

    Private Sub DeleteStation()
        If lvStations.SelectedItems.Count = 0 Then Exit Sub

        Dim s = CType(lvStations.SelectedItems(0).Tag, Station)
        If MsgBox("Are you sure you want to delete the '" + s.Name + "' station", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            fpdata.Data.Stations.DeleteObject(s)
            fpdata.Data.SaveChanges()
            LoadStations()
        End If
    End Sub

    Private Sub lvStations_DoubleClick(sender As Object, e As System.EventArgs) Handles lvStations.DoubleClick
        EditStation()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteStation()
    End Sub
End Class
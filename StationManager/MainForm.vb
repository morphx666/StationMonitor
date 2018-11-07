Imports FPDataManager

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fpdata = New DataManager()
        LoadStations()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Using frm = New StationEditorForm()
            frm.StationID = -1
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then LoadStations()
        End Using
    End Sub

    Private Sub LoadStations()
        Dim selID As Integer = -1
        If LvStations.SelectedItems.Count = 1 Then
            selID = CType(LvStations.SelectedItems(0).Tag, Station).ID
        End If

        LvStations.Items.Clear()

        For Each s In fpdata.Data.Stations
            Dim item As ListViewItem = LvStations.Items.Add(s.Name)
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

        LvStations.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        EditStation()
    End Sub

    Private Sub EditStation()
        If LvStations.SelectedItems.Count = 0 Then Exit Sub

        Dim s = CType(LvStations.SelectedItems(0).Tag, Station)
        Using frm = New StationEditorForm()
            frm.StationID = s.ID
            frm.TxtName.Text = s.Name
            frm.TxtFrequency.Text = s.Frequency
            frm.LoadCities()
            frm.CbCity.SelectedItem = s.City
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then LoadStations()
        End Using
    End Sub

    Private Sub DeleteStation()
        If LvStations.SelectedItems.Count = 0 Then Exit Sub

        Dim s = CType(LvStations.SelectedItems(0).Tag, Station)
        If MsgBox("Are you sure you want to delete the '" + s.Name + "' station", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            fpdata.Data.Stations.DeleteObject(s)
            fpdata.Data.SaveChanges()
            LoadStations()
        End If
    End Sub

    Private Sub LvStations_DoubleClick(sender As Object, e As EventArgs) Handles LvStations.DoubleClick
        EditStation()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        DeleteStation()
    End Sub
End Class
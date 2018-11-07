Imports FPDataManager

Public Class StationEditorForm
    Public Property StationID As Integer = -1

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim editStation = If(StationID = -1, New Station(), (From s In fpdata.Data.Stations Where s.ID = StationID Select s).Single())

        editStation.Name = TxtName.Text
        editStation.Frequency = TxtFrequency.Text
        editStation.CityID = GetSelectedCity()

        If StationID = -1 Then fpdata.Data.Stations.AddObject(editStation)

        fpdata.Data.SaveChanges()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Function GetSelectedCity() As Integer
        If CbCity.SelectedValue Is Nothing Then
            Dim newCity As City = New City With {.Name = CbCity.Text}
            fpdata.Data.Cities.AddObject(newCity)
            fpdata.Data.SaveChanges()
            Return newCity.ID
        Else
            Return CbCity.SelectedValue
        End If
    End Function

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub StationEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCities()
    End Sub

    Friend Sub LoadCities()
        If CbCity.Items.Count > 0 Then Exit Sub
        Dim cities = New AutoCompleteStringCollection()

        CbCity.DataSource = fpdata.Data.Cities
        CbCity.DisplayMember = "name"
        CbCity.ValueMember = "id"

        For Each s In fpdata.Data.Cities
            cities.Add(s.Name)
        Next

        CbCity.AutoCompleteCustomSource = cities
        CbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CbCity.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
End Class
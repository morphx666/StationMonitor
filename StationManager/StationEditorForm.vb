Imports FPDataManager

Public Class StationEditorForm
    Public Property StationID As Integer = -1

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim editStation As Station
        If StationID = -1 Then
            editStation = New Station()
        Else
            editStation = (From s In fpdata.Data.Stations Where s.ID = StationID Select s).Single()
        End If

        editStation.Name = txtName.Text
        editStation.Frequency = txtFrequency.Text
        editStation.CityID = GetSelectedCity()

        If StationID = -1 Then fpdata.Data.Stations.AddObject(editStation)

        fpdata.Data.SaveChanges()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Function GetSelectedCity() As Integer
        If cbCity.SelectedValue Is Nothing Then
            Dim newCity As City = New City()
            newCity.Name = cbCity.Text
            fpdata.Data.Cities.AddObject(newCity)
            fpdata.Data.SaveChanges()
            Return newCity.ID
        Else
            Return cbCity.SelectedValue
        End If
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub StationEditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCities()
    End Sub

    Friend Sub LoadCities()
        If cbCity.Items.Count > 0 Then Exit Sub
        Dim cities = New AutoCompleteStringCollection()

        cbCity.DataSource = fpdata.Data.cities
        cbCity.DisplayMember = "name"
        cbCity.ValueMember = "id"

        For Each s In fpdata.Data.cities
            cities.Add(s.name)
        Next

        cbCity.AutoCompleteCustomSource = cities
        cbCity.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cbCity.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
End Class
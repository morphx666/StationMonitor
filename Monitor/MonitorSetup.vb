Imports FPDataManager
Imports NDXVUMeterNET.DXVUMeterNETGDI

Public Class MonitorSetup
    Private mOwner As Monitor

    Private selLine As DevicesCollection.Device.RecordingSourcesCollection2.Line

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(owner As Monitor)
        Me.New()
        mOwner = owner
    End Sub

    Public Sub Initialize()
        For Each s In mOwner.DataManager.Data.Stations
            cbStation.Items.Add(s.Name)
        Next

        If cbStation.Items.Count > 0 Then
            cbStation.SelectedIndex = 0

            For Each d As DevicesCollection.Device In mOwner.Devices
                Dim i = cbDevices.Items.Add(d)
                If d.Selected Then cbDevices.SelectedIndex = i
            Next
            If cbDevices.SelectedIndex = -1 Then cbDevices.SelectedIndex = 0
        Else
            For Each ctrl As Control In Me.Controls
                If ctrl.Name <> btnCancel.Name Then ctrl.Enabled = False
            Next
        End If
    End Sub

    Private Sub cbStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStation.SelectedIndexChanged
        Dim selStationName = cbStation.SelectedItem.ToString()
        mOwner.SelectedStation = mOwner.DataManager.Data.Stations.Where(Function(s) s.Name = selStationName).First()
        tbSamplingTime.Value = mOwner.SelectedStation.SamplingTime
    End Sub

    Private Sub ChannelMute_CheckedChanged(sender As Object, e As EventArgs) Handles rbLeft.CheckedChanged, rbRight.CheckedChanged
        If mOwner IsNot Nothing Then
            mOwner.SelectedStation.LeftChMute = Not rbLeft.Checked
            mOwner.SelectedStation.RightChMute = Not rbRight.Checked
        End If
    End Sub

    Private Sub cmbChannelMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbChannelMode.SelectedIndexChanged
        If cbChannelMode.SelectedIndex = 0 Then
            rbLeft.Enabled = False
            rbRight.Enabled = False

            mOwner.SelectedStation.ChannelMode = 1
        Else
            rbLeft.Enabled = True
            rbRight.Enabled = True

            mOwner.SelectedStation.ChannelMode = 2
        End If
    End Sub

    Private Sub tbSamplingTime_ValueChanged(sender As Object, e As System.EventArgs) Handles tbSamplingTime.ValueChanged
        If mOwner IsNot Nothing Then mOwner.SelectedStation.SamplingTime = tbSamplingTime.Value
    End Sub

    Private Sub cbDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDevices.SelectedIndexChanged
        Dim selDevice As DevicesCollection.Device = CType(cbDevices.SelectedItem, DevicesCollection.Device)
        mOwner.SelectedStation.RecordingDevice = selDevice.GUID.ToString()

        cbSources.Items.Clear()
        For Each srcLine As DevicesCollection.Device.RecordingSourcesCollection2.Line In selDevice.RecordingSources2
            cbSources.Items.Add(srcLine)
        Next
        If cbSources.SelectedIndex = -1 AndAlso cbSources.Items.Count > 0 Then cbSources.SelectedIndex = 0

        cbChannelMode.SelectedIndex = 0
    End Sub

    Private Sub cmbSources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSources.SelectedIndexChanged
        Dim srcLine As DevicesCollection.Device.RecordingSourcesCollection2.Line = CType(cbSources.SelectedItem, DevicesCollection.Device.RecordingSourcesCollection2.Line)

        SelectRecordingSource(srcLine)
    End Sub

    Private Sub SelectRecordingSource(srcLine As DevicesCollection.Device.RecordingSourcesCollection2.Line)
        If selLine IsNot Nothing Then selLine.RemoveBingings()

        With srcLine
            If .HasVolume Then
                Try
                    tbVolume.CoreAudioControl = srcLine.CoreAudioLine.Parent.Line.Controls(0)
                    tbVolume.Enabled = True
                    tbVolume.IntegralChanges = False
                Catch
                    tbVolume.Enabled = False
                End Try
            Else
                tbVolume.Enabled = False
            End If
        End With

        selLine = srcLine
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub MonitorSetup_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tbVolume.CoreAudioControl = Nothing
    End Sub

    Private Sub MonitorSetup_Load(sender As Object, e As EventArgs) Handles Me.Load
        If mOwner IsNot Nothing Then Initialize()
    End Sub
End Class
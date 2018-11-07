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
            CbStation.Items.Add(s.Name)
        Next

        If CbStation.Items.Count > 0 Then
            CbStation.SelectedIndex = 0

            For Each d As DevicesCollection.Device In mOwner.Devices
                Dim i = CbDevices.Items.Add(d)
                If d.Selected Then CbDevices.SelectedIndex = i
            Next
            If CbDevices.SelectedIndex = -1 Then CbDevices.SelectedIndex = 0
        Else
            For Each ctrl As Control In Me.Controls
                If ctrl.Name <> BtnCancel.Name Then ctrl.Enabled = False
            Next
        End If
    End Sub

    Private Sub CbStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbStation.SelectedIndexChanged
        Dim selStationName = CbStation.SelectedItem.ToString()
        mOwner.SelectedStation = mOwner.DataManager.Data.Stations.Where(Function(s) s.Name = selStationName).First()
        TbSamplingTime.Value = mOwner.SelectedStation.SamplingTime
    End Sub

    Private Sub ChannelMute_CheckedChanged(sender As Object, e As EventArgs) Handles RbLeft.CheckedChanged, RbRight.CheckedChanged
        If mOwner IsNot Nothing Then
            mOwner.SelectedStation.LeftChMute = Not RbLeft.Checked
            mOwner.SelectedStation.RightChMute = Not RbRight.Checked
        End If
    End Sub

    Private Sub CmbChannelMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbChannelMode.SelectedIndexChanged
        If CbChannelMode.SelectedIndex = 0 Then
            RbLeft.Enabled = False
            RbRight.Enabled = False

            mOwner.SelectedStation.ChannelMode = 1
        Else
            RbLeft.Enabled = True
            RbRight.Enabled = True

            mOwner.SelectedStation.ChannelMode = 2
        End If
    End Sub

    Private Sub TbSamplingTime_ValueChanged(sender As Object, e As EventArgs) Handles TbSamplingTime.ValueChanged
        If mOwner IsNot Nothing Then mOwner.SelectedStation.SamplingTime = TbSamplingTime.Value
    End Sub

    Private Sub CbDevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbDevices.SelectedIndexChanged
        Dim selDevice As DevicesCollection.Device = CType(CbDevices.SelectedItem, DevicesCollection.Device)
        mOwner.SelectedStation.RecordingDevice = selDevice.GUID.ToString()

        CbSources.Items.Clear()
        For Each srcLine As DevicesCollection.Device.RecordingSourcesCollection2.Line In selDevice.RecordingSources2
            CbSources.Items.Add(srcLine)
        Next
        If CbSources.SelectedIndex = -1 AndAlso CbSources.Items.Count > 0 Then CbSources.SelectedIndex = 0

        CbChannelMode.SelectedIndex = 0
    End Sub

    Private Sub CmbSources_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbSources.SelectedIndexChanged
        Dim srcLine As DevicesCollection.Device.RecordingSourcesCollection2.Line = CType(CbSources.SelectedItem, DevicesCollection.Device.RecordingSourcesCollection2.Line)

        SelectRecordingSource(srcLine)
    End Sub

    Private Sub SelectRecordingSource(srcLine As DevicesCollection.Device.RecordingSourcesCollection2.Line)
        If selLine IsNot Nothing Then selLine.RemoveBingings()

        With srcLine
            If .HasVolume Then
                Try
                    TbVolume.CoreAudioControl = srcLine.CoreAudioLine.Parent.Line.Controls(0)
                    TbVolume.Enabled = True
                    TbVolume.IntegralChanges = False
                Catch
                    TbVolume.Enabled = False
                End Try
            Else
                TbVolume.Enabled = False
            End If
        End With

        selLine = srcLine
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub MonitorSetup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        TbVolume.CoreAudioControl = Nothing
    End Sub

    Private Sub MonitorSetup_Load(sender As Object, e As EventArgs) Handles Me.Load
        If mOwner IsNot Nothing Then Initialize()
    End Sub
End Class
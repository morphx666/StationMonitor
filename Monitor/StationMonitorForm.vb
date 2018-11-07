' http://research.microsoft.com/en-us/um/people/cburges/rare.htm

Public Class StationMonitorForm
    Private Sub StationMonitorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Monitor1.SetFingerPrintViewers(fpvSampled, fpvReference, fpvDiff)
    End Sub
End Class
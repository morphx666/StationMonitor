Imports NDXVUMeterNET.DXVUMeterNETGDI
Imports System.Threading
Imports FPDataManager

Public Class Monitor
    Private Enum ListModes
        PlayedTracks
        DetectedTracks
    End Enum

    Private mFPVLive As FingerprintViewer
    Private mFPVRefference As FingerprintViewer
    Private mFPVDifference As FingerprintViewer
    Private fpvsSet As Boolean

    Private fpData As DataManager
    Private hashDataLib As HashLib

    Private sampledFingerPrintLength As Integer
    Private results As New List(Of Result)
    Private bestMatches As New List(Of SimilarHash)

    Private tmrAutoStop As Timer

    Private lockedResult As Result = Nothing
    Private swTimer As Stopwatch = New Stopwatch()
    Private lastError As String
    Private mSelectedStation As Station

    Private continiousMonitorThread As Thread
    Private continiousMonitorWaiter As AutoResetEvent
    Private samplingTime As Integer

    Private mode As ListModes = ListModes.DetectedTracks
    Private resultLabels(5 - 1) As ResultLabel

    Private Sub Monitor_HandleCreated(sender As Object, e As System.EventArgs) Handles Me.HandleCreated
        btnSettings.Enabled = False
        If Me.FindForm IsNot Nothing Then AddHandler CType(Me.FindForm, Form).FormClosing, Sub()
                                                                                               fpData.Data.SaveChanges()
                                                                                               dxvuCtrl.StopMonitoring()
                                                                                           End Sub
    End Sub

    Private Sub Monitor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        btnDetectedTracks.Enabled = False
        btnPlayedTracks.Enabled = False

        If Not Me.DesignMode Then
            fpData = New DataManager()
            hashDataLib = New HashLib(dxvuCtrl)

            fpData.Data.Refresh(Data.Objects.RefreshMode.StoreWins, fpData.Data.Tracks)

            resultLabels(0) = ResultLabel1
            resultLabels(1) = ResultLabel2
            resultLabels(2) = ResultLabel3
            resultLabels(3) = ResultLabel4
            resultLabels(4) = ResultLabel5

            Initialize()
        End If
    End Sub

    Public Sub SetFingerPrintViewers(live As FingerprintViewer, reference As FingerprintViewer, difference As FingerprintViewer)
        mFPVLive = live
        mFPVRefference = reference
        mFPVDifference = difference

        If mFPVLive IsNot Nothing Then mFPVLive.HashBands = hashDataLib.NumOfFFTBands
        If mFPVRefference IsNot Nothing Then mFPVRefference.HashBands = hashDataLib.NumOfFFTBands
        If mFPVDifference IsNot Nothing Then mFPVDifference.HashBands = hashDataLib.NumOfFFTBands

        fpvsSet = Not (live Is Nothing OrElse reference Is Nothing OrElse difference Is Nothing)
    End Sub

    Private Sub DXVUMeterNET_IsReady() Handles dxvuCtrl.ControlIsReady
        btnSettings.Enabled = True
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Using ms As New MonitorSetup(Me)
            If ms.ShowDialog(Me) = DialogResult.OK Then Initialize()
        End Using
    End Sub

    Private Sub btnDetectedTracks_Click(sender As Object, e As EventArgs) Handles btnDetectedTracks.Click
        mode = ListModes.DetectedTracks
    End Sub

    Private Sub btnPlayedTracks_Click(sender As Object, e As EventArgs) Handles btnPlayedTracks.Click
        mode = ListModes.PlayedTracks
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        StartMonitoring()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopMonitoring()
    End Sub

    Private Sub StartMonitoring()
        btnSettings.Enabled = False
        btnStart.Enabled = False
        btnStop.Enabled = True

        lockedResult = New Result()

        dxvuCtrl.StartMonitoring()

        continiousMonitorWaiter = New AutoResetEvent(False)

        continiousMonitorThread = New Thread(AddressOf ContiniousMonitorSub)
        continiousMonitorThread.IsBackground = True
        continiousMonitorThread.Start()
    End Sub

    Private Sub StopMonitoring()
        If continiousMonitorThread IsNot Nothing Then
            continiousMonitorThread.Abort()
            continiousMonitorThread = Nothing
        End If

        swTimer.Stop()
        dxvuCtrl.StopMonitoring()

        btnSettings.Enabled = True
        btnStart.Enabled = True
        btnStop.Enabled = False
    End Sub

    Private Sub ContiniousMonitorSub()
        Do
            hashDataLib.Reset()

            hashDataLib.AnalyzeFFTFrames = True
            continiousMonitorWaiter.WaitOne(samplingTime)
            hashDataLib.AnalyzeFFTFrames = False

            swTimer.Restart()
            AnalyzeSampledAudio()
            swTimer.Stop()

            Debug.WriteLine(swTimer.Elapsed.ToString())
            Debug.WriteLine("")

            continiousMonitorWaiter.WaitOne(100)

            Me.Invoke(New MethodInvoker(Sub()
                                            Try
                                                AnalyzeResults()
                                            Catch
                                            End Try
                                        End Sub))
        Loop
    End Sub

    Private Sub AnalyzeSampledAudio()
        lastError = ""

        Try
            hashDataLib.ComputeHashes(1)
            sampledFingerPrintLength = hashDataLib.Hashes.Length
            If sampledFingerPrintLength < samplingTime / 200 Then Exit Sub

            errorMax = (sampledFingerPrintLength * hashDataLib.NumOfFFTBands) - 1
            errorThresholdMax = errorMax * 0.3     ' 30% error 70% match
            errorThresholdMid = errorMax * 0.25    ' 25% error 75% match
            errorThresholdMin = errorMax * 0.2     ' 20% error 80% match

            results.Clear()

            Dim result As Result
            If lockedResult.IsSet Then
                result = CompareSampledHashesToTrack(lockedResult.Hashes, lockedResult.MatchHashIndex)
                lockedResult.ErrorLevel = result.ErrorLevel

                If result.ErrorLevel <= errorThresholdMid Then
                    lockedResult.MatchHashIndex = result.MatchHashIndex
                    results.Add(lockedResult)

                    If lockedResult.ErrorCount = 0 AndAlso result.ErrorLevel <= errorThresholdMin Then
                        Debug.WriteLine("Using Locked Track")
                        Exit Sub
                    End If
                End If
            End If

            Dim maxImportantHashesTolerance As Integer = MaxTolerance
            'Dim timeDifs As New List(Of Double)

            'For i = 0 To hashDataLib.ImportantHashes.Count - 2
            '    timeDifs.Add(hashDataLib.ImportantHashes(i + 1).Position - hashDataLib.ImportantHashes(i).Position)
            'Next

            For i = 0 To hashDataLib.ImportantHashes.Count - 1
                Dim similarHashes As List(Of SimilarHash) = fpData.Data.FindSimilarHashes(hashDataLib.ImportantHashes(i).HashValue,
                                                                                          maxImportantHashesTolerance).ToList()


                For Each sh In similarHashes
                    Dim idx As Integer = bestMatches.IndexOf(sh)
                    If idx >= 0 Then
                        If bestMatches(idx).Position < sh.Position Then bestMatches(idx).Hits += 1
                    Else
                        bestMatches.Add(sh)
                    End If
                Next
            Next
            bestMatches = (From bm In bestMatches Select bm Where bm.Hits >= sampledFingerPrintLength / 8 Order By bm.ErrorLevel, bm.Hits Ascending).ToList()
            Debug.WriteLine("BestMatches: {0}", bestMatches.Count)

            Dim isDone As Boolean
            Dim testTrackID As Integer
            Dim hashes() As HashLib.Hash
            Dim testTrack As Track
            For Each bestMatch In bestMatches.Take(10)
                testTrackID = bestMatch.TrackID
                testTrack = fpData.Data.Tracks.Where(Function(t) t.ID = testTrackID).Single()

                hashes = testTrack.Fingerprints.Select(Function(f) New HashLib.Hash(f)).ToArray()
                result = CompareSampledHashesToTrack(hashes, 0)

                If result.ErrorLevel <= errorThresholdMax Then
                    Debug.WriteLine(" > {0}: {1:F2} [{2}]", testTrack.Title, result.ErrorLevel, bestMatch.Hits)

                    result.Track = testTrack
                    If (lockedResult.IsSet AndAlso result <> lockedResult) OrElse Not lockedResult.IsSet Then
                        result.Hashes = hashes
                        results.Add(result)

                        If result.ErrorLevel <= errorThresholdMin Then
                            isDone = True
                        End If
                    End If
                Else
                    bestMatch.ErrorLevel = MaxTolerance
                End If

                If isDone Then Exit For
                'If bestMatches(i).Count > 0 Then Exit For
            Next
            Debug.WriteLine("Results: {0}", results.Count)

            bestMatches.ForEach(Sub(bm) bm.Hits -= 1)
            bestMatches.RemoveAll(Function(bm) bm.Hits <= 0)
        Catch ex As Exception
            lastError = ex.Message + vbCrLf + vbCrLf + ex.StackTrace
            If ex.InnerException IsNot Nothing Then
                lastError += (vbCrLf + vbCrLf + "Inner Exception: " + vbCrLf + ex.InnerException.Message)
            End If
        End Try
    End Sub

    Private Function CompareSampledHashesToTrack(refHashes() As HashLib.Hash, startIndex As Integer) As Result
        Dim result = New Result()
        Dim distance As Integer

        startIndex -= startIndex / 4

        For refHashIndex As Integer = startIndex To refHashes.Length - sampledFingerPrintLength - 1
            distance = 0

            For sampledHashIndex As Integer = 0 To sampledFingerPrintLength - 1
                ' MFCC
                'distance += MFCC.EuclideanDistance(refHashes(refHashIndex + sampledHashIndex).CeptralCoeficients, hashDataLib.Hashes(sampledHashIndex).CeptralCoeficients)

                ' FP
                distance += HashLib.HammingDistance(refHashes(refHashIndex + sampledHashIndex).HashValue, hashDataLib.Hashes(sampledHashIndex).HashValue)
                If distance > errorThresholdMax Then Exit For
            Next

            With result
                If distance <= errorThresholdMax AndAlso distance < .ErrorLevel Then
                    .ErrorLevel = distance
                    .MatchHashIndex = refHashIndex

                    If distance <= errorThresholdMin Then Exit For
                End If
            End With
        Next

        Return result
    End Function

    Private Sub AnalyzeResults()
        If sampledFingerPrintLength <= 5 Then
            rlLockedTrack.CustomText = "No Audio Detected"
            mFPVLive.Hashes = {}
            mFPVRefference.Hashes = {}
            mFPVDifference.Hashes = {}

            lockedResult.UnSet()
            bestMatches.Clear()
            Exit Sub
        End If

        If results.Count > 0 Then
            Dim sortedResults = results.OrderBy(Function(r) r.ErrorLevel)
            Dim firstResult As Result = sortedResults.First()

            If mode = ListModes.DetectedTracks Then
                Dim startIndex As Integer = If(lockedResult.IsSet AndAlso lockedResult = firstResult, 1, 0)
                Dim j As Integer = 0

                For i = 0 To resultLabels.Length - 1
                    If i < startIndex Then Continue For

                    If i < sortedResults.Count Then
                        resultLabels(j).Result = sortedResults(i)
                    Else
                        resultLabels(j).CustomText = " "
                    End If
                    j += 1
                Next
                If startIndex = 1 Then resultLabels(j).CustomText = " "
            End If

            If lockedResult.IsSet Then
                If lockedResult.ErrorLevel > errorThresholdMax OrElse (firstResult.ErrorLevel <= lockedResult.ErrorLevel AndAlso firstResult <> lockedResult) Then
                    lockedResult.ErrorCount += 1

                    If lockedResult.ErrorCount > 3 Then
                        If firstResult.ErrorLevel <= lockedResult.ErrorLevel AndAlso firstResult.ErrorLevel <= errorThresholdMid Then
                            lockedResult = firstResult
                        Else
                            lockedResult.UnSet()
                        End If
                    End If
                ElseIf lockedResult.ErrorCount > 0 Then
                    lockedResult.ErrorCount -= 1
                End If
            ElseIf firstResult.ErrorLevel <= errorThresholdMid OrElse firstResult.ErrorLevel <= errorThresholdMin Then
                lockedResult = firstResult
            End If
        Else
            If lockedResult.IsSet Then
                If lockedResult.ErrorLevel > errorThresholdMax Then
                    lockedResult.ErrorCount += 1

                    If lockedResult.ErrorCount > 3 Then lockedResult.UnSet()
                ElseIf lockedResult.ErrorCount > 0 Then
                    lockedResult.ErrorCount -= 1
                End If
            End If

            For i = 0 To resultLabels.Length - 1
                resultLabels(i).CustomText = " "
            Next
        End If

        If lockedResult.IsSet Then
            rlLockedTrack.Result = lockedResult
            rlLockedTrack.Position = lockedResult.MatchHashIndex / lockedResult.Hashes.Length
        Else
            rlLockedTrack.Result = Nothing
        End If

        If fpvsSet Then
            mFPVLive.Hashes = hashDataLib.Hashes

            If lockedResult.IsSet Then
                mFPVRefference.Track = lockedResult.Track
                mFPVRefference.SelectedHash = lockedResult.MatchHashIndex

                Dim dh(sampledFingerPrintLength - 1) As HashLib.Hash
                For i As Integer = 0 To sampledFingerPrintLength - 1
                    dh(i) = New HashLib.Hash(lockedResult.Hashes(i + lockedResult.MatchHashIndex).HashValue Xor hashDataLib.Hashes(i).HashValue, 0)
                Next
                mFPVDifference.Hashes = dh
            Else
                mFPVRefference.Track = Nothing
                mFPVDifference.Hashes = {}
            End If
        End If

        UpdatePlayedTracksDB()
    End Sub

    Private Sub UpdatePlayedTracksDB()
        Dim cleanUpPlayedTracks As Boolean = False
        Dim newPlayedTrack As tmpPlayedTrack = New tmpPlayedTrack()

        If lockedResult.IsSet Then
            newPlayedTrack.TrackID = lockedResult.Track.ID
        Else
            newPlayedTrack.TrackID = New Integer?()
        End If
        newPlayedTrack.StationID = mSelectedStation.ID
        newPlayedTrack.StartTime = Now
        newPlayedTrack.EndTime = Now
        newPlayedTrack.Score = If(lockedResult.IsSet, lockedResult.ErrorLevel, Integer.MaxValue)

        If fpData.Data.tmpPlayedTracks.Count = 0 Then
            fpData.Data.tmpPlayedTracks.AddObject(newPlayedTrack)
            cleanUpPlayedTracks = True
        Else
            Dim lastTrack = fpData.Data.tmpPlayedTracks.AsEnumerable().Last()
            If lastTrack.TrackID = lockedResult.TrackID Then
                With lastTrack
                    If lockedResult.IsSet Then
                        .Score = Math.Min(.Score, lockedResult.ErrorLevel)
                    Else
                        ' FIXME: This cannot happen?
                        .TrackID = New Integer?()
                    End If
                    .EndTime = Now
                    .Duration = (.EndTime - .StartTime).TotalSeconds
                End With
            Else
                fpData.Data.tmpPlayedTracks.AddObject(newPlayedTrack)
                cleanUpPlayedTracks = True
            End If
        End If

        If fpData.Data.tmpPlayedTracks.Count > 5 Then
            Dim firstTrack = fpData.Data.tmpPlayedTracks.First()
            Dim newTrack As New PlayedTrack()
            newTrack.EndTime = firstTrack.EndTime
            newTrack.StartTime = firstTrack.StartTime
            newTrack.StationID = firstTrack.StationID
            newTrack.TrackID = firstTrack.TrackID
            fpData.Data.AddToPlayedTracks(newTrack)
            fpData.Data.DeleteObject(firstTrack)
            cleanUpPlayedTracks = True
        End If

        If cleanUpPlayedTracks Then
            If fpData.SaveAndRenewContext() Then mSelectedStation = fpData.Data.Stations.Where(Function(s) s.ID = mSelectedStation.ID).Single()

            Dim isDone As Boolean
            Do
                isDone = True

                Dim playedTracks = fpData.Data.tmpPlayedTracks.AsEnumerable()

                For i As Integer = 0 To playedTracks.Count - 2
                    If (Not playedTracks(i).TrackID.HasValue AndAlso playedTracks(i).Duration < 45) OrElse
                        (playedTracks(i).TrackID.HasValue AndAlso playedTracks(i).Duration < 120) Then
                        playedTracks(i + 1).StartTime = playedTracks(i).StartTime
                        fpData.Data.tmpPlayedTracks.DeleteObject(playedTracks(i))
                        isDone = False
                        Exit For
                    End If

                    If playedTracks(i).TrackID.Equals(playedTracks(i + 1).TrackID) Then
                        playedTracks(i).EndTime = playedTracks(i + 1).EndTime
                        fpData.Data.tmpPlayedTracks.DeleteObject(playedTracks(i + 1))
                        isDone = False
                        Exit For
                    End If

                    If i <= playedTracks.Count - 3 AndAlso playedTracks(i).TrackID.Equals(playedTracks(i + 2).TrackID) AndAlso playedTracks(i + 1).Duration < 60 Then
                        fpData.Data.tmpPlayedTracks.DeleteObject(playedTracks(i + 1))
                        isDone = False
                        Exit For
                    End If
                Next

                If Not isDone Then fpData.Data.SaveChanges()
            Loop Until isDone
        End If

        'tbResults.Text += vbCrLf + vbCrLf + "Played Tracks:" + vbCrLf
        'For Each pt In (From p In fpData.Data.tmpPlayedTracks Order By p.id Descending Take 10 Select p).AsEnumerable().Reverse()
        '    tbResults.Text += PlayedTrackToString(pt)
        'Next
    End Sub

    Private Function PlayedTrackToString(playedTrack As tmpPlayedTrack) As String
        Dim fileName As String
        If playedTrack.TrackID.HasValue Then
            fileName = playedTrack.Track.Artist.Name + " - " + playedTrack.Track.Title
        Else
            If playedTrack.Duration < 6 * 60 Then
                fileName = "Unknown Track"
            Else
                fileName = "Commercial Block?"
            End If
        End If

        Dim duration = playedTrack.EndTime - playedTrack.StartTime
        Return String.Format("{1:d2}:{2:d2}:{3:d2} -> {4:d2}:{5:d2}:{6:d2} [{7:d2}m {8:d2}s]: {0}", fileName, playedTrack.StartTime.Hour,
                                                                                        playedTrack.StartTime.Minute,
                                                                                        playedTrack.StartTime.Second,
                                                                                        playedTrack.EndTime.Hour,
                                                                                        playedTrack.EndTime.Minute,
                                                                                        playedTrack.EndTime.Second,
                                                                                        CInt(Math.Floor(duration.TotalMinutes)),
                                                                                        CInt(Math.Floor(duration.TotalSeconds - Math.Floor(duration.TotalMinutes) * 60))) + vbCrLf
    End Function

    Public ReadOnly Property DataManager As DataManager
        Get
            Return fpData
        End Get
    End Property

    Private ReadOnly Property MaxTolerance As Integer
        Get
            Return Math.Ceiling(hashDataLib.NumOfFFTBands * 0.05)
        End Get
    End Property

    Public Property SelectedStation As Station
        Get
            Return mSelectedStation
        End Get
        Set(value As Station)
            mSelectedStation = value
        End Set
    End Property

    Public ReadOnly Property Devices As DevicesCollection
        Get
            Return dxvuCtrl.Devices
        End Get
    End Property

    Private Sub Initialize()
        rlLockedTrack.Result = Nothing

        For i As Integer = 0 To resultLabels.Count - 1
            resultLabels(i).CustomText = " "
        Next

        If mSelectedStation Is Nothing Then
            lblStationName.Text = "(No Station Selected)"
            btnStart.Enabled = False
            btnStop.Enabled = False
        Else
            samplingTime = mSelectedStation.SamplingTime * 1000

            For Each device In dxvuCtrl.Devices
                If device.GUID.ToString() = mSelectedStation.RecordingDevice Then
                    device.Selected = True
                    Exit For
                End If
            Next

            lblStationName.Text = mSelectedStation.Name
            btnStart.Enabled = True
            btnStop.Enabled = False
        End If
    End Sub

    Private similarHashCustomComparer As New SimilarHashComparer()
    Private Class SimilarHashComparer
        Implements IEqualityComparer(Of SimilarHash)

        Public Overloads Function Equals(x As FPDataManager.SimilarHash, y As FPDataManager.SimilarHash) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of FPDataManager.SimilarHash).Equals
            Return (x.TrackID = y.TrackID)
        End Function

        Public Overloads Function GetHashCode(obj As FPDataManager.SimilarHash) As Integer Implements System.Collections.Generic.IEqualityComparer(Of FPDataManager.SimilarHash).GetHashCode
            Return obj.TrackID
        End Function
    End Class
End Class

Imports TracksManager.TrackAnalyzer
Imports System.Threading

Public Class AnalyzerForm
    Private mDirtyTracks As List(Of DirtyTrack)

    Private mainThread As Thread
    Private waiter As New AutoResetEvent(False)
    Private analyzers As New List(Of TrackAnalyzer)
    Private swEleapsed As New Stopwatch()

    Private threadsReadyCount As Integer

    Private masterSyncObject As New Object()

    Private threadsTotalCount As Integer

    Public Property DirtyTracks As List(Of DirtyTrack)
        Get
            Return mDirtyTracks
        End Get
        Set(value As List(Of DirtyTrack))
            mDirtyTracks = value

            InitializeThreads()
        End Set
    End Property

    Private Sub InitializeThreads()
        Dim pad As Integer = 5
        Dim y As Integer = pbGlobalProgress.Bottom + 3 * pad

        threadsTotalCount = Math.Min(Environment.ProcessorCount - 1, mDirtyTracks.Count)

        For i As Integer = 0 To threadsTotalCount - 1
            analyzers.Add(New TrackAnalyzer())
            Application.DoEvents()
        Next

        Dim ta As TrackAnalyzer = Nothing
        For Each ta In analyzers
            Me.Controls.Add(ta)
            ta.Location = New Point(pad, y)
            ta.Width = Me.Width - 6 * pad

            ta.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

            AddHandler ta.AnalysisResult, Sub(sender As Object, e As ResultEventArgs) waiter.Set()

            AddHandler ta.DxvuCtrl.ControlIsReady, Sub()
                                                       threadsReadyCount += 1
                                                       waiter.Set()
                                                   End Sub



            y += ta.Height + pad
        Next

        Me.Height = y + ta.Height + pad
        Me.MinimumSize = Me.Size
        Me.MaximumSize = New Size(9999, Me.Height)

        mainThread = New Thread(AddressOf Scheduler)
        mainThread.Start()
    End Sub

    Private Sub Scheduler()
        Dim currentTrackIndex As Integer = 0
        Dim totalTracks As Integer = mDirtyTracks.Count

        swEleapsed.Start()
        UpdateGlobalProgress(0)

        Do
            waiter.WaitOne()
        Loop Until threadsReadyCount = threadsTotalCount

        Thread.Sleep(100)

        If totalTracks > 0 Then
            Do
                For i As Integer = 0 To analyzers.Count - 1
                    If currentTrackIndex >= totalTracks Then Exit For

                    If Not analyzers(i).IsAnalyzing Then
                        analyzers(i).AnalyzeTrack(mDirtyTracks(currentTrackIndex), masterSyncObject)
                        currentTrackIndex += 1
                    End If

                    Thread.Sleep(100)
                Next

                waiter.WaitOne()

                UpdateGlobalProgress(currentTrackIndex / totalTracks * 100)

                If currentTrackIndex >= mDirtyTracks.Count Then
                    Dim allAnalyzersHaveFinished As Boolean = True

                    For i As Integer = 0 To analyzers.Count - 1
                        If analyzers(i).IsAnalyzing Then
                            allAnalyzersHaveFinished = False
                            Exit For
                        End If
                    Next

                    If allAnalyzersHaveFinished Then Exit Do
                End If
            Loop
        End If

        Me.Invoke(New MethodInvoker(Sub() Me.Close()))
    End Sub

    Private Sub UpdateGlobalProgress(p As Double)
        Me.Invoke(New MethodInvoker(Sub()
                                        ' FIXME: Please, fix this mess!
                                        Do
                                            Application.DoEvents()
                                        Loop Until Me.Handle <> IntPtr.Zero

                                        lblGlobalProgress.Text = String.Format("Global Progress: {0:F2}%", p)
                                        pbGlobalProgress.Value = p
                                        lblEleapsed.Text = String.Format("{0:00}:{1:00}:{2:00}", swEleapsed.Elapsed.Hours,
                                                                                                 swEleapsed.Elapsed.Minutes,
                                                                                                 swEleapsed.Elapsed.Seconds)
                                    End Sub))
    End Sub
End Class
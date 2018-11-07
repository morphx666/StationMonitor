Imports System.Threading
Imports FPDataManager
Imports TracksManager.TrackAnalyzer.ResultEventArgs

Public Class TrackAnalyzer
    Public Class DirtyTrack
        Private mItem As ListViewItem
        Private mArtist As String
        Private mTitle As String
        Private mAlbum As String
        Private mGenre As String
        Private mFileName As String
        Private mYear As String
        Private mAnalysisResult As Results

        Public Sub New(item As ListViewItem, artist As String, title As String, album As String, genre As String, year As String, fileName As String)
            mItem = item
            mArtist = artist
            mTitle = title
            mAlbum = album
            mGenre = genre
            mFileName = fileName
        End Sub

        Public ReadOnly Property Item As ListViewItem
            Get
                Return mItem
            End Get
        End Property

        Public Property AnalysisResult As Results
            Get
                Return mAnalysisResult
            End Get
            Set(value As Results)
                mAnalysisResult = value
            End Set
        End Property

        Public ReadOnly Property Artist As String
            Get
                Return mArtist
            End Get
        End Property

        Public ReadOnly Property Title As String
            Get
                Return mTitle
            End Get
        End Property

        Public ReadOnly Property Album As String
            Get
                Return mAlbum
            End Get
        End Property

        Public ReadOnly Property Genre As String
            Get
                Return mGenre
            End Get
        End Property

        Public ReadOnly Property FileName As String
            Get
                Return mFileName
            End Get
        End Property

        Public ReadOnly Property Year As String
            Get
                Return mYear
            End Get
        End Property
    End Class

    Private mDirtyTrack As DirtyTrack

    Private fpData As DataManager
    Private hashDataLib As HashLib

    Private syncObject As Object
    Private waiter As New AutoResetEvent(False)
    Private lastStatus As HashLib.StatusEventArgs
    Private swProgressTimer As Stopwatch = New Stopwatch()
    Private mIsAnalyzing As Boolean
    Private abortThread As Boolean

    Public Class ResultEventArgs
        Inherits EventArgs

        Public Enum Results
            Done
            AnalysisFailed
            TrackTooShort
            DatabaseError
        End Enum

        Private mDescription
        Private mResult As Results

        Public Sub New(result As Results, Optional description As String = "")
            mResult = result
            mDescription = description
        End Sub

        Public ReadOnly Property Result As Results
            Get
                Return mResult
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return mDescription
            End Get
        End Property
    End Class

    Public Event AnalysisResult(sender As Object, e As ResultEventArgs)

    Private Sub dxvuCtrl_ControlIsReady() Handles dxvuCtrl.ControlIsReady
        InitializeSystem()
    End Sub

    Private Sub TrackAnalyzer_HandleCreated(sender As Object, e As System.EventArgs) Handles Me.HandleCreated
        If Me.FindForm IsNot Nothing Then AddHandler CType(Me.FindForm, Form).FormClosing, Sub()
                                                                                               dxvuCtrl.StopMonitoring()
                                                                                               fpData.Data.SaveChanges()
                                                                                               hashDataLib.Dispose()
                                                                                               fpData.Dispose()
                                                                                               dxvuCtrl.Dispose()
                                                                                           End Sub
    End Sub

    Private Sub InitializeSystem()
        fpData = New DataManager()
        hashDataLib = New HashLib(dxvuCtrl)

        'Un4seen.Bass.Bass.BASS_Init(-1, 44100, Un4seen.Bass.BASSInit.BASS_DEVICE_DEFAULT, Me.Handle)
        'Un4seen.Bass.AddOn.Mix.BassMix.LoadMe()

        AddHandler hashDataLib.Status, Sub(sender As Object, e As HashLib.StatusEventArgs)
                                           lastStatus = e

                                           Me.Invoke(New MethodInvoker(Sub()
                                                                           If e.Status = HashLib.StatusFlags.Error Then
                                                                               lblCurTrackStatus.Text = "Error: " + ToNiceStatusMessage(e.Error.ToString())
                                                                           Else
                                                                               lblCurTrackStatus.Text = ToNiceStatusMessage(e.Status.ToString())
                                                                           End If
                                                                       End Sub))

                                           waiter.Set()
                                       End Sub

        AddHandler hashDataLib.FFTProgress, Sub(sender As Object, e As HashLib.ProgressEventArgs)
                                                Me.Invoke(New MethodInvoker(Sub()
                                                                                Dim p As Single = e.Percentage
                                                                                pbCurrentTrack.Value = p * 100
                                                                            End Sub))
                                            End Sub

        dxvuCtrl.BackColor = Color.FromKnownColor(KnownColor.Control)
        dxvuCtrl.EnableRendering = False
    End Sub

    Private Function ToNiceStatusMessage(message As String) As String
        Dim Z = Asc("Z")
        Dim msg As String = ""
        For Each c In message
            If msg <> "" AndAlso Asc(c) <= Z Then msg += " "
            msg += c
        Next

        Return msg
    End Function

    Public ReadOnly Property IsAnalyzing As Boolean
        Get
            Return mIsAnalyzing
        End Get
    End Property

    Public Sub AnalyzeTrack(track As DirtyTrack, syncObject As Object)
        mDirtyTrack = track
        Me.syncObject = syncObject

        Me.Invoke(New MethodInvoker(Sub()
                                        With pbCurrentTrack
                                            .Minimum = 0
                                            .Maximum = 100
                                            .Value = 0
                                        End With

                                        lblCurTrackProgress.Text = String.Format("{0} - {1}", mDirtyTrack.Artist, mDirtyTrack.Title)
                                    End Sub))

        If swProgressTimer.IsRunning Then swProgressTimer.Stop()
        swProgressTimer.Start()

        Dim analyzeThread = New Thread(AddressOf AnalyzeSub)
        analyzeThread.Start()
    End Sub

    Private Sub AnalyzeSub()
        Dim retries As Integer = 0

        mIsAnalyzing = True

        Do
            If hashDataLib.AnalyzeFile(mDirtyTrack.FileName) Then
                Do
                    waiter.WaitOne()
                    If abortThread Then Exit Sub
                Loop Until lastStatus.Status = HashLib.StatusFlags.HashesReady OrElse lastStatus.Status = HashLib.StatusFlags.Error

                Select Case lastStatus.Error
                    Case FPDataManager.HashLib.Errors.PerformingFFT
                        Thread.Sleep(100)
                    Case FPDataManager.HashLib.Errors.TrackLength
                        retries += 1
                        If retries < 2 Then
                            Thread.Sleep(100)
                        Else
                            mDirtyTrack.AnalysisResult = Results.TrackTooShort
                            SafeRaiseEvent(Results.TrackTooShort)
                            Exit Do
                        End If
                    Case FPDataManager.HashLib.Errors.None
                        retries = 0

                        Try
                            SyncLock syncObject
                                AddItemToDB()
                            End SyncLock
                            mDirtyTrack.AnalysisResult = Results.Done
                            SafeRaiseEvent(Results.Done)
                        Catch ex As Exception
                            mDirtyTrack.AnalysisResult = Results.DatabaseError
                            SafeRaiseEvent(Results.DatabaseError,
                                           "Error adding to the database the '" + mDirtyTrack.FileName + "' file:" + vbCrLf +
                                           ex.Message + vbCrLf + vbCrLf + ex.InnerException.Message)
                        End Try

                        Exit Do
                End Select
            Else
                mDirtyTrack.AnalysisResult = Results.AnalysisFailed
                SafeRaiseEvent(ResultEventArgs.Results.AnalysisFailed)
            End If
        Loop
    End Sub

    Private Sub AddItemToDB()
        Dim newTrack As Track
        Dim matchingTracks = (From track In fpData.Data.Tracks Where track.FileName = mDirtyTrack.FileName)

        If matchingTracks.Count > 0 Then
            newTrack = matchingTracks.First()
            fpData.Data.ExecuteStoreCommand("DELETE FROM Fingerprints WHERE TrackID=" + newTrack.ID.ToString())
            fpData.Data.ExecuteStoreCommand("DELETE FROM SubFingerprints WHERE TrackID=" + newTrack.ID.ToString())
        Else
            newTrack = New Track()
        End If

        newTrack.Title = mDirtyTrack.Title
        newTrack.Year = mDirtyTrack.Year
        newTrack.FileName = mDirtyTrack.FileName
        newTrack.ArtistID = GetArtistID(mDirtyTrack.Artist)
        newTrack.AlbumID = GetAlbumID(mDirtyTrack.Album)
        newTrack.GenreID = GetGenreID(mDirtyTrack.Genre)

        For Each hash In hashDataLib.Hashes
            Dim newFingerprint = New Fingerprint()
            newFingerprint.Hash = hash.HashValue
            newFingerprint.Position = hash.Position

            'newFingerprint.c1 = hash.CeptralCoeficients(0)
            'newFingerprint.c2 = hash.CeptralCoeficients(1)
            'newFingerprint.c3 = hash.CeptralCoeficients(2)
            'newFingerprint.c4 = hash.CeptralCoeficients(3)
            'newFingerprint.c5 = hash.CeptralCoeficients(4)
            'newFingerprint.c6 = hash.CeptralCoeficients(5)
            'newFingerprint.c7 = hash.CeptralCoeficients(6)
            'newFingerprint.c8 = hash.CeptralCoeficients(7)
            'newFingerprint.c9 = hash.CeptralCoeficients(8)
            'newFingerprint.c10 = hash.CeptralCoeficients(9)
            'newFingerprint.c11 = hash.CeptralCoeficients(10)
            'newFingerprint.c12 = hash.CeptralCoeficients(11)

            newTrack.Fingerprints.Add(newFingerprint)
        Next

        For Each hash In hashDataLib.ImportantHashes
            Dim newSubFingerprint = New SubFingerprint()
            newSubFingerprint.Hash = hash.HashValue
            newSubFingerprint.Position = hash.Position

            newTrack.SubFingerprints.Add(newSubFingerprint)
        Next

        If matchingTracks.Count = 0 Then fpData.Data.Tracks.AddObject(newTrack)

        fpData.SaveAndRenewContext()
    End Sub

    Private Function GetArtistID(artistName As String) As Integer
        Dim matchingArtists = (From artist In fpData.Data.Artists Where artist.Name = artistName Select artist)
        If matchingArtists.Count > 0 Then
            Return matchingArtists.First().ID
        Else
            Dim newArtist = New Artist()
            newArtist.Name = artistName
            fpData.Data.Artists.AddObject(newArtist)
            fpData.Data.SaveChanges()
            Return newArtist.ID
        End If
    End Function

    Private Function GetAlbumID(albumName As String) As Integer
        Dim matchingAlbums = (From album In fpData.Data.Albums Where album.Name = albumName Select album)
        If matchingAlbums.Count > 0 Then
            Return matchingAlbums.First().ID
        Else
            Dim newAlbum = New Album()
            newAlbum.Name = albumName
            fpData.Data.Albums.AddObject(newAlbum)
            fpData.Data.SaveChanges()
            Return newAlbum.ID
        End If
    End Function

    Private Function GetGenreID(genreName As String) As Integer
        Dim matchingGenres = (From genre In fpData.Data.Genres Where genre.Name = genreName Select genre)
        If matchingGenres.Count > 0 Then
            Return matchingGenres.First().ID
        Else
            Dim newGenre = New Genre()
            newGenre.Name = genreName
            fpData.Data.Genres.AddObject(newGenre)
            fpData.Data.SaveChanges()
            Return newGenre.ID
        End If
    End Function

    Private Sub SafeRaiseEvent(result As Results, Optional description As String = "")
        Dim e As New ResultEventArgs(result, description)

        mIsAnalyzing = False

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(Sub() RaiseEvent AnalysisResult(Me, e)))
        Else
            RaiseEvent AnalysisResult(Me, e)
        End If
    End Sub
End Class

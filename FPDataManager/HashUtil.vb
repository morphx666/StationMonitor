Imports NDXVUMeterNET.DXVUMeterNETGDI
Imports NDXVUMeterNET
Imports System.Windows.Forms
Imports System.Drawing

Public Class HashLib
    Implements IDisposable

    'Public Frequencies() As Integer = New Integer() {50, 150, 250, 350, 450, 570, 700, 840, 1000, 1170, 1370, 1600, 1850,
    '                                                 2150, 2500, 2900, 3400, 4000, 4800, 5800, 7000, 8500, 10500, 13500, 17500}

    'Public Frequencies() As Integer = New Integer() {570, 700, 840, 1000, 1170, 1370, 1600, 1850,
    '                                                 2150, 2500, 2900, 3400, 4000, 4800}

    Public Frequencies() As Integer = New Integer() {250, 350, 450, 570, 700, 840, 1000, 1170, 1370,
                                                     1600, 1850, 2150, 2500}

    Public Const NumOfMelBands As Integer = 12

    Public Property PaintBands As Boolean

    Public Shared ReadOnly SupportedFileTypes() As String = New String() {"mp3", "acc", "wav", "aif", "aiff", "wma", "ogg", "ac3"}

    Public BandsEnergies As New List(Of Dictionary(Of Integer, Double))
    Public CeptralCoefficients As New List(Of Double())

    Private buffer As IO.FileStream
    Private tmpBufferFileName As String
    Private providerBuffer() As Byte
    Private bufferIndex As Long
    Private bufferLength As Long
    Private numBytesPerSample As Integer
    Private bandsIndexes() As Integer

    Private framesToSkip As Integer = 0
    Private framesCounter As Integer = 0

    Private bassStream As Integer

    Private curFrameEnergySum As New Dictionary(Of Integer, Double)()

    Private mAnalyzeFFTFrames As Boolean = False
    Private mDXVUCtrl As DXVUMeterNETGDI
    Private mPlayingFileLength As Long
    Private mPlayingFileName As String

    Public Class Hash
        Public HashValue As Integer
        Public Position As Double
        Public CeptralCoeficients() As Double

        Public Sub New(fp As Fingerprint)
            HashValue = fp.Hash
            Position = fp.Position
            'CeptralCoeficients = {fp.c1, fp.c2, fp.c3, fp.c4, fp.c5, fp.c6, fp.c7, fp.c8, fp.c9, fp.c10, fp.c11, fp.c12}
        End Sub

        Public Sub New(hashValue As Integer, position As Double)
            Me.HashValue = hashValue
            Me.Position = position
        End Sub

        Public Sub New(hashValue As Integer, ceptralCoeficients As Double(), position As Double)
            Me.New(hashValue, position)
            Me.CeptralCoeficients = ceptralCoeficients
        End Sub
    End Class

    Private mHashes() As Hash
    Private mImportantHashes() As Hash

    Private dummyEventArgs As New EventArgs()

    Public Class ProgressEventArgs
        Public ReadOnly Property Percentage As Double
        Public ReadOnly Property IsDone As Boolean

        Public Sub New(percentage As Double, isDone As Boolean)
            Me.Percentage = percentage
            Me.IsDone = isDone
        End Sub
    End Class

    Public Enum StatusFlags
        Decompressing
        ExtractingAudioFeatures
        GeneratingHashes
        HashesReady
        Playing
        Stopping
        WaitingForSystem
        [Error]
    End Enum

    Public Enum Errors
        PerformingFFT
        TrackLength
        Decompressing
        InvalidBufferSize
        SystemNotReady
        None
    End Enum

    Public Class StatusEventArgs
        Public ReadOnly Property Status As StatusFlags
        Public ReadOnly Property [Error] As Errors

        Public Sub New(status As StatusFlags, Optional [error] As Errors = Errors.None)
            Me.Status = status
            Me.Error = [error]
        End Sub
    End Class

    Public Event FFTFrame(sender As Object, e As EventArgs)
    Public Event FFTProgress(sender As Object, e As ProgressEventArgs)
    Public Event Status(sender As Object, e As StatusEventArgs)

    Private mfcc As MFCC

    Public Sub New(dxvuCtrl As DXVUMeterNETGDI)
        mDXVUCtrl = dxvuCtrl

        If mDXVUCtrl IsNot Nothing Then
            With mDXVUCtrl
                .LicenseControl("00000000000000000000000000000000", "FingerPrinting")

                .Style = StyleConstants.FFT

                .FFTSize = FFTSizeConstants.FFTs1024

                .FFTXZoom = True
                .FFTXScale = FFTXScaleConstants.Logarithmic

                .FFTWindow = FFTWindowConstants.Hanning
                .FFTYScale = FFTYScaleConstants.dB
                .FFTNormalized = True

                .FFTStyle = FFTStyleConstants.Line

                .Frequency = 11025
                .Channels = 1
                .BitDepth = 16

                .FFTHistorySize = 4

                .GreenOff = Color.FromArgb(200, .GreenOff)
                .FFTSmoothing = 3
                .LinesThickness = 2

                .BackColor = System.Drawing.Color.Black
            End With

            GetBandIndexes()
            mfcc = New MFCC(mDXVUCtrl.Frequency, mDXVUCtrl.FFTSize, NumOfMelBands + 2, False, Frequencies.First(), Frequencies.Last(), NumOfMelBands * 2)

            AddHandler mDXVUCtrl.FFTFrame, Sub()
                                               If mAnalyzeFFTFrames Then AnalyzeAudioFrame()
                                               RaiseEvent FFTFrame(Me, dummyEventArgs)
                                           End Sub

            AddHandler mDXVUCtrl.Paint, Sub(sender As Object, e As System.Windows.Forms.PaintEventArgs)
                                            If Not PaintBands Then Exit Sub

                                            Dim bandIndex As Integer
                                            Dim x As Integer
                                            Dim fftMin = dxvuCtrl.Freq2FFTIdx(dxvuCtrl.FFTXMin)
                                            Dim fftMax = dxvuCtrl.Freq2FFTIdx(dxvuCtrl.FFTXMax)
                                            Dim h As Integer = dxvuCtrl.Height

                                            Using p As Pen = New Pen(Color.FromArgb(96, Color.Yellow), 2)
                                                For i = 0 To NumOfFFTBands - 1
                                                    bandIndex = bandsIndexes(i)
                                                    x = dxvuCtrl.FFTIdx2X(bandIndex, fftMin, fftMax, dxvuCtrl.Width)
                                                    e.Graphics.DrawLine(p, x, 0, x, h)
                                                Next
                                            End Using
                                        End Sub

            AddHandler mDXVUCtrl.DoubleClick, Sub() PaintBands = Not PaintBands

            Un4seen.Bass.BassNet.Registration("", "")
            If Un4seen.Bass.Bass.BASS_Init(-1, 44100, Un4seen.Bass.BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero) Then
                Un4seen.Bass.Bass.BASS_PluginLoad("bass_aac.dll")
                Un4seen.Bass.Bass.BASS_PluginLoad("bass_ac3.dll")
                'Un4seen.Bass.Bass.BASS_PluginLoad("bassflac.dll")
                Un4seen.Bass.Bass.BASS_PluginLoad("basswma.dll")

                Un4seen.Bass.AddOn.Mix.BassMix.LoadMe()
            End If
        End If

        AddHandler Me.FFTProgress, Sub(sender As Object, e As ProgressEventArgs)
                                       If e.IsDone Then
                                           mDXVUCtrl.StopMonitoring()

                                           If BandsEnergies.Count = 0 Then
                                               RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Error, Errors.PerformingFFT))
                                           Else
                                               RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.GeneratingHashes))
                                               ComputeHashes()

                                               If mHashes.Count < 100 Then
                                                   RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Error, Errors.TrackLength))
                                               Else
                                                   RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.HashesReady))
                                               End If
                                           End If
                                       End If
                                   End Sub
    End Sub

    ' NOTE: Not using this anymore... http://www.codeproject.com/Questions/188926/Generating-a-logarithmically-spaced-numbers
    Private Sub GetBandIndexes()
        Dim indexes As New List(Of Integer)
        Dim numOfFreq As Integer = Frequencies.Length - 1
        Dim bandIndex As Integer = 0

        For i = 0 To numOfFreq
            If Frequencies(i) >= mDXVUCtrl.Frequency / 2 Then Exit For

            indexes.Add(mDXVUCtrl.Freq2FFTIdx(Frequencies(i)))
            If i < numOfFreq Then indexes.Add(mDXVUCtrl.Freq2FFTIdx(Frequencies(i) + (Frequencies(i + 1) - Frequencies(i)) / 2))
        Next

        bandsIndexes = indexes.ToArray()
    End Sub

    Public ReadOnly Property DXVUCtrl As DXVUMeterNETGDI
        Get
            Return mDXVUCtrl
        End Get
    End Property

    Public ReadOnly Property Hashes() As Hash()
        Get
            Return mHashes
        End Get
    End Property

    Public ReadOnly Property ImportantHashes As Hash()
        Get
            Return mImportantHashes
        End Get
    End Property

    Public ReadOnly Property NumOfFFTBands As Integer
        Get
            Return bandsIndexes.Length
        End Get
    End Property

    Public Property AnalyzeFFTFrames As Boolean
        Get
            Return mAnalyzeFFTFrames
        End Get
        Set(value As Boolean)
            mAnalyzeFFTFrames = value
        End Set
    End Property

    Public Shared Function HammingDistance(hash1 As Integer, hash2 As Integer) As Integer
        Dim distance As Integer = 0
        Dim hammingWeigth As Integer = (hash1 Xor hash2) '>> 2 ' Ignore the first few bits which belong to the high frequencies
        Do While hammingWeigth > 0
            distance += 1
            hammingWeigth = hammingWeigth And (hammingWeigth - 1)
        Loop

        Return distance
    End Function

    ' The partition parameter MUST be even
    Public Sub ComputeHashes(Optional partition As Integer = 10)
        'mfcc.NormalizeVectors(CeptralCoefficients.ToArray())

        If BandsEnergies.Count > 0 Then
            Dim frameCount = BandsEnergies.Count - 1
            Dim bandCount = NumOfFFTBands - 1
            Dim value As Integer

            ReDim mHashes(frameCount - 1)
            Dim importantHashes As New List(Of Hash)()

            Dim importantHash As Hash = Nothing
            Dim curFrameEnergy As Double
            Dim maxEnergy As Double = -1

            For frame As Integer = 1 To frameCount
                value = 0
                curFrameEnergy = 0

                For band As Integer = 0 To bandCount - 1
                    Dim t1 As Double = BandsEnergies(frame)(band)
                    Dim t2 As Double = BandsEnergies(frame)(band + 1)
                    Dim t3 As Double = BandsEnergies(frame - 1)(band)
                    Dim t4 As Double = BandsEnergies(frame - 1)(band + 1)

                    ' EB(f,b) - EB(f,b+1) - (EB(f-1,b) - EB(f-1,b+1))
                    'If t1 - t2 - (t3 - t4) > 0 Then value += 2 ^ (bandCount - band - 1)
                    If t1 - (t2 - (t3 - t4)) > 0 Then value += 2 ^ (bandCount - band - 1)

                    curFrameEnergy += t1
                Next

                'mHashes(frame - 1) = New Hash(value, CeptralCoefficients(frame), frame / frameCount)
                mHashes(frame - 1) = New Hash(value, (frame - 1) / frameCount)

                If curFrameEnergy > maxEnergy Then
                    maxEnergy = curFrameEnergy
                    importantHash = mHashes(frame - 1)
                End If

                If frame Mod partition = 0 Then
                    importantHashes.Add(importantHash)
                    maxEnergy = -1
                End If
            Next

            If importantHashes.Count = 0 Then importantHashes.Add(importantHash)

            TrimSilence()
            mImportantHashes = importantHashes.ToArray()
        Else
            ReDim mHashes(-1)
            ReDim mImportantHashes(-1)
        End If
    End Sub

    Private Sub GetCeptralCoefficients()
        Dim values(mDXVUCtrl.FFTSize - 1) As Double
        For i As Integer = 0 To mDXVUCtrl.FFTSize / 2
            ' TODO: Didn't we conclude that we need to use FFTAverageFromIndex instead of FFTPowerFromIndex?
            values(i) = mDXVUCtrl.FFTPowerFromIndex(i, FFTChannelConstants.Left)
        Next

        CeptralCoefficients.Add(mfcc.ProcessFFT(values))
    End Sub

    Private Sub GetBandsPower()
        Dim value As Double = 0

        For i = 0 To NumOfFFTBands - 1
            ' TODO: DXVUMeterNET supports adjusting the bandwidth of the FFTAverage on a particular band.
            ' We should try setting the bandwidth to "2" in order to average the power of a band based on its history
            '    and the power of the two adjacent bands ((b-1)+b+(b+1))/3:
            '    mDXVUCtrl.FFTAverageFromIndex(bandsIndexes(i), FFTChannelConstants.Left, 2)
            If mDXVUCtrl.LeftChannelMute Then
                value = mDXVUCtrl.FFTAverageFromIndex(bandsIndexes(i), FFTChannelConstants.Right, 2)
            Else
                value = mDXVUCtrl.FFTAverageFromIndex(bandsIndexes(i), FFTChannelConstants.Left, 2)
            End If
            If value < 0.02 Then value = 0
            curFrameEnergySum.Add(i, value ^ 2)
        Next

        BandsEnergies.Add(New Dictionary(Of Integer, Double)(curFrameEnergySum))
        curFrameEnergySum.Clear()
    End Sub

    Private Sub AnalyzeAudioFrame()
        If framesCounter = framesToSkip Then
            'GetCeptralCoefficients()
            GetBandsPower()

            framesCounter = 0
        Else
            framesCounter += 1
        End If
    End Sub

    Private Sub TrimSilence()
        If mHashes.Length > 0 Then
            Dim index As Integer = 0
            While index < mHashes.Length AndAlso mHashes(index).HashValue = 0
                index += 1
            End While
            If index > 0 Then
                Array.Copy(mHashes, index, mHashes, 0, mHashes.Length - index)
                ReDim Preserve mHashes(mHashes.Length - index)
            End If

            If mHashes.Length > 1 Then
                index = 0
                While mHashes(mHashes.Length - index - 1).HashValue = 0
                    index += 1
                End While
                If index > 0 Then ReDim Preserve mHashes(mHashes.Length - index - 1)
            End If
        End If
    End Sub

    Private Function BufferProvider() As Byte()
        Dim endOfBuffer As Boolean = False

        If bufferIndex + numBytesPerSample >= bufferLength Then
            numBytesPerSample = bufferLength - bufferIndex
            ReDim BufferProvider(numBytesPerSample - 1)
            endOfBuffer = True
        End If

        buffer.Read(providerBuffer, 0, numBytesPerSample)

        If endOfBuffer Then
            buffer.Close()
            buffer.Dispose()
            IO.File.Delete(tmpBufferFileName)
        End If

        bufferIndex += numBytesPerSample

        RaiseEvent FFTProgress(Me, New ProgressEventArgs(bufferIndex / bufferLength, endOfBuffer))

        Return providerBuffer
    End Function

    Public Function AnalyzeFile(fileName As String) As Boolean
        mDXVUCtrl.StopMonitoring()
        Threading.Thread.Sleep(100)

        RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Decompressing))

        If Not mDXVUCtrl.UsesCustomBuffer Then mDXVUCtrl.SetCustomBufferProvider(True, New DXVUMeterNETGDI.CustomBufferProvider(AddressOf BufferProvider))
        mAnalyzeFFTFrames = True

        Dim strm As Integer = Un4seen.Bass.Bass.BASS_StreamCreateFile(fileName, 0, 0, Un4seen.Bass.BASSFlag.BASS_STREAM_DECODE Or Un4seen.Bass.BASSFlag.BASS_STREAM_BLOCK)
        'Un4seen.Bass.Bass.BASS_ChannelPlay(strm, False)

        bufferIndex = 0
        If Un4seen.Bass.Bass.BASS_ChannelGetLength(strm) > 0 Then
            tmpBufferFileName = My.Computer.FileSystem.GetTempFileName()
            buffer = New IO.FileStream(tmpBufferFileName, IO.FileMode.OpenOrCreate)
            bufferLength = 0

            Dim b(131072 * 100) As Byte

            'Dim mixer As Integer = Un4seen.Bass.AddOn.Mix.BassMix.BASS_Mixer_StreamCreate(mDXVUCtrl.Frequency, mDXVUCtrl.Channels, Un4seen.Bass.BASSFlag.BASS_MIXER_END Or Un4seen.Bass.BASSFlag.BASS_STREAM_DECODE Or Un4seen.Bass.BASSFlag.BASS_SAMPLE_MONO)
            Dim mixer As Integer = Un4seen.Bass.AddOn.Mix.BassMix.BASS_Mixer_StreamCreate(mDXVUCtrl.Frequency, mDXVUCtrl.Channels, Un4seen.Bass.BASSFlag.BASS_MIXER_END Or Un4seen.Bass.BASSFlag.BASS_STREAM_DECODE)
            Un4seen.Bass.AddOn.Mix.BassMix.BASS_Mixer_StreamAddChannel(mixer, strm, Un4seen.Bass.BASSFlag.BASS_MIXER_FILTER)
            While (Un4seen.Bass.Bass.BASS_ChannelIsActive(strm) = Un4seen.Bass.BASSActive.BASS_ACTIVE_PLAYING)
                Dim len = Un4seen.Bass.Bass.BASS_ChannelGetData(mixer, b, b.Length)
                If len < 0 Then
                    Exit While
                Else
                    buffer.Write(b, 0, len)
                    bufferLength += len
                End If
            End While
            Un4seen.Bass.Bass.BASS_ChannelStop(strm)
            Un4seen.Bass.AddOn.Mix.BassMix.BASS_Mixer_ChannelRemove(strm)
            Un4seen.Bass.Bass.BASS_ChannelStop(mixer)
            Un4seen.Bass.Bass.BASS_StreamFree(strm)

            buffer.Position = 0
            Reset()

            RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.WaitingForSystem))

            mDXVUCtrl.StartMonitoring()
            Dim n As Integer = 0
            Do
                numBytesPerSample = mDXVUCtrl.CaptureBufferLenght / 2
                If numBytesPerSample <> 0 Then ReDim providerBuffer(numBytesPerSample - 1)

                Threading.Thread.Sleep(100)

                n += 1
                If n Mod 10 = 0 Then
                    If mDXVUCtrl.MonitoringState = MonitoringStateConstants.Idle Then
                        RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Error, Errors.SystemNotReady))
                    ElseIf numBytesPerSample = 0 Then
                        RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Error, Errors.InvalidBufferSize))
                    End If
                    mDXVUCtrl.StartMonitoring()
                End If
                If n = 100 Then
                    RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Error, Errors.Decompressing))
                    Return False
                End If
            Loop While (mDXVUCtrl.MonitoringState = MonitoringStateConstants.Idle OrElse mDXVUCtrl.CaptureBufferLenght = 0) AndAlso buffer IsNot Nothing

            If buffer Is Nothing Then
                Return False
            Else
                RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.ExtractingAudioFeatures))
                Return True
            End If
        Else
            If strm <> 0 Then Un4seen.Bass.Bass.BASS_StreamFree(strm)

            RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Error, Errors.Decompressing))
            Return False
        End If
    End Function

    Public Sub StartPlayback(fileName As String)
        StopPlayback()
        If IO.File.Exists(fileName) Then
            bassStream = Un4seen.Bass.Bass.BASS_StreamCreateFile(fileName, 0, 0, Un4seen.Bass.BASSFlag.BASS_SAMPLE_FLOAT)
            Un4seen.Bass.Bass.BASS_ChannelPlay(bassStream, False)

            Dim channelInfo = New Un4seen.Bass.BASS_CHANNELINFO()
            'Un4seen.Bass.Bass.BASS_ChannelGetInfo(bassStream, channelInfo)
            mPlayingFileLength = Un4seen.Bass.Bass.BASS_ChannelGetLength(bassStream)

            mAnalyzeFFTFrames = False
            mDXVUCtrl.SetCustomBufferProvider(False)
            mDXVUCtrl.StartMonitoring()

            mPlayingFileName = fileName

            RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Playing))
        End If
    End Sub

    Public Sub StopPlayback()
        If bassStream <> 0 Then
            Un4seen.Bass.Bass.BASS_ChannelStop(bassStream)
            Un4seen.Bass.Bass.BASS_StreamFree(bassStream)
            bassStream = 0

            mDXVUCtrl.StopMonitoring()
        End If

        mPlayingFileName = ""
        RaiseEvent Status(Me, New StatusEventArgs(StatusFlags.Stopping))
    End Sub

    Public ReadOnly Property PlayingFileName As String
        Get
            Return mPlayingFileName
        End Get
    End Property

    Public ReadOnly Property PlaybackFileLength As Long
        Get
            Return mPlayingFileLength
        End Get
    End Property

    Public Property PlaybackPosition As Long
        Get
            If bassStream <> 0 Then
                Return Un4seen.Bass.Bass.BASS_ChannelGetPosition(bassStream)
            Else
                Return -1
            End If
        End Get
        Set(value As Long)
            If bassStream <> 0 Then
                Un4seen.Bass.Bass.BASS_ChannelSetPosition(bassStream, value)
            End If
        End Set
    End Property

    Public Sub Reset()
        BandsEnergies.Clear()
        CeptralCoefficients.Clear()
    End Sub

    Public Sub UnloadBASS()
        Un4seen.Bass.Bass.BASS_PluginFree(0)
        Un4seen.Bass.AddOn.Mix.BassMix.FreeMe()
        Un4seen.Bass.Bass.BASS_Free()
        Un4seen.Bass.Bass.FreeMe()
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                StopPlayback()
                mDXVUCtrl.StopMonitoring()

                'Un4seen.Bass.Bass.BASS_PluginFree(0)
                'Un4seen.Bass.AddOn.Mix.BassMix.FreeMe()
                'Un4seen.Bass.Bass.BASS_Free()
                'Un4seen.Bass.Bass.FreeMe()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class

Partial Public Class SimilarHash
    Implements IEquatable(Of SimilarHash)

    Private mHits As Integer

    Public Property Hits As Integer
        Get
            Return mHits
        End Get
        Set(value As Integer)
            mHits = value
        End Set
    End Property

    Public Shared Operator =(sh1 As SimilarHash, sh2 As SimilarHash) As Boolean
        Return sh1.TrackID = sh2.TrackID
    End Operator

    Public Shared Operator <>(sh1 As SimilarHash, sh2 As SimilarHash) As Boolean
        Return sh1.TrackID <> sh2.TrackID
    End Operator

    Public Overrides Function ToString() As String
        Return String.Format("{0}: {1} ({2})", TrackID, ErrorLevel, Hits)
    End Function

    Public Overloads Function Equals(other As SimilarHash) As Boolean Implements IEquatable(Of SimilarHash).Equals
        Return TrackID = other.TrackID
    End Function
End Class
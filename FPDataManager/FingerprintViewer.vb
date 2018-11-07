Imports FPDataManager
Imports NDXVUMeterNET
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class FingerprintViewer
    Public Enum Modes
        Hashes
        CeptralCoeficients
    End Enum

    Private mTrack As Track
    Private mHashes(-1) As HashLib.Hash
    Private mImportantHashes(-1) As HashLib.Hash
    Private mHashDataLib As HashLib
    Private mShowCursort As Boolean
    Private mMode As Modes
    Private mHashBands As Integer = 32

    Private dotSize As Integer
    Private hashesPerPage As Integer
    Private fpRect As New Rectangle()

    Private hashIndex As Integer = -1
    Private playbackPosition As Double
    Private cursorColor As SolidBrush = New SolidBrush(Color.FromArgb(128, Color.Green))

    Private Sub FingerprintViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        AddHandler DoubleClick, Sub() Mode = If(Mode = Modes.CeptralCoeficients, Modes.Hashes, Modes.CeptralCoeficients)
        AddHandler Resize, AddressOf SetupUI

        SetupUI()
    End Sub

    <Category("Appearance")>
    Public Property Mode As Modes
        Get
            Return mMode
        End Get
        Set(value As Modes)
            mMode = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShowPlayStopButtons As Boolean
        Get
            Return BtnPlay.Visible
        End Get
        Set(value As Boolean)
            BtnPlay.Visible = value
            BtnStop.Visible = value

            SetupUI()
        End Set
    End Property

    Public Property ShowCursor As Boolean
        Get
            Return mShowCursort
        End Get
        Set(value As Boolean)
            mShowCursort = value
            Me.Invalidate()
        End Set
    End Property

    Public Property HashBands As Integer
        Get
            Return mHashBands
        End Get
        Set(value As Integer)
            mHashBands = value
            SetupUI()
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        'MyBase.OnPaintBackground(e)
    End Sub

    Public Sub AttachToHashDataLib(hashDataLib As HashLib)
        mHashDataLib = hashDataLib
        HashBands = mHashDataLib.NumOfFFTBands

        AddHandler mHashDataLib.FFTFrame, Sub()
                                              If Not mHashDataLib.AnalyzeFFTFrames AndAlso hashIndex >= 0 Then
                                                  playbackPosition = mHashDataLib.PlaybackPosition / mHashDataLib.PlaybackFileLength
                                                  If Math.Abs(mHashes(hashIndex).Position - playbackPosition) > 0.001 Then hashIndex += 1

                                                  If hashIndex < mHashes.Count Then
                                                      If Math.Abs(mHashes(hashIndex).Position - playbackPosition) > 0.0001 Then
                                                          For i = 0 To mHashes.Count - 1
                                                              If Math.Abs(mHashes(i).Position - playbackPosition) <= 0.0001 Then
                                                                  hashIndex = i
                                                                  Exit For
                                                              End If
                                                          Next
                                                      End If

                                                      If hashIndex >= VsbOffset.Value + VsbOffset.LargeChange \ 2 Then
                                                          VsbOffset.Value = Math.Min(VsbOffset.Maximum, hashIndex - VsbOffset.LargeChange \ 2)
                                                      ElseIf hashIndex < VsbOffset.Value Then
                                                          VsbOffset.Value = hashIndex
                                                      End If

                                                      Me.Invalidate()
                                                  ElseIf hashIndex = mHashes.Count Then
                                                      hashDataLib.StopPlayback()
                                                  Else
                                                      hashIndex = 0
                                                  End If
                                              End If
                                          End Sub
    End Sub

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Track(Optional setHashesFromTrack As Boolean = True) As Track
        Get
            Return mTrack
        End Get
        Set(value As Track)
            Dim oldID As Integer = -1
            If mTrack IsNot Nothing Then oldID = mTrack.ID

            Me.Stop()
            mTrack = value

            If setHashesFromTrack Then
                If mTrack Is Nothing Then
                    ReDim mHashes(-1)
                    ReDim mImportantHashes(-1)
                ElseIf oldID <> mTrack.ID Then
                    mHashes = mTrack.Fingerprints.Select(Function(f) New HashLib.Hash(f)).ToArray()
                    mImportantHashes = mTrack.SubFingerprints.Select(Function(f) New HashLib.Hash(f.Hash, f.Position)).ToArray()
                End If

                ResetUI()
            End If
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Hashes As HashLib.Hash()
        Get
            Return mHashes
        End Get
        Set(value As HashLib.Hash())
            mHashes = value

            ResetUI()
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property SelectedHash As Integer
        Get
            Return hashIndex
        End Get
        Set(value As Integer)
            hashIndex = value
            VsbOffset.Value = If(value >= VsbOffset.Minimum AndAlso value <= VsbOffset.Maximum, hashIndex, 0)
            Me.Invalidate()
        End Set
    End Property

    Private Sub SetupUI()
        BtnPlay.Enabled = mTrack IsNot Nothing
        BtnStop.Enabled = mTrack IsNot Nothing

        BtnPlay.Top = Me.Height - BtnPlay.Height
        BtnStop.Top = Me.Height - BtnPlay.Height

        VsbOffset.Left = Me.Width - VsbOffset.Width
        VsbOffset.Top = 0
        VsbOffset.Height = Me.Height - If(BtnPlay.Visible, BtnPlay.Height, 0)

        fpRect = Me.DisplayRectangle
        fpRect.Width -= VsbOffset.Width + 1
        fpRect.Height -= If(BtnPlay.Visible, BtnPlay.Height, 0) + 1

        dotSize = Math.Floor(fpRect.Width / mHashBands)
        hashesPerPage = (fpRect.Height / dotSize)

        VsbOffset.Enabled = mHashes.Length > hashesPerPage
        VsbOffset.LargeChange = hashesPerPage
    End Sub

    Private Sub ResetUI()
        SetupUI()
        VsbOffset.Value = 0
        VsbOffset.Maximum = mHashes.Length
        VsbOffset.SmallChange = 1

        Me.Invalidate()
    End Sub

    Private Sub FingerprintViewer_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics

        g.Clear(Color.White)

        g.DrawRectangle(Pens.Gray, fpRect)
        Dim r As Rectangle = fpRect
        r.X += 1
        r.Y += 1
        r.Width -= 1
        r.Height -= r.Y * 2

        Dim dot As New Rectangle(r.X, r.Y, dotSize, dotSize)

        Dim w As Integer = dotSize * mHashBands
        g.FillRectangle(Brushes.LightGray, w + 1, r.Y, r.Width - w, r.Height + 1)

        If mHashes.Length = 0 Then
            Dim flag As Boolean

            For y = 0 To r.Height Step dotSize
                For x = 0 To mHashBands - 1
                    flag = Not flag

                    If flag Then g.FillRectangle(Brushes.LightGray, dot)
                    dot.X += dotSize
                Next

                dot.X = r.X
                dot.Y += dotSize

                If mHashBands Mod 2 = 0 Then flag = Not flag
            Next
        Else
            Select Case mMode
                Case Modes.Hashes
                    Dim binaryHash As String

                    For i As Integer = VsbOffset.Value To mHashes.Length - 1
                        binaryHash = Convert.ToString(mHashes(i).HashValue, 2).PadLeft(mHashBands, "0")

                        'Debug.WriteLine(binaryHash)

                        For Each bit In binaryHash
                            If bit = "1"c Then g.FillRectangle(Brushes.Black, dot)
                            dot.X += dotSize
                        Next
                        If mShowCursort AndAlso hashIndex = i Then g.FillRectangle(cursorColor, r.X, dot.Y, r.Width, dotSize)

                        dot.X = r.X
                        dot.Y += dotSize

                        If dot.Y > r.Height - dotSize Then Exit For
                    Next
                Case Modes.CeptralCoeficients
                    Dim rh2 As Single = r.Height / 2
                    Dim barWidth As Integer = Math.Floor(r.Width / HashLib.NumOfMelBands)
                    Dim barHeight As Single
                    Dim maxValue As Double = (From h In mHashes Select h.CeptralCoeficients.Max()).Max() / 2
                    Dim index As Integer = If(hashIndex = -1, VsbOffset.Value, hashIndex)
                    For i As Integer = 0 To HashLib.NumOfMelBands - 1
                        barHeight = Math.Abs(mHashes(index).CeptralCoeficients(i) / maxValue * rh2)
                        If mHashes(VsbOffset.Value).CeptralCoeficients(i) > 0 Then
                            g.FillRectangle(Brushes.Black, r.X + i * barWidth, rh2 - barHeight, barWidth - 1, barHeight)
                        Else
                            g.FillRectangle(Brushes.Black, r.X + i * barWidth, rh2, barWidth - 1, barHeight)
                        End If
                    Next
            End Select
        End If
    End Sub

    Private Sub VsbOffset_Scroll(sender As Object, e As ScrollEventArgs) Handles VsbOffset.Scroll
        Me.Invalidate()
    End Sub

    Public Sub Play()
        If mHashDataLib IsNot Nothing Then
            hashIndex = 0
            VsbOffset.Value = 0
            Me.Invalidate()

            mHashDataLib.StartPlayback(mTrack.FileName)
        End If
    End Sub

    Public Sub [Stop]()
        If mHashDataLib IsNot Nothing Then
            hashIndex = -1
            VsbOffset.Value = 0
            Me.Invalidate()

            mHashDataLib.StopPlayback()
        End If
    End Sub

    Private Sub BtnPlay_Click(sender As Object, e As EventArgs) Handles BtnPlay.Click
        Play()
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        Me.Stop()
    End Sub

    Private Sub FingerprintViewer_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        SetupUI()
    End Sub
End Class

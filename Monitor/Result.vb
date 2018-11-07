Imports FPDataManager

Public Class Result
    Implements IComparable(Of Result)

    Public Property ErrorLevel As Double
    Public Property TrackID As Integer
    Public Property Hashes As HashLib.Hash()
    Public Property MatchHashIndex As Integer
    Public Property ErrorCount As Integer

    Private mIsSet As Boolean
    Private mTrack As Track

    Public Sub New()
        ErrorLevel = Double.MaxValue
    End Sub

    Public Sub New(track As Track)
        Me.New()
        Me.TrackID = track.ID
        Me.Track = track
    End Sub

    Public Sub New(similarHash As SimilarHash)
        Me.New()
        Me.TrackID = similarHash.TrackID
        Me.ErrorLevel = similarHash.ErrorLevel
    End Sub

    Public ReadOnly Property IsSet As Boolean
        Get
            Return mIsSet
        End Get
    End Property

    Public Sub UnSet()
        Track = Nothing
        TrackID = -1
    End Sub

    Public Property Track As Track
        Get
            Return mTrack
        End Get
        Set(value As Track)
            mTrack = value
            mIsSet = (mTrack IsNot Nothing)
            If mIsSet Then TrackID = mTrack.ID
        End Set
    End Property

    Public Overloads Function ToString() As String
        'Return String.Format("{0} at {1}m {2}s ({3}%): {4:F2}/{5:F2}/{6:F2}", FileName, Time.Minutes, Time.Seconds, Position, Score, Max, StdError)
        'Return String.Format("{0} at {1}m {2}s ({3}%): {4:F2}", NiceFileName, Time.Minutes, Time.Seconds, Position, Score)
        Return String.Format("{0}: {1:F2}%", NiceFileName, 100.0 - (ErrorLevel / errorMax * 100.0))
    End Function

    Public ReadOnly Property NiceFileName() As String
        Get
            Return Track.Artist.Name + " - " + Track.Title
        End Get
    End Property

    Public Shared Widening Operator CType(hash As SimilarHash) As Result
        Return New Result(hash)
    End Operator

    Public Shared Operator =(r1 As Result, r2 As Result) As Boolean
        If r1 Is Nothing Then
            Return r2 Is Nothing
        ElseIf r2 Is Nothing Then
            Return r1 Is Nothing
        End If

        Return r1.TrackID = r2.TrackID
    End Operator

    Public Shared Operator <>(r1 As Result, r2 As Result) As Boolean
        Return Not r1 = r2
    End Operator

    Public Overrides Function Equals(obj As Object) As Boolean
        Return If(TypeOf obj Is Result, Me = CType(obj, Result), False)
    End Function

    Public Function CompareTo(other As Result) As Integer Implements IComparable(Of Result).CompareTo
        Return ErrorLevel.CompareTo(other.ErrorLevel)
    End Function
End Class
Imports System.ComponentModel
Imports System.Threading

Public Class ResultLabel
    Private mResult As Result
    Private mCustomText As String
    Private mPosition As Single

    Private delayUpdateTimer As New Timer(Sub() Me.Invoke(New MethodInvoker(AddressOf UpdateUI)), Nothing, Timeout.Infinite, Timeout.Infinite)

    Private Sub ResultLabel_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.Selectable, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.UserPaint, True)

        AddHandler Me.SizeChanged, AddressOf DelayUpdate
        AddHandler lblPercentage.TextChanged, AddressOf DelayUpdate
    End Sub

    Private Sub DelayUpdate()
        delayUpdateTimer.Change(100, Timeout.Infinite)
    End Sub

    Private Sub UpdateUI()
        lblPercentage.Left = Me.Width - lblPercentage.Width - Me.Padding.Right - lblPercentage.Margin.Right
        lblTrack.Width = Me.Width - lblPercentage.Width - Me.Padding.Horizontal - lblTrack.Margin.Right - lblPercentage.Margin.Left

        lblTrack.Top = ((Me.Height - Me.Padding.Vertical) - (lblTrack.Height - lblTrack.Margin.Vertical)) / 2
        lblPercentage.Top = lblTrack.Top
    End Sub

    Private Sub UpdateText()
        If mCustomText = "" Then
            If mResult Is Nothing OrElse mResult.Track Is Nothing Then
                lblTrack.Text = "Unknown Artist - Unknown Track"
                lblPercentage.Text = "0%"
            Else
                lblTrack.Text = mResult.NiceFileName

                Dim errorLevel = If(mResult.ErrorLevel = Double.MaxValue, errorMax, mResult.ErrorLevel)
                lblPercentage.Text = ((1.0 - errorLevel / errorMax) * 100.0).ToString("F2") + "%"
            End If
        Else
            lblTrack.Text = mCustomText
            lblPercentage.Text = ""
        End If

        Me.Invalidate()
    End Sub

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Result As Result
        Get
            Return mResult
        End Get
        Set(value As Result)
            mResult = value
            mCustomText = ""
            mPosition = 0

            UpdateText()
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Position As Single
        Get
            Return mPosition
        End Get
        Set(value As Single)
            mPosition = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CustomText As String
        Get
            Return mCustomText
        End Get
        Set(value As String)
            mCustomText = value
            mPosition = 0

            UpdateText()
        End Set
    End Property

    Private Sub ResultLabel_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g = e.Graphics
        Dim r = Me.DisplayRectangle
        r.Width -= 1
        r.Height -= 1

        If mPosition <> 0 AndAlso mResult IsNot Nothing Then
            Using b As New SolidBrush(Color.FromArgb(100, If(mResult.IsSet, Color.LightBlue, Color.LightGray)))
                g.FillRectangle(b, 0, 0, r.Width * mPosition, r.Height)
            End Using

            For i As Integer = 0 To mResult.ErrorCount - 1
                g.FillEllipse(Brushes.Red, 7 * (i + 2) - 6, r.Height - 8, 7, 7)
            Next
        End If

        g.DrawRectangle(Pens.LightGray, r)
    End Sub
End Class

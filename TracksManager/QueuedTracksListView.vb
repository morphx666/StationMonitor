Imports System.Runtime.CompilerServices
Imports System.ComponentModel

Public Class QueuedTracksListView
    Private mSortingColumn As ColumnHeader
    Private mSorter As IComparer
    Private mHeaderHeight As Integer
    Private mInsertAfter As ListViewItem
    Private mGridColor As Color = Color.Black
    Private mGridLinesStyle As GridLinesStyles = GridLinesStyles.Both
    Private mSelectedItemBackColor As Color = Color.FromArgb(94, 99, 100)
    Private mHeaderBackColor As Color = Color.FromArgb(50, 52, 54)
    Private mInsetList As Boolean = False
    Private mInsertAfterIndicator As Color = Color.FromArgb(192, 82, 0)
    Private mIsBusy As Boolean
    Private mEnableRendering As Boolean = True
    Private mItemsDictionary As Dictionary(Of String, ListViewItem) = New Dictionary(Of String, ListViewItem)

    Public Enum GridLinesStyles
        Both = 0
        Horizontal = 1
        Vertical = 2
    End Enum

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)

        Me.SmallImageList = New ImageList With {.ImageSize = New Size(1, 20)}
    End Sub

    <Category("Appearance")>
    Public Property SelectedItemBackColor() As Color
        Get
            Return mSelectedItemBackColor
        End Get
        Set(ByVal value As Color)
            mSelectedItemBackColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property GridLineStyle() As GridLinesStyles
        Get
            Return mGridLinesStyle
        End Get
        Set(ByVal value As GridLinesStyles)
            mGridLinesStyle = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property GridLinesColor() As Color
        Get
            Return mGridColor
        End Get
        Set(ByVal value As Color)
            mGridColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property EnableRendering() As Boolean
        Get
            Return mEnableRendering
        End Get
        Set(ByVal value As Boolean)
            If mEnableRendering = False And value = True Then
                mEnableRendering = True
                Me.Invalidate()
            Else
                mEnableRendering = value
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property InsetList() As Boolean
        Get
            Return mInsetList
        End Get
        Set(ByVal value As Boolean)
            mInsetList = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property InsertAfterIndicator() As Color
        Get
            Return mInsertAfterIndicator
        End Get
        Set(ByVal value As Color)
            mInsertAfterIndicator = value
        End Set
    End Property

    <Category("Appearance")>
    Public Property HeaderBackColor() As Color
        Get
            Return mHeaderBackColor
        End Get
        Set(ByVal value As Color)
            mHeaderBackColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property IsBusy() As Boolean
        Get
            Return mIsBusy
        End Get
        Set(ByVal value As Boolean)
            mIsBusy = value
        End Set
    End Property

    Public ReadOnly Property HeaderHeight() As Integer
        Get
            Return mHeaderHeight
        End Get
    End Property

    Public Sub DisableSorting()
        mSorter = Me.ListViewItemSorter
        Me.ListViewItemSorter = Nothing
    End Sub

    Public Sub EnableSorting()
        Me.ListViewItemSorter = mSorter
        Me.Sort()
    End Sub

    Public Property InsertAfter() As ListViewItem
        Get
            Return mInsertAfter
        End Get
        Set(ByVal value As ListViewItem)
            mInsertAfter = value
            Me.Invalidate()
        End Set
    End Property

    'Public Overloads Sub AutoResizeColumns(ByVal headerAutoResize As ColumnHeaderAutoResizeStyle)
    '    Me.SetStyle(ControlStyles.UserPaint, False)
    '    Me.Font = New Font(Me.Font, Me.Font.Style)
    '    Me.SetStyle(ControlStyles.UserPaint, True)

    '    MyBase.AutoResizeColumns(headerAutoResize)
    'End Sub

    Public Sub SetItemsFont(ByVal font As Font)
        For Each item As ListViewItem In Me.Items
            item.Font = font
        Next
    End Sub

    Public Function ItemsDictionary() As Dictionary(Of String, ListViewItem)
        Return mItemsDictionary
    End Function

    Public Sub RemoveItem(ByVal item As ListViewItem)
        mItemsDictionary.Remove(item.Name)
        Me.Items.Remove(item)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Not mEnableRendering Then Exit Sub

        Dim g As Graphics = e.Graphics

        Dim fvi As ListViewItem = Me.GetItemAt(1, 6) 'Me.GetItemAt(r.Left, r.Top)
        Dim lvi As ListViewItem = Me.GetItemAt(1, Me.DisplayRectangle.Height - 5) 'Me.GetItemAt(r.Left, r.Bottom - 6)

        Dim lastY As Integer
        Dim itemHeight As Integer

        If fvi IsNot Nothing Then
            If lvi Is Nothing Then lvi = Me.Items(Me.Items.Count - 1)
            If lvi Is Nothing Then Exit Sub

            Dim fv As Integer = fvi.Index
            Dim lv As Integer = lvi.Index
            Dim item As ListViewItem
            Dim itemState As ListViewItemStates
            Dim itemBackColor As Color

            For i As Integer = fv To lv
                item = Me.Items(i)
                itemState = If(item.Selected, ListViewItemStates.Selected, ListViewItemStates.Default)

                itemHeight = Math.Max(itemHeight, item.Bounds.Height)
                lastY = item.Bounds.Top

                itemBackColor = If((itemState And ListViewItemStates.Selected) = ListViewItemStates.Selected,
                    mSelectedItemBackColor,
                    If(item.BackColor = Me.BackColor, Color.Transparent, item.BackColor))
                Dim area As Rectangle = item.Bounds
                area.Width -= 4
                area.Height -= 1
                area.X += 2

                g.FillRectangle(New SolidBrush(itemBackColor), area)
                MyBase.OnDrawItem(New DrawListViewItemEventArgs(g, item, area, item.Index, itemState))

                If Me.GridLines Then DrawGridLines(g, item.Bounds, item)
            Next
        Else
            itemHeight = g.MeasureString("X", Me.Font).Height + 2

            If Me.HeaderStyle = ColumnHeaderStyle.None Then
                lastY = 0
            Else
                lastY += 5
            End If

            If Me.GridLines Then itemHeight += 1
        End If

        If Me.GridLines AndAlso itemHeight > 0 Then
            For y As Integer = lastY + itemHeight To Me.DisplayRectangle.Height Step itemHeight
                DrawGridLines(g, New Rectangle(0, y, Me.DisplayRectangle.Width, itemHeight))
            Next
        End If

        If mInsetList Then DrawInset(g)

        'MyBase.OnPaint(e)
    End Sub

    Private Sub DrawInset(ByVal g As Graphics)
        Dim r As Rectangle = Me.DisplayRectangle
        r.Y += mHeaderHeight

        r.Width -= 1
        r.Height -= 1 + r.Y


        Dim p As Pen
        For i As Integer = 4 To 1 Step -1
            p = New Pen(Color.FromArgb(CInt(If(i = 4, 255, 255 * i / 12)), 0, 0, 0))
            g.DrawRectangle(p, r)
            p.Dispose()

            r.X += 1
            r.Y += 1

            r.Width -= 2
            r.Height -= 2
        Next
    End Sub

    Private Sub DrawGridLines(ByVal g As Graphics, ByVal r As Rectangle, Optional ByVal item As ListViewItem = Nothing)
        Dim leftPos As Integer = r.X
        Dim p As Pen = New Pen(mGridColor)

        If item IsNot Nothing AndAlso mInsertAfter IsNot Nothing AndAlso mInsertAfter.Index = item.Index Then
            g.DrawLine(New Pen(mInsertAfterIndicator), 0, r.Bottom - 1, r.Width, r.Bottom - 1)
        Else
            If mGridLinesStyle <> GridLinesStyles.Vertical Then
                g.DrawLine(p, 0, r.Bottom - 1, r.Width, r.Bottom - 1)
            End If
        End If

        If mGridLinesStyle <> GridLinesStyles.Horizontal Then
            For si As Integer = 0 To Me.Columns.Count - 1
                Dim colIdx As Integer = si
                Dim col As ColumnHeader = (From c As ColumnHeader In Me.Columns Select c Where c.DisplayIndex = colIdx).First()
                leftPos += col.Width
                g.DrawLine(p, leftPos, r.Top, leftPos, r.Bottom)
            Next
        End If
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
        If Not mEnableRendering Then Exit Sub

        pevent.Graphics.Clear(Me.BackColor)
        If Me.BackgroundImage IsNot Nothing Then
            pevent.Graphics.DrawImageUnscaled(Me.BackgroundImage, 0, 0)
        End If
    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As DrawListViewItemEventArgs)
        If Not mEnableRendering Then Exit Sub

        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnDrawSubItem(ByVal e As DrawListViewSubItemEventArgs)
        If Not mEnableRendering Then Exit Sub

        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnDrawColumnHeader(ByVal e As DrawListViewColumnHeaderEventArgs)
        If Not mEnableRendering Then Exit Sub

        MyBase.OnDrawColumnHeader(e)
    End Sub

    Public Shadows Property Sorting() As SortOrder
        Get
            Return MyBase.Sorting
        End Get
        Set(ByVal value As SortOrder)
            MyBase.Sorting = value
            ReSort()
        End Set
    End Property

    <Browsable(False)>
    Public Property SortingColumnIndex() As Integer
        Get
            Return If(mSortingColumn IsNot Nothing, mSortingColumn.Index, -1)
        End Get
        Set(ByVal value As Integer)
            If value >= 0 AndAlso value < Me.Columns.Count Then
                mSortingColumn = Me.Columns(value)
                ReSort()
            End If
        End Set
    End Property

    Private Sub ReSort()
        xfxListView_ColumnClick(mSortingColumn, New ColumnClickEventArgs(mSortingColumn.Index))
    End Sub

    Private Sub XfxListView_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles Me.ColumnClick
        ' Get the new sorting column.
        Dim newSortingColumn As ColumnHeader = Me.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sortOrder As SortOrder
        If mSortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sortOrder = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If newSortingColumn.Equals(mSortingColumn) Then
                ' Same column. Switch the sort order.
                sortOrder = If(CInt(mSortingColumn.Tag) = 1, SortOrder.Descending, SortOrder.Ascending)
            Else
                ' New column. Sort ascending.
                sortOrder = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            'mSortingColumn.Text = mSortingColumn.Text.Substring(2)
            mSortingColumn.Tag = Nothing
        End If

        ' Display the new sort order.
        mSortingColumn = newSortingColumn
        mSortingColumn.Tag = If(sortOrder = SortOrder.Ascending, 1, 0)

        ' Create a comparer.
        Me.ListViewItemSorter = New ListViewComparer(e.Column, sortOrder)

        ' Sort.
        Me.Sort()
    End Sub

    Private Sub ListViewPlus_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles Me.DrawColumnHeader
        If Me.HeaderStyle <> ColumnHeaderStyle.None Then
            Dim g As Graphics = e.Graphics
            Dim r As Rectangle = e.Bounds
            Dim foreColor As SolidBrush = New SolidBrush(Me.ForeColor)
            Dim sf As StringFormat = New StringFormat(StringFormatFlags.NoWrap)

            Dim area As Rectangle = New Rectangle(r.Left + 2,
                                                 r.Height \ 2 - g.MeasureString(e.Header.Text, Me.Font).ToSize.Height \ 2,
                                                r.Width,
                                                r.Height)

            Select Case Me.Columns(e.ColumnIndex).TextAlign
                Case HorizontalAlignment.Left
                    sf.Alignment = StringAlignment.Near
                Case HorizontalAlignment.Center
                    sf.Alignment = StringAlignment.Center
                Case HorizontalAlignment.Right
                    sf.Alignment = StringAlignment.Far
            End Select

            Using b As SolidBrush = New SolidBrush(mHeaderBackColor)
                g.FillRectangle(b, r)
            End Using

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

            Dim textArea As Rectangle = area
            If Me.Columns(e.ColumnIndex).TextAlign = HorizontalAlignment.Right Then textArea.X -= 8
            If mSortingColumn IsNot Nothing AndAlso mSortingColumn.Index = e.ColumnIndex AndAlso mSortingColumn.TextAlign = HorizontalAlignment.Right Then
                textArea.X -= 16
            End If
            g.DrawString(e.Header.Text, Me.Font, foreColor, textArea, sf)

            If e.Header.Index > 0 Then
                Using p As Pen = New Pen(mGridColor)
                    g.DrawLine(p, r.Left, r.Top, r.Left, r.Bottom)
                End Using
            End If

            If e.Header.Tag IsNot Nothing Then
                Dim p1 As Point
                Dim p2 As Point
                Dim p3 As Point
                If CInt(e.Header.Tag) = 1 Then
                    p1 = New Point(r.Right - 12, r.Top + 12)
                    p2 = New Point(p1.X - 6, p1.Y)
                    p3 = New Point(p1.X - 3, p1.Y + 5)
                Else
                    p1 = New Point(r.Right - 12, r.Top + 12 + 5)
                    p2 = New Point(p1.X - 6, p1.Y)
                    p3 = New Point(p1.X - 3, p1.Y - 5)
                End If
                Using b As SolidBrush = New SolidBrush(Me.ForeColor)
                    g.FillPolygon(b, New Point() {p1, p2, p3})
                End Using
            End If
            foreColor.Dispose()

            mHeaderHeight = r.Height
        Else
            mHeaderHeight = 0
        End If
    End Sub

    Private Sub ListViewPlus_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs) Handles Me.DrawItem
        Dim r As Rectangle = e.Item.Bounds
        Dim itemBackColor = If((e.State And ListViewItemStates.Selected) = ListViewItemStates.Selected,
            New SolidBrush(mSelectedItemBackColor),
            New SolidBrush(e.Item.BackColor))

        If Me.CheckBoxes Then
            Dim m As Integer = 2
            Dim chkRect As Rectangle = New Rectangle(r.X + m, r.Y + m, 16 - m, r.Height - m * 2)
            ControlPaint.DrawCheckBox(e.Graphics, chkRect, IIf(e.Item.Checked, ButtonState.Checked, ButtonState.Normal) Or ButtonState.Flat)
            r.X += 16
        End If

        DrawItemText(e.Graphics, e.Item.Text, e.Item.ForeColor, itemBackColor, e.Item.Font, r, 0, e.Item)

        For Each c As ColumnHeader In Me.Columns
            Try
                ListViewPlus_DrawSubItem(Me, New DrawListViewSubItemEventArgs(e.Graphics, e.Item.SubItems(c.Index).Bounds, e.Item, e.Item.SubItems(c.Index), e.ItemIndex, -c.Index, c, e.State))
            Catch
            End Try
        Next

        itemBackColor.Dispose()
    End Sub

    Private Sub ListViewPlus_DrawSubItem(ByVal sender As Object, ByVal e As DrawListViewSubItemEventArgs) Handles Me.DrawSubItem
        Dim colIndex As Integer = e.ColumnIndex
        Dim itemBackColor As SolidBrush

        Dim r As Rectangle = e.SubItem.Bounds

        If colIndex < 0 Then
            colIndex = Math.Abs(colIndex)

            itemBackColor = If((e.ItemState And ListViewItemStates.Selected) = ListViewItemStates.Selected,
                New SolidBrush(mSelectedItemBackColor),
                If(e.Item.UseItemStyleForSubItems, New SolidBrush(e.Item.BackColor), New SolidBrush(e.SubItem.BackColor)))

            If e.Item.UseItemStyleForSubItems Then
                DrawItemText(e.Graphics, e.SubItem.Text, e.Item.ForeColor, itemBackColor, e.Item.Font, e.Bounds, colIndex, e.Item)
            Else
                DrawItemText(e.Graphics, e.SubItem.Text, e.SubItem.ForeColor, itemBackColor, e.SubItem.Font, e.Bounds, colIndex, e.Item)
            End If

            itemBackColor.Dispose()
        End If
    End Sub

    Private Sub DrawItemText(ByVal g As Graphics, ByVal text As String, ByVal foreColor As Color, ByVal backColor As SolidBrush, ByVal font As Font, ByVal r As Rectangle, ByVal columnIndex As Integer, ByVal item As ListViewItem)
        Dim sf As StringFormat = New StringFormat With {.FormatFlags = StringFormatFlags.NoWrap}

        Dim area As Rectangle = New Rectangle(r.Left + 1,
                                    r.Top,
                                    Me.Columns(columnIndex).Width - 1,
                                    r.Height - 1)

        Dim offset As Integer = r.Height \ 2 - TextRenderer.MeasureText(text, font).Height \ 2
        area.Y = r.Top + offset - 1

        Select Case Me.Columns(columnIndex).TextAlign
            Case HorizontalAlignment.Left
                sf.Alignment = StringAlignment.Near
                area.X += offset
            Case HorizontalAlignment.Center
                sf.Alignment = StringAlignment.Center
            Case HorizontalAlignment.Right
                area.Width -= offset
                sf.Alignment = StringAlignment.Far
        End Select

        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        g.DrawString(text, font, New SolidBrush(foreColor), area, sf)
    End Sub

#Region "Auto Resize Last Column"
    Private lastSize As Size = New Size(0, 0)
    Private columnsLastWidth As List(Of Integer) = New List(Of Integer)
    Private disableAutoResize As Boolean
    Private delayAutoResize As Threading.Timer = New Threading.Timer(New Threading.TimerCallback(AddressOf AutoResizeFromTimer))

    Private Sub ListView_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Not mEnableRendering Then Exit Sub

        If delayAutoResize IsNot Nothing Then
            If Not disableAutoResize Then
                If lastSize <> Me.Size Then
                    lastSize = Me.Size
                    delayAutoResize.Change(250, Threading.Timeout.Infinite)
                End If
            End If
        End If

        CreateBackgroundImage()
    End Sub

    Private Sub CreateBackgroundImage()
        If Me.BackgroundImage IsNot Nothing Then Me.BackgroundImage.Dispose()
        Try
            Dim r As Rectangle = Me.DisplayRectangle
            Me.BackgroundImage = New Bitmap(r.Width, r.Height)
            Dim g As Graphics = Graphics.FromImage(Me.BackgroundImage)
            g.Clear(Me.BackColor)

            r.Y += mHeaderHeight
            r.Height -= r.Y
            r.Inflate(-1, -1)

            For n As Integer = 0 To 4
                r.Offset(n / 4, n / 4)
                g.DrawRectangle(New Pen(Color.FromArgb(255 - n * 32, n * 8, n * 8, n * 8)), r)
            Next
            g.Dispose()
        Catch
        End Try
    End Sub

    Private Sub ListView_ColumnWidthChanged(ByVal sender As Object, ByVal e As ColumnWidthChangedEventArgs) Handles Me.ColumnWidthChanged
        If Not mEnableRendering Then Exit Sub

        If delayAutoResize IsNot Nothing Then
            If disableAutoResize Then
                disableAutoResize = False
            Else
                Dim foreceAutoResize As Boolean = False
                If columnsLastWidth.Count <> Me.Columns.Count Then
                    foreceAutoResize = True
                    columnsLastWidth.Clear()
                    For Each col As ColumnHeader In Me.Columns
                        columnsLastWidth.Add(col.Width)
                    Next
                End If

                If columnsLastWidth(e.ColumnIndex) <> Me.Columns(e.ColumnIndex).Width OrElse foreceAutoResize Then
                    foreceAutoResize = False

                    columnsLastWidth(e.ColumnIndex) = Me.Columns(e.ColumnIndex).Width
                    delayAutoResize.Change(100, Threading.Timeout.Infinite)
                End If
            End If
        End If
    End Sub

    Private Delegate Sub SafeAutoResizeDel()
    Private Sub AutoResizeFromTimer()
        If Me.Created Then Me.Invoke(New SafeAutoResizeDel(AddressOf AutoResizeLastColumn))
    End Sub

    Private Sub AutoResizeLastColumn()
        disableAutoResize = True
        If Me.Columns.Count = 0 Then Exit Sub

        DoAutoResize()
    End Sub

    Private Sub DoAutoResize()
        Me.Columns(Me.Columns.Count - 1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
        If Me.Columns.Count = 1 Then
            disableAutoResize = True
            Me.Columns(Me.Columns.Count - 1).Width -= 2
        End If
    End Sub
#End Region

    Private Class ListViewComparer
        Implements IComparer

        Private ReadOnly mColumnNumber As Integer
        Private ReadOnly mSortOrder As SortOrder

        Public Sub New(ByVal columnNumber As Integer, ByVal sortOrder As SortOrder)
            mColumnNumber = columnNumber
            mSortOrder = sortOrder
        End Sub

        ' Compare the items in the appropriate column
        ' for objects x and y.
        Public Function Compare(ByVal i1 As Object, ByVal i2 As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim item1 As ListViewItem = DirectCast(i1, ListViewItem)
            Dim item2 As ListViewItem = DirectCast(i2, ListViewItem)

            Dim string1 As String
            Dim string2 As String

            string1 = If(item1.SubItems.Count <= mColumnNumber, "", item1.SubItems(mColumnNumber).Text)

            string2 = If(item2.SubItems.Count <= mColumnNumber, "", item2.SubItems(mColumnNumber).Text)

            If mSortOrder = SortOrder.Descending Then
                Dim tmp As String
                tmp = string1
                string1 = string2
                string2 = tmp
            End If

            If string1.IsNumeric() AndAlso string2.IsNumeric() Then
                Return Val(string1).CompareTo(Val(string2))
            ElseIf string1.IsDate() AndAlso string2.IsDate() Then
                Return CDate(string1).CompareTo(CDate(string2))
            Else
                Return String.Compare(string1, string2)
            End If
        End Function
    End Class
End Class

Module Extensions
    <Extension()>
    Public Function IsNumeric(ByVal [string] As String) As Boolean
        Dim tmp As Decimal
        Return Decimal.TryParse([string], tmp)
    End Function

    <Extension()>
    Public Function IsDate(ByVal [string] As String) As Boolean
        Dim tmp As DateTime
        Return DateTime.TryParse([string], tmp)
    End Function
End Module

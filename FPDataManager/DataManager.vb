Public Class DataManager
    Implements IDisposable

    Private fpData As fpdataEntities
    Private Const MAX_MEM As Long = 1024 * 1024 * 1024
    Private lastMemoryCheck As DateTime

    Public Sub New()
        lastMemoryCheck = Now
        CreateContext()
    End Sub

    Public Function SaveAndRenewContext() As Boolean
        Return CreateContext()
    End Function

    Public ReadOnly Property Data As fpdataEntities
        Get
            Return fpData
        End Get
    End Property

    Private Function CreateContext() As Boolean
        Dim result As Boolean = False
        Dim checkMemoryCondition As Boolean = (Now - lastMemoryCheck).TotalSeconds > 10

        If fpData Is Nothing Then
            result = True
        Else
            fpData.SaveChanges()

            If checkMemoryCondition AndAlso My.Application.Info.WorkingSet > MAX_MEM Then
                fpData.Dispose()
                fpData = Nothing
                GC.Collect()

                lastMemoryCheck = Now
                result = True
            End If
        End If

        If result Then fpData = New fpdataEntities()

        Return result
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                fpData.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.

            ' Moved to HashLib's Dispose()
            'Un4seen.Bass.Bass.BASS_PluginFree(0)
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

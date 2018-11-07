Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

Partial Public Class UserDefinedFunctions
    <SqlFunction(IsDeterministic:=True, IsPrecise:=False)>
    Public Shared Function Levenshtein(str1 As SqlString, str2 As SqlString) As SqlDouble
        Dim s1 = str1.Value
        Dim s2 = str2.Value

        Dim n = s1.Length
        Dim m = s1.Length

        Dim d(n + 1, m + 1) As Integer
        Dim cost = 0

        For i = 0 To n
            d(i, 0) = i
        Next
        For j = 0 To m
            d(0, j) = j
        Next

        For i = 1 To n
            For j = 1 To m
                If s1(i - 1) = s2(j - 1) Then
                    cost = 0
                Else
                    cost = 1
                End If

                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next

        Return Math.Round((1.0 - (d(n, m) / Math.Max(n, m))) * 100, 2)
    End Function

    '<Microsoft.SqlServer.Server.SqlFunction(IsDeterministic:=True, IsPrecise:=False)>
    'Public Shared Function HammingDistance(hash1 As String, hash2 As String) As SqlDouble
    '    Dim d As Integer = 9
    '    For i As Integer = 0 To 8
    '        If hash1(i) <> hash2(i) Then d -= 1
    '    Next
    '    Return d
    'End Function

    <SqlFunction(IsDeterministic:=True, IsPrecise:=False)>
    Public Shared Function HammingDistance(hash1 As Integer, hash2 As Integer) As SqlInt32
        Dim distance As Integer = 0
        Dim hammingWeigth As Integer = (hash1 Xor hash2) '>> 2 ' Ignore the first few bits which belong to the high frequencies
        Do While hammingWeigth > 0
            distance += 1
            hammingWeigth = hammingWeigth And (hammingWeigth - 1)
        Loop

        Return distance
    End Function
End Class

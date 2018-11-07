Imports NDXVUMeterNET.FFT
Imports System.Math
Imports NDXVUMeterNET
Imports DotNetMatrix

Public Class MFCC
    Private windowSize As Integer
    Private windowSize2 As Integer
    Private sampleRate As Integer
    Private baseFreq As Integer

    Private minFreq As Double
    Private maxFreq As Double
    Private numberFilters As Integer

    Private numberCoefficients As Integer
    Private useFirstCoefficient As Boolean

    Private dctMatrix As GeneralMatrix
    Private melFilterBanks As GeneralMatrix
    Private scale As Double

    Private log10 As Double

    Public Sub New(sampleRate As Integer)
        Me.New(sampleRate, FFT.FFTSizeConstants.FFTs512, 20, True, 20.0, 16000.0, 40)
    End Sub

    Public Sub New(sampleRate As Integer, windowSize As FFT.FFTSizeConstants, numberCoefficients As Integer, useFirstCoefficient As Boolean)
        Me.New(sampleRate, windowSize, numberCoefficients, useFirstCoefficient, 20.0, 16000.0, 40)
    End Sub

    Public Sub New(sampleRate As Integer, windowSize As FFT.FFTSizeConstants, numberCoefficients As Integer, useFirstCoefficient As Boolean, minFreq As Double, maxFreq As Double, numberFilters As Integer)
        Me.sampleRate = sampleRate
        Me.windowSize = windowSize
        Me.windowSize2 = windowSize / 2
        Me.baseFreq = sampleRate / windowSize

        Me.numberCoefficients = numberCoefficients
        Me.useFirstCoefficient = useFirstCoefficient

        Me.minFreq = minFreq
        Me.maxFreq = maxFreq
        Me.numberFilters = numberFilters

        ' Store filter weights and DCT matrix due to performance reason
        melFilterBanks = GetMelFilterBanks()
        dctMatrix = GetDCTMatrix()

        ' Compute rescale factor to rescale and normalize at once (default is 96dB = 2^16)
        scale = (Math.Pow(10, 96 / 20))
        log10 = 10 * (1 / Math.Log(10))
    End Sub

    Private Function GetMelFilterBankBoundaries(minFreq As Double, maxFreq As Double, numberFilters As Integer) As Double()
        Dim centers(numberFilters + 2 - 1) As Double
        Dim maxFreqMel As Double
        Dim minFreqMel As Double
        Dim deltaFreqMel As Double
        Dim nextCenterMel As Double

        ' Compute Mel min/max frequency
        maxFreqMel = LinToMelFreq(maxFreq)
        minFreqMel = LinToMelFreq(minFreq)
        deltaFreqMel = (maxFreqMel - minFreqMel) / (numberFilters + 1)

        ' Create (numberFilters + 2) equidistant points for the triangles
        nextCenterMel = minFreqMel
        For i = 0 To centers.Length - 1
            ' transform the points back to linear scale
            centers(i) = MelToLinFreq(nextCenterMel)
            nextCenterMel += deltaFreqMel
        Next

        ' Adjust boundaries to exactly fit the given min./max. frequency
        centers(0) = minFreq
        centers(numberFilters + 1) = maxFreq

        Return centers
    End Function

    Private Function GetMelFilterBanks() As GeneralMatrix
        ' Get boundaries of the different filters
        Dim boundaries() As Double = GetMelFilterBankBoundaries(minFreq, maxFreq, numberFilters)

        ' Ignore filters outside of spectrum
        For i = 1 To boundaries.Length - 1 - 1
            If boundaries(i) > sampleRate / 2 Then
                numberFilters = i - 1
                Exit For
            End If
        Next

        ' Create the filter bank matrix
        Dim matrix(numberFilters - 1)() As Double

        ' Fill each row of the filter bank matrix with one triangular Mel filter
        For i As Integer = 1 To numberFilters
            Dim filter(windowSize2) As Double
            ' For each frequency of the FFT
            For j = 0 To filter.Length - 1
                ' Compute the filter weight of the current triangular Mel filter
                Dim freq As Double = baseFreq * j
                filter(j) = GetMelFilterWeight(i, freq, boundaries)
            Next
            ' Add the computed Mel filter to the filter bank
            matrix(i - 1) = filter
        Next

        ' return the filter bank
        Return New GeneralMatrix(matrix, numberFilters, windowSize2 + 1)
    End Function

    Private Function GetMelFilterWeight(filterBank As Integer, freq As Double, boundaries() As Double) As Double
        ' For most frequencies the filter weight is 0
        Dim result As Double = 0

        ' Compute start- , center- and endpoint as well as the height of the filter
        Dim start As Double = boundaries(filterBank - 1)
        Dim center As Double = boundaries(filterBank)
        Dim [end] As Double = boundaries(filterBank + 1)
        Dim height As Double = 2 / ([end] - start)

        ' Is the frequency within the triangular part of the filter
        If freq >= start AndAlso freq <= [end] Then
            ' Depending on frequency position within the triangle
            If freq < center Then
                ' ...use a ascending linear function
                result = (freq - start) * (height / (center - start))
            Else
                ' ..use a descending linear function
                result = height + ((freq - center) * (-height / ([end] - center)))
            End If
        End If

        Return result
    End Function

    Private Function LinToMelFreq(inputFreq As Double) As Double
        Return (2595.0 * (Math.Log(1.0 + inputFreq / 700.0) / Math.Log(10.0)))
    End Function

    Private Function MelToLinFreq(inputFreq As Double) As Double
        Return (700.0 * (Math.Pow(10.0, (inputFreq / 2595.0)) - 1.0))
    End Function

    Private Function GetDCTMatrix() As GeneralMatrix
        ' Compute constants
        Dim k As Double = Math.PI / numberFilters
        Dim w1 As Double = 1.0 / (Math.Sqrt(numberFilters))
        Dim w2 As Double = Math.Sqrt(2.0 / numberFilters)

        ' Create new matrix
        Dim matrix As New GeneralMatrix(numberCoefficients, numberFilters)

        ' Generate DCT matrix
        For i = 0 To numberCoefficients - 1
            For j = 0 To numberFilters - 1
                If i = 0 Then
                    matrix.SetElement(i, j, w1 * Math.Cos(k * i * (j + 0.5)))
                Else
                    matrix.SetElement(i, j, w2 * Math.Cos(k * i * (j + 0.5)))
                End If
            Next
        Next

        ' Adjust index if we are using first coefficient
        If Not useFirstCoefficient Then matrix = matrix.getMatrix(1, numberCoefficients - 1, 0, numberFilters - 1)

        Return matrix
    End Function

    Public Function ProcessFFT(fftData() As Double) As Double()
        Dim mfcc As New List(Of Double())

        For i As Integer = 0 To fftData.Length - 1
            fftData(i) *= scale
        Next

        ' Use all coefficients up to the nyquist frequency (ceil((fftSize+1)/2))
        Dim x As GeneralMatrix = New GeneralMatrix(fftData, windowSize)
        x = x.GetMatrix(0, windowSize2, 0, 0) ' fftSize-1 is the index of the nyquist frequency

        ' Apply Mel filter banks
        x = melFilterBanks.Multiply(x)

        x.ThrunkAtLowerBoundary(1)
        x.LogEquals()
        x.MultiplyEquals(log10)

        ' Compute DCT
        x = dctMatrix.Multiply(x)

        Return x.ColumnPackedCopy()
    End Function

    Public Shared Function ChiSquaredDistance(x As Double, y As Double) As Double
        Return (x - y) ^ 2 / (2 * (x + y))
    End Function

    Public Shared Function EuclideanDistance(v1() As Double, v2() As Double) As Double
        Dim d As Double = 0
        For i As Integer = 1 To v1.Length - 2
            d += (v1(i) - v2(i)) ^ 2
        Next
        Return Math.Sqrt(d)
    End Function

    Public Shared Sub NormalizeVectors(v()() As Double, Optional scaleMin As Double = -1, Optional scaleMax As Double = 1)
        Dim valueMax As Double = Double.MinValue
        Dim valueMin As Double = Double.MaxValue
        Dim valueRange As Double

        Dim scaleRange As Double = scaleMax - scaleMin

        Dim numVectors As Integer = v.Length - 1
        Dim vectorLen As Integer = v(0).Length - 1

        For i = 0 To numVectors
            For j = 0 To vectorLen
                valueMax = Math.Max(v(i)(j), valueMax)
                valueMin = Math.Min(v(i)(j), valueMin)
            Next
        Next
        valueRange = valueMax - valueMin

        For i = 0 To numVectors
            For j = 0 To vectorLen
                v(i)(j) = ((scaleRange * (v(i)(j) - valueMin)) / valueRange) + scaleMin
            Next
        Next
    End Sub
End Class
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class test

    Private Sub Test()
        Dim inputFile As String = "e:\temp\a.jpg"

        Dim outputFile As String = "e:\temp\b.jpg"

        'create new bitmap 

        Dim bmp As Bitmap
        bmp = New Bitmap("D:\testOmrclass\doc00721620180524110738_001.jpg")
        Dim rect = New Rectangle(0, 0, bmp.Width, bmp.Height)

        Dim data = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat)
        Dim depth = (Bitmap.GetPixelFormatSize(data.PixelFormat) / 8)
        'bytes per pixel
        Dim buffer = New Byte(((data.Width * (data.Height * depth))) - 1) {}

        'copy pixels to buffer
        Marshal.Copy(data.Scan0, buffer, 0, buffer.Length)
        Parallel.Invoke(
                           Sub()
                               ' Param #1 - lambda expression
                               Process(buffer, 0, 0, (data.Width / 2), (data.Height / 2), data.Width, depth)
                           End Sub,
                           Sub()
                               ' Param #2 - in-line delegate
                               Process(buffer, (data.Width / 2), (data.Height / 2), data.Width, data.Height, data.Width, depth)
                           End Sub)



        Marshal.Copy(buffer, 0, data.Scan0, buffer.Length)
        bmp.UnlockBits(data)
        bmp.Save(outputFile, ImageFormat.Jpeg)
    End Sub

    Private Sub Process(ByVal buffer() As Byte, ByVal x As Integer, ByVal y As Integer, ByVal endx As Integer, ByVal endy As Integer, ByVal width As Integer, ByVal depth As Integer)
        Dim i As Integer = x
        Do While (i < endx)
            Dim j As Integer = y
            Do While (j < endy)
                Dim offset = (((j * width) _
                            + i) _
                            * depth)
                ' Dummy work    
                ' To grayscale (0.2126 R + 0.7152 G + 0.0722 B)
                Dim b = ((0.2126 * buffer((offset + 0))) _
                            + ((0.7152 * buffer((offset + 1))) + (0.0722 * buffer((offset + 2)))))
                buffer((offset + 2)) = CType(b, Byte)
                buffer((offset + 1)) = CType(b, Byte)
                buffer((offset + 0)) = CType(b, Byte)
                j = (j + 1)
            Loop

            i = (i + 1)
        Loop

    End Sub
End Class

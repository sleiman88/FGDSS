Imports AForge.Imaging.Filters

Public Class gdssomr

    Public lastScanId As Int32
    Dim NewSave As SaveToDB
    Dim _error = True
    Public Lfinish, Rfinish As Boolean

    Public Event omrdetectdone()
    Public Event omrdetecterror()
    Public PaperError As Boolean

    Public imgpath = ""
    Dim threashpers = 0.2
    Public omrbooklet(5) As String
    Public omrques(20, 5) As String
    Public omrid(10, 5) As String
    Public resomrbookel As String
    Public resomrques(20) As String
    Public resomrid(5) As String
    'Dim qsx = 440, qsdx = 130, qsy = 365, qsdy = 127
    Dim qsx = 340, qsdx = 130, qsy = 300, qsdy = 127
    Dim idsx = 636, idsdx = 145, idsy = 1630, idsdy = 128
    Dim booklx = 1220, bookldx = 127, bookly = 585
    ' Dim booklx = 1420, bookldx = 127, bookly = 885

    Private PctSourceImage As PictureBox
    Private PctOutputImage As PictureBox
    Private SourcePath As String
    Private OutputBitmap As Bitmap

    Public bmp As Bitmap
    Public Color As Bitmap
    Public igtodetect As Bitmap

    Public leftcorner = False
    Public rightcorner = False
    Dim toplx As Integer = 0
    Dim toply As Integer = 0
    Dim toprx As Integer = 0
    Dim topry As Integer = 0
    Dim th1 As Threading.Thread
    Dim th2 As Threading.Thread
    Dim wid As Integer = 0
    Dim greenbrush As New SolidBrush(System.Drawing.Color.FromArgb(180, System.Drawing.Color.Green))
    Dim skyBluePen As New Pen(Brushes.DeepSkyBlue)
    Dim skygreenPen As New Pen(Brushes.Green)

    Dim ig As System.Drawing.Image
    Dim coun = 0
    Public grayImage As Bitmap
    Public img As System.Drawing.Image
    Public threashholdpivot = 180

    Sub New(igpath As String, idScan As Int32)
        lastScanId = idScan
        Lfinish = False   'indicator to check if the left thread has finsh work 
        Rfinish = False   'indicator to check if the right  thread has finsh work 
        PaperError = False




        imgpath = igpath
        img = System.Drawing.Image.FromFile(igpath)
        bmp = New Bitmap(igpath)
        Color = New Bitmap(igpath)
        igtodetect = New Bitmap(igpath)
        ig = System.Drawing.Image.FromFile(igpath)
        skygreenPen.Width = 8.0F
        skygreenPen.LineJoin = Drawing2D.LineJoin.Bevel
        skyBluePen.Width = 8.0F
        skyBluePen.LineJoin = Drawing2D.LineJoin.Bevel

    End Sub


    Public Sub startdetect(sender As Object, e As EventArgs)
        Dim startt = Date.Now
        leftcorner = False
        rightcorner = False

        '// create filter with kernel size equal to 11
        '// and Gaussia sigma value equal to 4.0

        Dim filter = New Grayscale(0.2125, 0.7154, 0.0721)
        grayImage = filter.Apply(Color)
        coun = 0

        Dim filter1 = New Threshold(threashholdpivot) 'New SISThreshold()
        filter1.ApplyInPlace(grayImage)

        igtodetect = grayImage


        Dim count1 = 0
        Dim count2 = 0

        Dim fleft = False
        Dim fright = False

        wid = Math.Floor(grayImage.Width / 16)
        Dim c1 As New Color
        Dim ex = 0
        Dim stx = 0
        Dim sty = 0
        'PictureBox1.Image = grayImage

        th1 = New Threading.Thread(AddressOf checkcornerleft)
        'th1.SetApartmentState(Threading.ApartmentState.MTA)

        'Dim f1 = New Grayscale(0.2125, 0.7154, 0.0721)
        'Dim g1 = filter.Apply(Color)
        Dim gtosend = grayImage.Clone
        th1.Start(gtosend)  'g1


        'checkcornerleft(grayImage)

        Dim sst = 0
        Dim ssend = grayImage.Width - 1


        th2 = New Threading.Thread(AddressOf checkcornerright)
        'th1.SetApartmentState(Threading.ApartmentState.MTA)

        'Dim f2 = New Grayscale(0.2125, 0.7154, 0.0721)
        'Dim g2 = filter.Apply(Color)
        Dim gtosend1 = grayImage.Clone
        th2.Start(gtosend1) 'g2
        th1.Join()
        th2.Join()
        th1.Abort()
        th2.Abort()
        'alidebug
        My.Application.Log.WriteEntry("th1 and th2 finish ")


        'g.DrawLine(skygreenPen, 0, toply, grayImage.Width, toply)
        'g.DrawLine(skyBluePen, toplx, toply, toprx, topry)

        '' threadiiiiiinnnngg   PictureBox2.Invalidate()


    End Sub

    Private Sub loadimg(pt As String)
        Color = New Bitmap(pt)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Try
            img = Color
            img = RotateImage(img, New PointF(-0, -0), -Math.Atan((topry - toply) / (toprx - toplx)) * (180 / Math.PI))
        Catch ex As Exception
            'By Sleiman
            'MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub checkcornerleft(ByVal gimag As Bitmap)
        My.Application.Log.WriteEntry("start left ")
        Dim ex = 0
        Dim c1 As Color
        Dim stx = 0
        Dim sty = 0

        '''''''''''''''' cornerrr    leftttt
        For y = 0 To (gimag.Height - 1) / 8   '  start from y 0   For y = 0 To (grayImage.height - 1) / 4 
            If ex <> 0 Then
                Exit For
            End If
            For x = 0 To (gimag.Width - 1) / 8    '  start from x 0   For x = 0 To (grayImage.Width - 1) / 4
                c1 = gimag.GetPixel(x, y)           'get pixel

                If c1.R < 200 Then
                    'MsgBox(c1.ToString & " x :" & x & "  y:" & y)
                    stx = x
                    sty = y

                    If (checkifsquare(gimag, stx, sty)) Then
                        'g.DrawRectangle(skygreenPen, stx, sty, wid, wid)
                        leftcorner = True
                        toplx = stx
                        toply = sty
                        ex = 1
                        Exit For
                    End If
                End If
            Next
        Next
        If rightcorner = True And leftcorner = True Then
            My.Application.Log.WriteEntry("calling orient from left ")
            orientimage()
        End If

        If Not leftcorner Then
            _error &= " no left corner "
            My.Application.Log.WriteEntry("non left detetect error event ")
            RaiseEvent omrdetecterror()
        End If

        Lfinish = True

        My.Application.Log.WriteEntry("end left  ")
    End Sub

    Private Sub checkcornerright(ByVal gimag As Bitmap)
        My.Application.Log.WriteEntry("start right ")
        Dim ex = 0

        '''''''''''''''' cornerrr    right
        Dim stx = 0
        Dim sty = 0
        Dim c1 As Color

        For y = 0 To Math.Floor((gimag.Height - 1) / 8)   '  start from y 0
            If ex <> 0 Then
                Exit For
            End If

            Dim sss = gimag.Width - 1
            Dim ttt = Math.Floor(gimag.Width - 1 - (gimag.Width) / 8)

            For x = sss To ttt Step -1    '  start from x 0
                c1 = gimag.GetPixel(x, y)           'get pixel

                If c1.R < 200 Then
                    'MsgBox(c1.ToString & " x :" & x & "  y:" & y)
                    stx = x
                    sty = y

                    'PictureBox2.Invalidate()

                    If (checkifsquare(gimag, stx - wid, sty)) Then
                        'g.DrawRectangle(skyBluePen, stx - wid, sty, wid, wid)
                        toprx = stx - wid
                        topry = sty
                        rightcorner = True
                        ex = 1
                        Exit For
                    End If
                End If
            Next
        Next
        If rightcorner = True And leftcorner = True Then
            My.Application.Log.WriteEntry("calling orient from right ")
            orientimage()
        End If

        If Not rightcorner Then
            _error &= " no right corner "
            My.Application.Log.WriteEntry("non right detect raise event erreur ")
            RaiseEvent omrdetecterror()
        End If
        Rfinish = True

        My.Application.Log.WriteEntry("end right ")
    End Sub

    Sub orientimage()
        My.Application.Log.WriteEntry("start orient ")
        Try
            'img = igtodetect 'Color
            'If toply <= topry Then
            '    grayImage = RotateImage(grayImage, New PointF(0, 0), -Math.Atan((topry - toply) / (toprx - toplx)) * (180 / Math.PI))
            'Else
            '    grayImage = RotateImage(grayImage, New PointF(img.Width, 0), -Math.Atan((topry - toply) / (toprx - toplx)) * (180 / Math.PI))
            'End If
            grayImage = RotateImage(grayImage, New PointF(0, 0), Math.Atan((toply - topry) / (toprx - toplx)) * (180 / Math.PI))
            'MsgBox(Math.Atan((toply - topry) / (toprx - toplx)) * (180 / Math.PI))
            'grayImage = RotateImage(grayImage, New PointF(0, 0), )
            'Color = img
            Button3_Click()
        Catch ex As Exception
            'MsgBox(ex.Message)
            'By Sleiman
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim qess(5) As Integer

    Private Sub Button3_Click()
        My.Application.Log.WriteEntry("start bt3")
        Dim widint = Integer.Parse(Math.Floor(wid))
        Dim widint4 = Integer.Parse(Math.Floor(wid / 4))

        Dim dis = 2160
        Dim recdis = 160
        Dim g = Graphics.FromImage(grayImage)

        'g.DrawLine(skyBluePen, New Point(toplx, 0), New Point(toplx, grayImage.Height))
        'g.DrawLine(skyBluePen, New Point(toplx + wid, 0), New Point(toplx + wid, grayImage.Height))

        'g.DrawLine(skygreenPen, New Point(toprx, 0), New Point(toprx, grayImage.Height))
        'g.DrawLine(skygreenPen, New Point(toprx + wid, 0), New Point(toprx + wid, grayImage.Height))

        'g.DrawLine(skygreenPen, New Point(toprx + recdis, 0), New Point(toprx + recdis, grayImage.Height))
        'Try
        '    g.DrawRectangle(skyBluePen, toplx, toply, widint, widint4)
        '    g.DrawRectangle(skyBluePen, toprx, topry, widint, widint4)

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'If toply < topry Then
        '    '''' lefttttt
        '    g.DrawString("Left", New Font("arial", 28), Brushes.Red, New Point(toplx + 300, toply))

        '    'g.DrawRectangle(skyBluePen, toplx, toply, recdis, recdis)
        '    'g.DrawRectangle(skygreenPen, toplx + dis, topry, recdis, recdis)

        'Else
        '    ''''rightttt

        '    g.DrawString("right", New Font("arial", 28), Brushes.Red, New Point(toprx - 300, topry))

        '    'g.DrawRectangle(skyBluePen, toprx, topry, recdis, recdis)
        '    'g.DrawRectangle(skygreenPen, toprx - dis, topry, recdis, recdis)

        'End If



        'g.DrawLine(skyBluePen, New Point(toplx + dis, 0), New Point(toplx + dis, grayImage.Height))
        'g.DrawLine(skyBluePen, New Point(toplx + dis + recdis, 0), New Point(toplx + dis + recdis, grayImage.Height))

        'g.DrawLine(skyBluePen, New Point(toplx, toply), New Point(toprx + wid, topry))
        'g.DrawRectangle(skyBluePen, toplx, toply, Integer.Parse(Math.Floor(wid)), Integer.Parse(Math.Floor(wid)))
        'g.DrawLine(skygreenPen, New Point(0, toply), New Point(grayImage.Width, toply))
        'g.DrawRectangle(skygreenPen, Integer.Parse(Math.Floor(toprx)), Integer.Parse(Math.Floor(topry)), Integer.Parse(Math.Floor(wid)), Integer.Parse(Math.Floor(wid)))

        'g.DrawRectangle(skyBluePen, widint * 2, widint * 4, Integer.Parse(Math.Floor(wid / 2)), Integer.Parse(Math.Floor(wid / 2)))

        Dim g1 = Graphics.FromImage(grayImage)

        'g1.DrawRectangle(skyBluePen, 0, 0, widint, widint)
        'g1.DrawLine(skygreenPen, toplx, toply, toplx, grayImage.Height)
        'g1.DrawLine(skygreenPen, toprx, 0, toprx, grayImage.Height)
        'g1.DrawLine(skygreenPen, toplx + grayImage.Width - dis, 0, toplx + grayImage.Width - dis, grayImage.Height)
        'g1.DrawLine(skygreenPen, toprx, 0, toprx, 1000)

        '''''' maskkkkkkkk

        'Dim f1 = New Grayscale(0.2125, 0.7154, 0.0721)
        Dim imggray = grayImage 'f1.Apply(grayImage)


        Dim cooy = qsy 'widint * 3
        Dim tot = (wid / 2) ^ 2

        Dim cooxbooklet = booklx  ' Integer.Parse(txt_x.Text) * 2   'widint * 3
        cooy = bookly

        For j = 0 To 2
            coun = 0
            'mask ali 
            g1.DrawRectangle(skygreenPen, cooxbooklet, cooy, Integer.Parse(Math.Floor(wid / 2)), Integer.Parse(Math.Floor(wid / 2)))

            countpix(cooxbooklet, cooy, imggray)
            If coun / 6000 > threashpers Then
                g1.FillRectangle(greenbrush, cooxbooklet, cooy, Integer.Parse(Math.Floor(wid / 2)), Integer.Parse(Math.Floor(wid / 2)))
                resomrbookel &= rress(j)
            End If
            qess(j) = coun
            cooxbooklet += bookldx
        Next

        'Dim row = New String() {"BOOKLET", "", perr(qess(0)), perr(qess(1)), perr(qess(2)), "0", "0"}
        omrbooklet = {perr(qess(0)), perr(qess(1)), perr(qess(2))}

        'DataGridView1.Rows.Add(row)



        cooy = qsy  'widint * 3
        For j = 0 To 19

            Dim coox = qsx   'widint * 3
            coun = 0

            For i = 0 To 3
                'mask ali 
                g1.DrawRectangle(skygreenPen, coox, cooy, Integer.Parse(Math.Floor(wid / 2)), Integer.Parse(Math.Floor(wid / 2)))
                countpix(coox, cooy, imggray)
                If coun / 6000 > threashpers Then
                    g1.FillRectangle(greenbrush, coox, cooy, Integer.Parse(Math.Floor(wid / 2)), Integer.Parse(Math.Floor(wid / 2)))
                    resomrques(j) &= rress(i)
                End If
                coox += qsdx  'Integer.Parse(Math.Floor((wid / 2) + (wid / 3)))
                qess(i) = coun

                omrques(j, i) = perr(coun) 'perr(coun)
                coun = 0
            Next

            cooy += qsdy

            '.SetValue( = New String() {j + 1, "", perr(qess(0)), perr(qess(1)), perr(qess(2)), perr(qess(3)), perr(qess(4))}

            'DataGridView1.Rows.Add(row)

            coun = 0

        Next


        cooy = idsy  'widint * 5

        For j = 0 To 9
            Try
                coun = 0
                Dim coox = idsx * 2 ' widint * 10
                For i = 0 To 4
                    'mask ali 
                    g1.DrawRectangle(skygreenPen, coox, cooy, Integer.Parse(Math.Floor(wid / 2)), Integer.Parse(Math.Floor(wid / 2)))

                    countpix(coox, cooy, imggray)
                    If coun / 6000 > threashpers Then
                        g1.FillRectangle(greenbrush, coox, cooy, Integer.Parse(Math.Floor(wid / 2)), Integer.Parse(Math.Floor(wid / 2)))
                        resomrid(i) &= j
                    End If
                    coox += idsdx  'Integer.Parse(Math.Floor((wid / 2) + (wid / 3)))
                    omrid(j, i) = perr(coun) 'perr(qess(i))
                    coun = 0
                Next

                cooy += idsdy
            Catch ex As Exception
                MsgBox(ex.Message & " : 123" & ":j:" & j)
            End Try
            coun = 0

        Next

        'g1.DrawL(skygreenPen, toplx, 0, toplx, 500)
        'g1.DrawLine(skygreenPen, toprx, 0, toprx, 500)

        'Try
        '    Dim nna = imgpath.ToString.Insert(1 + imgpath.ToString.LastIndexOf("\"), "_solved_")
        '    'MsgBox(nna)
        '    If Not My.Computer.FileSystem.FileExists(nna) Then
        '        Dim ee = imggray.Clone
        '        SyncLock (ee) 'Puts a "lock" on the object to make sure it will not be used anywhere else.
        '            'MsgBox(imgpath.ToString)
        '            ee.Save(nna)
        '        End SyncLock 'Release the lock so that other threads can access th
        '    Else
        '        'MsgBox("D:\omr\ex\" & imnum.ToString & "_solved.jpg  exist")
        '    End If
        '    ig.Dispose()
        '    grayImage.Dispose()
        '    igtodetect.Dispose()
        '    bmp.Dispose()
        '    Color.Dispose()
        '    img.Dispose()

        '    RaiseEvent omrdetectdone()

        '    Return
        'Catch ex As Exception

        'End Try
        'Close()
        Try

            If Not My.Computer.FileSystem.FileExists(imgpath & "_solved.jpg") Then
                Dim ee = imggray.Clone
                My.Application.Log.WriteEntry("Calling Save " & Me.imgpath & ".")
                SyncLock (ee) 'Puts a "lock" on the object to make sure it will not be used anywhere else.
                    ee.Save(imgpath & "_solved.jpg")
                End SyncLock 'Release the lock so that other threads can access th
                My.Application.Log.WriteEntry("After Save " & Me.imgpath & ".")
                ig.Dispose()
                grayImage.Dispose()
                igtodetect.Dispose()
                bmp.Dispose()
                Color.Dispose()
                img.Dispose()



            Else
                'MsgBox("D:\omr\ex\" & imnum.ToString & "_solved.jpg  exist")
            End If
            My.Application.Log.WriteEntry("raise done e vent ")
            RaiseEvent omrdetectdone()

            Return
        Catch ex As Exception
            'By Sleiman
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function perr(ByVal n As Integer) As String
        Return Math.Round(100 * n / 6000)
    End Function

    Dim rress() = {"A", "B", "C", "D", "E"}

    Public Function RotateImage(ByRef image As System.Drawing.Image, ByVal offset As PointF, ByVal angle As Decimal) As Bitmap
        If image Is Nothing Then
            Throw New ArgumentNullException("image")
        End If
        ''create a new empty bitmap to hold rotated image
        Dim rotatedBmp As Bitmap = New Bitmap(image.Width, image.Height)
        'Dim rotatedBmp As Bitmap = New Bitmap(image)
        rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)
        ''make a graphics object from the empty bitmap
        Dim g As Graphics = Graphics.FromImage(rotatedBmp)
        ''Put the rotation point in the center of the image
        'g.TranslateTransform(offset.X, offset.Y)
        g.TranslateTransform(-toplx, -toply)
        ''rotate the image
        g.RotateTransform(angle)

        ''move the image back
        'g.TranslateTransform(-offset.X, -offset.Y)
        ''draw passed in image onto graphics object

        g.DrawImage(image, New PointF(0, 0))

        'g.DrawImage(image, offset)
        Return rotatedBmp
    End Function

    Public Function trans(ByRef image As System.Drawing.Image, ByVal x As Integer, y As Integer) As Bitmap
        If image Is Nothing Then
            Throw New ArgumentNullException("image")
        End If
        ''create a new empty bitmap to hold rotated image
        Dim rotatedBmp As Bitmap = New Bitmap(image.Width, image.Height)
        'Dim rotatedBmp As Bitmap = New Bitmap(image)
        rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)
        ''make a graphics object from the empty bitmap
        Dim g As Graphics = Graphics.FromImage(rotatedBmp)
        g.TranslateTransform(x, y)
        g.DrawImage(image, New PointF(0, 0))
        'g.DrawImage(image, offset)
        Return rotatedBmp
    End Function


    Function checkifsquare(ByVal grayImage As Bitmap, stx As Integer, sty As Integer) As Boolean
        Dim wid = 0
        Dim coun = 0

        wid = Integer.Parse(Math.Floor(grayImage.Width / 16.0))
        Dim tot = wid * wid / 4
        For i = stx To stx + wid
            If i > grayImage.Width - 1 Then
                Exit For
            End If
            For j = sty To sty + (wid / 4)
                If j > grayImage.Height - 1 Then
                    Exit For
                End If
                Dim c1 = grayImage.GetPixel(i, j)

                If c1.R < 50 Then 'And c1.G < 50 And c1.B < 50 Then
                    coun += 1
                    If ((coun / 1.0) / tot) * 100 > 89 Then
                        'g.DrawString(coun.ToString, New Font("Arial", 50), New SolidBrush(System.Drawing.Color.Red), New Point(stx, sty))
                        'MsgBox(coun & ":" & ((coun / 1.0) / tot) * 100)
                        Return True
                    End If
                End If
            Next

        Next

        'If ((coun / 1.0) / tot) * 100 > Integer.Parse(TextBox2.Text) Then
        ' Return True
        'Else
        Return False
        'End If
    End Function

    Sub countpix(coox As Integer, cooy As Integer, ByRef imggray As Bitmap)
        For qi = coox To coox + wid / 2
            If qi > imggray.Width - 1 Then
                Exit For
            End If
            For qj = cooy To cooy + wid / 2
                If qj > imggray.Height - 1 Then
                    Exit For
                End If
                Dim c1 = imggray.GetPixel(qi, qj)
                If c1.R < 50 And c1.G < 50 And c1.B < 50 Then
                    coun += 1
                End If
            Next
        Next

    End Sub

    Public Sub SavetoDB() Handles Me.omrdetectdone
        'My.Application.Log.WriteEntry("Calling SaveClass non error " & Me.imgpath & ".")
        NewSave = New SaveToDB(Me)



    End Sub

    Public Sub SavetoDbWithErro() Handles Me.omrdetecterror
        PaperError = True
        ' My.Application.Log.WriteEntry("Calling SaveClass with error " & Me.imgpath & ".")
        NewSave = New SaveToDB(Me)
    End Sub
End Class

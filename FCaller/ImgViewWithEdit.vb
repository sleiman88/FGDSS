Imports System.Data.SqlClient
Public Class ImgViewWithEdit
    Dim IdScan, ResolvedPath As String
    Dim AnalyseAndReport As AnalyseAndReport
    Dim Myconn As MyConnection
    Dim ExamType As ExamType
    Sub New(ResolvedPath As String, IdScan As String, AnalyseAndReport As AnalyseAndReport)
        Me.AnalyseAndReport = AnalyseAndReport
        Me.ResolvedPath = ResolvedPath
        Me.IdScan = IdScan
        Myconn = New MyConnection

        ' This call is required by the designer.
        InitializeComponent()
        ExamType = New ExamType
        ExamType.Location = New Size(467, 46)
        Me.Controls.Add(ExamType)


        Dim img As Bitmap
        img = New Bitmap(ResolvedPath, True)
        PictureBox1.Image = img
        TextBox_Path.Text = ResolvedPath

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub ImgViewWithEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setAnswers(getAnswersFromDb(IdScan, ResolvedPath))
        setCandidatId(getCandidatIdFromDB(IdScan, ResolvedPath))
        ExamType.setRadio(getExamTypeForCandidatFromDB(IdScan, ResolvedPath))
    End Sub

    Private Function getExamTypeForCandidatFromDB(IdScan As String, ResolvedPath As String) As String
        Try
            Dim querry As String
            querry = "select Name_type  from 
PaperOmr_tbl join Exams_type on PaperOmr_tbl .Id_type =Exams_type .Id_type 

 where  ResolvedPath_PaperOmr = '" + ResolvedPath + "' and Id_Scan =" + IdScan + " "
            Dim ds As DataSet
            Dim cmd As SqlCommand
            Dim result As String
            ds = New DataSet()
            cmd = New SqlCommand(querry)
            Dim reader = New SqlDataAdapter(cmd.CommandText, Myconn.openConnection)
            ds.Clear()
            reader.Fill(ds)
            reader.Dispose()
            Dim Dtable As DataTable = ds.Tables(0)
            result = Dtable.Rows(0)("Name_type")
            Return result
            Myconn.closeConnection()
        Catch ex As Exception
            Myconn.closeConnection()
        End Try
        Return "error"
    End Function

    Private Function getCandidatIdFromDB(IdScan As String, ResolvedPath As String) As String()
        Dim CandidatId(5) As String
        Try
            Dim querry As String
            Dim ds As DataSet
            Dim cmd As SqlCommand
            querry = "select D0_PaperOmrId AS 'D0',D1_PaperOmrId AS 'D1',D2_PaperOmrId AS 'D2',D3_PaperOmrId AS 'D3',D4_PaperOmrId AS 'D4' from PaperOmr_tbl  join PaperOmrId_tbl on PaperOmr_tbl .Id_PaperOmr =PaperOmrId_tbl .Id_PaperOmr 

 where ResolvedPath_PaperOmr ='" + ResolvedPath + "' and Id_Scan =" + IdScan + ";"

            ds = New DataSet()
            cmd = New SqlCommand(querry)
            Dim reader = New SqlDataAdapter(cmd.CommandText, Myconn.openConnection)
            ds.Clear()
            reader.Fill(ds)
            reader.Dispose()
            Dim Dtable As DataTable = ds.Tables(0)
            CandidatId(0) = Dtable.Rows(0)("D0")
            CandidatId(1) = Dtable.Rows(0)("D1")
            CandidatId(2) = Dtable.Rows(0)("D2")
            CandidatId(3) = Dtable.Rows(0)("D3")
            CandidatId(4) = Dtable.Rows(0)("D4")
            Dtable.Dispose()
            Myconn.closeConnection()

            Return CandidatId
        Catch ex As Exception
            Myconn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try
        Return CandidatId
    End Function

    Private Sub setCandidatId(CandidatId As String())
        For k = 0 To 4
            If CandidatId(k) = "empty" Then
                CandidatId(k) = ""
            End If
        Next

        TextBox_D0.Text = CandidatId(0)


        TextBox_D1.Text = CandidatId(1)


        TextBox_D2.Text = CandidatId(2)

        TextBox_D3.Text = CandidatId(3)


        TextBox_D4.Text = CandidatId(4)



    End Sub

    Private Sub Button_Update_Click(sender As Object, e As EventArgs) Handles Button_Update.Click
        If checkTextBoxError() = True Then
            MessageBox.Show("Invalid Candidat Id ")
        Else
            'save to DB 
            SaveCandidatIdToDB(readCandidatId(), IdScan, ResolvedPath)
            'update answers 
            saveToDB(readAnswers(), IdScan, ResolvedPath)

            SaveCandidatExamType(ExamType.getSelected(), IdScan, ResolvedPath)
            changeEditedByadminSatus(IdScan, ResolvedPath)
            MessageBox.Show("Updated")
            AnalyseAndReport.fillAllDataGrid()
            AnalyseAndReport.FillTextbox()
            Me.Close()
        End If


    End Sub
    Private Sub changeEditedByadminSatus(IdScan As String, ResolvedPath As String)
        Try
            Dim querry As String
            querry = "Update PaperOmr_tbl set EditedByAdmin_PaperOmr ='True'  where 
ResolvedPath_PaperOmr = '" + ResolvedPath + "' and Id_Scan =" + IdScan + " 
 "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(querry, Myconn.openConnection())
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SaveCandidatExamType(ExamIdFromForm As String, IdScan As String, ResolvedPath As String)
        Try
            Dim querry As String
            querry = "Update PaperOmr_tbl set Id_type =(select Id_type from Exams_type where Name_type ='" + ExamIdFromForm + "')
 
 where  ResolvedPath_PaperOmr = '" + ResolvedPath + "' and Id_Scan =" + IdScan + " 
 "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(querry, Myconn.openConnection())
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SaveCandidatIdToDB(CandidatId As String(), IdScan As String, ResolvedPath As String)
        Try
            Dim querry As String
            querry = "
Update PaperOmrId_tbl set D0_PaperOmrId ='" + CandidatId(0) + "',D1_PaperOmrId ='" + CandidatId(1) + "',D2_PaperOmrId ='" + CandidatId(2) + "',
D3_PaperOmrId ='" + CandidatId(3) + "',D4_PaperOmrId ='" + CandidatId(4) + "'

 where Id_PaperOmr 
In(select Id_PaperOmr from PaperOmr_tbl where  ResolvedPath_PaperOmr = '" + ResolvedPath + "'
and Id_Scan =" + IdScan + " )
 "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(querry, Myconn.openConnection())
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Function getAnswersFromDb(IdScan As String, ResolvedPath As String) As String()
        Dim AnswerFromDB(20) As String
        Try

            Dim ds As New DataSet()
            Dim myCmd1 As SqlCommand
            Dim query As String

            ds = New DataSet()

            query = "Select QuesAns_paperOmrQues As 'Ans_Ans' from PaperOmrQues_tbl where Id_PaperOmr IN
(Select Id_PaperOmr from PaperOmr_tbl where Id_Scan =" + IdScan + "And ResolvedPath_PaperOmr ='" + ResolvedPath + "');"
            myCmd1 = New SqlCommand(query)
            Dim reader = New SqlDataAdapter(myCmd1.CommandText, Myconn.openConnection)
            ds.Clear()
            reader.Fill(ds)
            reader.Dispose()
            Dim Dtable As DataTable = ds.Tables(0)
            'Dim Drow As DataRow
            ' Dim Dcolumn As DataColumn

            'result = Dtable.Rows(0)("LName")
            For k = 0 To 19

                AnswerFromDB(k) = Dtable.Rows(k)("Ans_Ans")


            Next
            Return AnswerFromDB

        Catch ex As Exception
            MessageBox.Show("yes here!! " + ex.Message)
            Myconn.closeConnection()
        End Try

        Return AnswerFromDB
    End Function
    'Read candidat number from 
    Function readCandidatId() As String()
        Dim CandidatId(5) As String
        CandidatId(0) = TextBox_D0.Text
        CandidatId(1) = TextBox_D1.Text
        CandidatId(2) = TextBox_D2.Text
        CandidatId(3) = TextBox_D3.Text
        CandidatId(4) = TextBox_D4.Text
        For k = 0 To 4
            If CandidatId(k) = "" Then
                CandidatId(k) = "empty"
            End If
        Next
        Return CandidatId
    End Function
    'read answers from form 
    Function readAnswers() As String()
        Dim Ans As Char

        Ans = "0"
        Dim temp As Char = Chr(1)
        Dim checkedRadio
        Dim i As Int32
        i = 0
        Dim counter As Int32

        Dim Fanswer(20) As String
        For Each ctrl As Control In GroupBox_Questions.Controls
            If TypeOf ctrl Is GroupBox Then

                checkedRadio = {ctrl}.SelectMany(Function(g) g.Controls.OfType(Of RadioButton)().Where(Function(r) r.Checked))
                counter = 0

                For Each c In checkedRadio
                    counter = counter + 1
                    temp = c.Name(c.Name.Length - 1)

                    Select Case temp
                        Case "1"
                            Ans = "A"

                        Case "2"
                            Ans = "B"

                        Case "3"
                            Ans = "C"

                        Case "4"
                            Ans = "D"

                        Case "5"
                            Ans = "E"

                    End Select

                    Fanswer(i) = Ans


                    i = i + 1
                Next
                If counter = 0 Then
                    Fanswer(i) = "empty"
                    i = i + 1
                End If
            End If
        Next

        Return Fanswer
    End Function

    'set Answers to form through radio button 
    Private Sub setAnswers(answ As String())
        Dim Ans As Char
        Ans = "0"

        Dim temp = answ
        Dim index As Int32
        Dim i As Int32
        i = 0
        Dim count As Int32
        count = 0
        For Each ctrl As Control In GroupBox_Questions.Controls
            If TypeOf ctrl Is GroupBox Then
                Select Case temp(i)
                    Case "A"
                        index = 2
                        count += 1
                    Case "B"
                        index = 4
                        count += 1
                    Case "C"
                        index = 3
                        count += 1
                    Case "D"
                        index = 1
                        count += 1
                    Case "E"
                        index = 0
                    Case "empty"
                        index = 99
                End Select
                If index <> 99 And count = 1 Then
                    ctrl.Controls.OfType(Of RadioButton).ElementAt(index).Checked = True

                End If

                count = 0
                i = i + 1

            End If



        Next


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub saveToDB(AnsTbl() As String, IdScan As String, ResolvedPath As String)
        Try
            Dim cmdUpd As SqlCommand
            Dim querry2 As String

            '            Update Customers
            'SET ContactName = 'Alfred Schmidt', City= 'Frankfurt'
            'WHERE CustomerID = 1;

            For k = 0 To 19
                querry2 = " Update PaperOmrQues_tbl  SET QuesAns_paperOmrQues ='" + AnsTbl(k) + "' where QuesId_PaperOmrQues =" + k.ToString + "
                            And Id_PaperOmr 
                            IN
                            (select Id_PaperOmr from PaperOmr_tbl where Id_Scan =" + IdScan + " and ResolvedPath_PaperOmr ='" + ResolvedPath + "');"

                cmdUpd = New SqlCommand(querry2, Myconn.openConnection())

                cmdUpd.ExecuteNonQuery()

            Next
            Myconn.closeConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Myconn.closeConnection()
        End Try
    End Sub

    Private Sub TextBox_D0_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_D0.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox_D1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_D1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox_D2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_D2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox_D3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_D3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Function checkTextBoxError() As Boolean
        If TextBox_D0.Text.Length > 1 Or TextBox_D1.Text.Length > 1 Or TextBox_D2.Text.Length > 1 Or TextBox_D3.Text.Length > 1 Or TextBox_D4.Text.Length > 1 Then
            Return True
        End If

        Return False
    End Function

    Private Sub GroupBox21_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim zoom As New ImgViewer(ResolvedPath)
        zoom.Show()
    End Sub

    Private Sub TextBox_D4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox_D4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class
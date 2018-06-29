Imports System.Data.SqlClient
Public Class EditExam
    Dim NewFormCaller As GradeAndAnswers
    Dim myConn As MyConnection
    Public IdExam As Integer
    Sub New(caller As GradeAndAnswers)
        NewFormCaller = caller
        ' This call is required by the designer.
        InitializeComponent()
        caller.Hide()
        myConn = New MyConnection()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub EditExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fillMyDataGrid()
        DataGridView_EditExam.Rows(0).Selected = True



        setAnswers(getAnswersFromDb(getSelectedIdExam(0)))

    End Sub
    Private Function getSelectedIdExam(rowIndex As Int32) As Int32
        Dim result As Int32
        Try

            Dim ExamName, ExamLanguage, ExamType As String
            ExamName = DataGridView_EditExam.Item(0, rowIndex).Value.ToString()
            ExamLanguage = DataGridView_EditExam.Item(1, rowIndex).Value.ToString()
            ExamType = DataGridView_EditExam.Item(2, rowIndex).Value.ToString()
            Dim querry As String
            querry = "select Id_Exam from Exams_tbl where 
Name_Exam='" + ExamName + "' and Id_type =(select Id_type from Exams_type where Name_type ='" + ExamType + "') 
and Id_Language =(Select Id_Language from Exams_Language where Name_Language ='" + ExamLanguage + "');"


            Dim ds As New DataSet()
            Dim cmd = New SqlCommand(querry)
            Dim Dtable As DataTable
            ds.Clear()

            Dim sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(ds)


            Dtable = ds.Tables(0)


            result = Dtable.Rows(0)("Id_Exam")
            myConn.closeConnection()
            ds.Dispose()

            IdExam = result
            Return result


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
        End Try
        Return result

    End Function

    Public Sub fillMyDataGrid()
        Try
            Dim querry As String
            Dim dsGrid As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            querry = "Select Name_Exam AS 'Exam Name' ,Name_Language As 'Language' ,Name_type As 'Type'
                 from Exams_tbl  join Exams_Language on Exams_tbl.Id_Language =Exams_Language.Id_Language
                                 join Exams_type on  Exams_tbl.Id_type=Exams_type.Id_type
				                 join ExamsCheckAns_tbl on Exams_tbl.Id_Exam=ExamsCheckAns_tbl.Id_Exam
                 where ExamsCheckAns_tbl.State_ExamsCheckAns like 'Answers Exist'"

            Dim cmd As New SqlCommand(querry)

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsGrid)
            DataGridView_EditExam.ClearSelection()


            DataGridView_EditExam.DataSource = dsGrid.Tables(0)

            myConn.closeConnection()

        Catch ex As Exception

        End Try

    End Sub

    Private Function getAnswersFromDb(IdExam As Int32) As Char()
        Dim AnswerFromDB(20) As Char
        Try

            Dim ds As New DataSet()
            Dim myCmd1 As SqlCommand
            Dim query As String

            ds = New DataSet()

            query = "select * from Answers_tbl where Id_Exam =" + IdExam.ToString + " ;"
            myCmd1 = New SqlCommand(query)
            Dim reader = New SqlDataAdapter(myCmd1.CommandText, myConn.openConnection)
            ds.Clear()
            reader.Fill(ds)

            Dim Dtable As DataTable = ds.Tables(0)
            'Dim Drow As DataRow
            ' Dim Dcolumn As DataColumn

            'result = Dtable.Rows(0)("LName")
            For k = 0 To 19

                AnswerFromDB(k) = Dtable.Rows(k)("Ans_Ans")


            Next
            Return AnswerFromDB

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
        End Try

        Return AnswerFromDB
    End Function


    'read Answer from form 
    Function readAnswers() As Char()
        Dim Ans As Char

        Ans = "0"
        Dim temp As Char = Chr(1)
        Dim checkedRadio
        Dim i As Int32
        i = 0
        Dim Fanswer(20) As Char
        For Each ctrl As Control In GroupBox_Questions.Controls
            If TypeOf ctrl Is GroupBox Then

                checkedRadio = {ctrl}.SelectMany(Function(g) g.Controls.OfType(Of RadioButton)().Where(Function(r) r.Checked))

                For Each c In checkedRadio

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

            End If
        Next

        Return Fanswer
    End Function
    'set answers to form 
    Private Sub setAnswers(answ As Char())
        Dim Ans As Char
        Ans = "0"

        Dim temp = answ
        Dim index As Int32
        Dim i As Int32
        i = 0

        For Each ctrl As Control In GroupBox_Questions.Controls
            If TypeOf ctrl Is GroupBox Then
                Select Case temp(i)
                    Case "A"
                        index = 2
                    Case "B"
                        index = 4
                    Case "C"
                        index = 3
                    Case "D"
                        index = 1
                    Case "E"
                        index = 0
                End Select
                ctrl.Controls.OfType(Of RadioButton).ElementAt(index).Checked = True

                i = i + 1

            End If



        Next


    End Sub
    Private Sub saveToDB(AnsTbl() As Char)
        Try
            Dim cmdUpd As SqlCommand
            Dim querry2 As String

            '            Update Customers
            'SET ContactName = 'Alfred Schmidt', City= 'Frankfurt'
            'WHERE CustomerID = 1;

            For k = 0 To 19
                querry2 = "Update Answers_tbl SET Ans_Ans=@Ans_Ans where Id_Exam=@Id_Exam AND QuesID_Ans =@QuesID_Ans ;"



                cmdUpd = New SqlCommand(querry2, myConn.openConnection())
                cmdUpd.Parameters.AddWithValue("@QuesID_Ans", k.ToString)
                cmdUpd.Parameters.AddWithValue("@Ans_Ans", AnsTbl(k))
                cmdUpd.Parameters.AddWithValue("@Id_Exam", IdExam)
                cmdUpd.ExecuteNonQuery()





            Next
            MessageBox.Show("updated  succefully")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Btn_save_Click(sender As Object, e As EventArgs) Handles Btn_save.Click
        saveToDB(readAnswers())



    End Sub

    Private Sub EditExam_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        myConn.closeConnection()

        NewFormCaller.Show()
    End Sub

    Private Sub Btn_Back_Click(sender As Object, e As EventArgs) Handles Btn_Back.Click
        myConn.closeConnection()
        Me.Close()
        NewFormCaller.Show()
    End Sub

    Private Sub DataGridView_EditExam_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_EditExam.CellContentClick
        Btn_save.Enabled = True
        setAnswers(getAnswersFromDb(getSelectedIdExam(e.RowIndex)))
    End Sub

    Private Sub DataGridView_EditExam_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_EditExam.RowHeaderMouseClick
        Btn_save.Enabled = True
        setAnswers(getAnswersFromDb(getSelectedIdExam(e.RowIndex)))
    End Sub
End Class
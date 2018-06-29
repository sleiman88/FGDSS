Imports System.Data.SqlClient
Public Class AddAnswers
    Dim answer() As Char
    Public myconn As MyConnection
    Dim GradeForm As GradeAndAnswers
    Dim IdExam As Int32
    Sub New(IdExam As Integer, callerForm As GradeAndAnswers)
        Me.IdExam = IdExam
        GradeForm = callerForm
        InitializeComponent()
        GradeForm.Hide()
        myconn = New MyConnection()

    End Sub




    Private Sub AddAnswers_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        GradeForm.Show()

        myconn.closeConnection()

    End Sub

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        Dim answer() As Char
        answer = getAnswersFromForm()

        insertAnswersToDb(answer)
            MessageBox.Show(" Added successfully")

            Me.Hide()
            myconn.closeConnection()
            GradeForm.fillMyDataGrid()

            GradeForm.Show()


            Me.Close()


    End Sub



    Private Sub Btn_Back_Click(sender As Object, e As EventArgs) Handles Btn_Back.Click
        Me.Hide()
        GradeForm.Show()

        myconn.closeConnection()
        Me.Close()
    End Sub

    Private Sub AddAnswers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillTextBox()
    End Sub

    Private Sub fillTextBox()
        Dim querry As String

        Try
            Dim Dtable As DataTable


            Dim cmd As SqlCommand
            Dim ds As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            querry = "Select Name_Exam,Name_Language,Name_Type from  Exams_tbl join Exams_type on Exams_tbl .Id_type =Exams_type .Id_type 
          join Exams_Language on Exams_tbl .Id_Language =Exams_Language .Id_Language  where Id_Exam =" + IdExam.ToString + ";"

            cmd = New SqlCommand(querry)

            ds.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myconn.openConnection)

            sqlAdapter.Fill(ds)


            Dtable = ds.Tables(0)
            TextBox_LangExam.Text = Dtable.Rows(0)("Name_Language")
            TextBox_NExam.Text = Dtable.Rows(0)("Name_Exam")
            TextBox_TypeExam.Text = Dtable.Rows(0)("Name_Type")



            myconn.closeConnection()


        Catch ex As Exception
            myconn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try




    End Sub


    Function getAnswersFromForm() As Char()
        Dim Ans As Char
        Dim result(20) As Char
        Ans = "0"

        Dim temp As Char = Chr(1)


        Dim checkedRadio




        Dim i As Int32
        i = 0

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

                    result(i) = Ans

                    i = i + 1
                Next

            End If
        Next

        Return result
    End Function


    Private Sub insertAnswersToDb(AnsTbl() As Char)
        Try
            Dim querry2 As String

            Dim cmdIns As SqlCommand


            For k = 0 To 19
                querry2 = "insert into Answers_tbl (QuesID_Ans,Ans_Ans,Id_Exam) values (@QuesID_Ans,@Ans_Ans," + IdExam.ToString + ");"
                cmdIns = New SqlCommand(querry2, myconn.openConnection())
                cmdIns.Parameters.AddWithValue("@QuesID_Ans", k.ToString)
                cmdIns.Parameters.AddWithValue("@Ans_Ans", AnsTbl(k))
                cmdIns.ExecuteNonQuery()
            Next
            querry2 = "UPDATE ExamsCheckAns_tbl SET State_ExamsCheckAns = 'Answers Exist' WHERE Id_Exam =" + IdExam.ToString + ";"
            cmdIns = New SqlCommand(querry2, myconn.openConnection())
            cmdIns.ExecuteNonQuery()
            myconn.closeConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myconn.closeConnection()
        End Try
    End Sub
End Class
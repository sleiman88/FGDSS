Imports System.Data.SqlClient
Public Class GradeAndAnswers
    Public myConn As MyConnection
    Public IdExam As Integer
    Sub New(main As MainForm)
        myConn = New MyConnection()
        InitializeComponent()
        MainForm = main
        main.Hide()
    End Sub
    Private Sub GradeAndAnswers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillMyDataGrid()
        Btn_AddAnswers.Enabled = False
    End Sub
    Public Sub fillMyDataGrid()
        Dim querry As String
        Dim dsGrid As New DataSet()
        Dim sqlAdapter As SqlDataAdapter
        querry = "Select Name_Exam AS 'Exam Name' ,Name_Language As 'Language' ,Name_type As 'Type'
                 from Exams_tbl  join Exams_Language on Exams_tbl.Id_Language =Exams_Language.Id_Language
                                 join Exams_type on  Exams_tbl.Id_type=Exams_type.Id_type
				                 join ExamsCheckAns_tbl on Exams_tbl.Id_Exam=ExamsCheckAns_tbl.Id_Exam
                 where ExamsCheckAns_tbl.State_ExamsCheckAns like 'Non Answers'"

        Dim cmd As New SqlCommand(querry)

        sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)
        DataGridView_Exam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        sqlAdapter.Fill(dsGrid)
        DataGridView_Exam.ClearSelection()


        DataGridView_Exam.DataSource = dsGrid.Tables(0)

        myConn.closeConnection()


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        MainForm.Show()
        myConn.closeConnection()
        Me.Close()
    End Sub

    Private Sub GradeAndAnswers_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainForm.Show()
        myConn.closeConnection()
    End Sub

    Private Sub DataGridView_Exam_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Exam.CellContentClick
        IdExam = getSelectedIdExam(e.RowIndex)
        allowButtonAddAnswers()
    End Sub

    Private Sub DataGridView_Exam_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Exam.RowHeaderMouseClick
        IdExam = getSelectedIdExam(e.RowIndex)
        allowButtonAddAnswers()
    End Sub

    Private Sub allowButtonAddAnswers()
        Btn_AddAnswers.Enabled = True
        Btn_AddAnswers.Select()

    End Sub

    Private Function getSelectedIdExam(rowIndex As Int32) As Int32
        Dim result As Int32
        Try

            Dim ExamName, ExamLanguage, ExamType As String
            ExamName = DataGridView_Exam.Item(0, rowIndex).Value.ToString()
            ExamLanguage = DataGridView_Exam.Item(1, rowIndex).Value.ToString()
            ExamType = DataGridView_Exam.Item(2, rowIndex).Value.ToString()
            Dim querry As String
            querry = "select Id_Exam from Exams_tbl where 
Name_Exam=N'" + ExamName + "' and Id_type =(select Id_type from Exams_type where Name_type ='" + ExamType + "') 
and Id_Language =(Select Id_Language from Exams_Language where Name_Language ='" + ExamLanguage + "');"
            ' MsgBox(querry)

            Dim ds As New DataSet()
            Dim cmd = New SqlCommand(querry)
            Dim Dtable As DataTable
            ds.Clear()

            Dim sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(ds)


            Dtable = ds.Tables(0)


            result = Dtable.Rows(0)("Id_Exam")
            '  MsgBox(result)
            myConn.closeConnection()
            ds.Dispose()


            Return result


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
        End Try
        Return result

    End Function

    Private Sub Btn_AddAnswers_Click(sender As Object, e As EventArgs) Handles Btn_AddAnswers.Click
        If DataGridView_Exam.SelectedRows.Count = 1 Then
            Dim NewAns As New AddAnswers(IdExam, Me)
            NewAns.StartPosition = FormStartPosition.Manual

            NewAns.DesktopLocation = Me.DesktopLocation
            NewAns.Activate()
            Me.Hide()
            NewAns.Show()
        Else
            MessageBox.Show("please choose an exam to add Answers to")
        End If

    End Sub

    Private Sub DataGridView_Exam_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Exam.RowHeaderMouseDoubleClick
        IdExam = getSelectedIdExam(e.RowIndex)
        allowButtonAddAnswers()
    End Sub

    Private Sub btn_EditAnswers_Click(sender As Object, e As EventArgs) Handles btn_EditAnswers.Click
        If checkIfAnswerExist() = False Then
            MessageBox.Show("Non Answers to edit ")
        Else

            Dim NewEdit As New EditExam(Me)
            NewEdit.StartPosition = FormStartPosition.Manual

            NewEdit.DesktopLocation = Me.DesktopLocation
            NewEdit.Activate()
            Me.Hide()
            NewEdit.Show()


        End If

    End Sub

    Private Function checkIfAnswerExist() As Boolean
        Try
            Dim cmd As SqlCommand
            cmd = New SqlCommand("select * from ExamsCheckAns_tbl where State_ExamsCheckAns ='Answers Exist';", myConn.openConnection())
            Dim reader As SqlDataReader

            reader = cmd.ExecuteReader()

            If reader.HasRows = False Then
                myConn.closeConnection()
                Return False
            End If
            reader.Close()
            myConn.closeConnection()
            Return True
        Catch ex As Exception

            myConn.closeConnection()

            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Btn_result_Click(sender As Object, e As EventArgs) Handles Btn_result.Click

        If checkIfAnswerExist() = False Then
            MessageBox.Show("Please add Answers First ")

        Else
            Dim NewResult As New Scans(Me)
            NewResult.StartPosition = FormStartPosition.Manual

            NewResult.DesktopLocation = Me.DesktopLocation
            NewResult.Activate()
            Me.Hide()
            NewResult.Show()

        End If




    End Sub
End Class
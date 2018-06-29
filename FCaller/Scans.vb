Imports System.Data.SqlClient
Public Class Scans
    Dim myConn As MyConnection
    Dim MainFrame As GradeAndAnswers
    Sub New(Caller As GradeAndAnswers)
        Me.MainFrame = Caller
        MainFrame.Hide()
        myConn = New MyConnection
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub ResultAndGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Btn_finalAnalyse.Enabled = False
        fillMyDataGrid()

    End Sub
    Public Sub fillMyDataGrid()
        Dim querry As String
        Dim dsGrid As New DataSet()
        Dim sqlAdapter As SqlDataAdapter
        querry = "Select Id_Scan as 'Scan Number',GradedAlready_Scan AS 'Graded ?',description_Scan AS 'Description',Name_Exam_Scan As 'Exam Name'
,Name_Language_scan As 'Language',Date_scan AS 'Date' from Scan_tbl "

        Dim cmd As New SqlCommand(querry)

        sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

        sqlAdapter.Fill(dsGrid)
        DataGridView_Scan.ClearSelection()


        DataGridView_Scan.DataSource = dsGrid.Tables(0)

        myConn.closeConnection()


    End Sub
    Private Sub ResultAndGrades_Closed(sender As Object, e As EventArgs) Handles Me.Closed


        Me.Hide()
        MainFrame.Show()




    End Sub


    Private Sub Btn_Back_Click(sender As Object, e As EventArgs) Handles Btn_Back.Click
        Me.Hide()
        MainFrame.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Scan.CellContentClick
        onclickDataGrid()
    End Sub
    Private Function checkIfScanHaveAllAns(ExamName As String, ExamLanguage As String) As Boolean
        Dim querry As String
        querry = "select Exams_tbl.Id_Exam from Exams_tbl join ExamsCheckAns_tbl on Exams_tbl.Id_Exam =ExamsCheckAns_tbl.Id_Exam 
where Name_Exam =@ExamName And Id_Language =(select Id_Language from Exams_Language where Name_Language =@ExamLanguage )  And State_ExamsCheckAns ='Non Answers'
"
        Try
            Dim cmd As SqlCommand
            cmd = New SqlCommand(querry, myConn.openConnection())
            cmd.Parameters.AddWithValue("@ExamName", ExamName)
            cmd.Parameters.AddWithValue("@ExamLanguage", ExamLanguage)

            Dim reader As SqlDataReader

            reader = cmd.ExecuteReader()

            If reader.HasRows = True Then
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

        Return True
    End Function

    Private Sub DataGridView_Scan_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Scan.RowHeaderMouseClick
        onclickDataGrid()
    End Sub

    Private Sub onclickDataGrid()
        If checkIfScanHaveAllAns(DataGridView_Scan.CurrentRow.Cells(2).Value.ToString, DataGridView_Scan.CurrentRow.Cells(3).Value.ToString) = False Then


            MessageBox.Show("Exams related to this Scan are missing answers .Please add answers first ")
        Else
            Btn_finalAnalyse.Enabled = True
            Btn_finalAnalyse.Select()


            ' MessageBox.Show("we can proceed " + DataGridView_Scan.CurrentRow.Cells(0).Value.ToString)

        End If
    End Sub

    Private Sub Btn_finalAnalyse_Click(sender As Object, e As EventArgs) Handles Btn_finalAnalyse.Click
        Dim NewAnalyse As New AnalyseAndReport(DataGridView_Scan.CurrentRow.Cells(0).Value.ToString, Me)
        NewAnalyse.StartPosition = FormStartPosition.Manual

        NewAnalyse.DesktopLocation = Me.DesktopLocation
        NewAnalyse.Activate()
        Me.Hide()
        NewAnalyse.Show()
    End Sub
End Class
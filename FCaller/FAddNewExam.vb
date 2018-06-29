Imports System.Data.SqlClient
Public Class FAddNewExam
    Public mainForm As MainForm
    Private conn As MyConnection
    Sub New(main As MainForm)
        conn = New MyConnection()
        InitializeComponent()
        mainForm = main
        main.Hide()
    End Sub




    Private Sub FAddNewExam_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        mainForm.Show()
        conn.closeConnection()
    End Sub



    Private Sub NewEx_Back_Click(sender As Object, e As EventArgs) Handles NewEx_Back.Click
        Me.Hide()
        mainForm.Show()
        conn.closeConnection()
        Me.Close()
    End Sub

    Private Sub FAddNewExam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ComboBox_Lang.Items.Count > 0 Then
            ComboBox_Lang.SelectedIndex = 0    ' The first item has index 0 '
        End If
    End Sub

    Private Sub Button_save_Click(sender As Object, e As EventArgs) Handles Button_save.Click
        If TextBox_ExamName.Text.Length = 0 Then
            MessageBox.Show("Please enter Exam Name ")
        Else

            If checkIfexist() = False Then
                'insert data 
                insertExam()
                Me.Hide()
                mainForm.Exams_tblTableAdapter.Fill(mainForm.MyDataSet.Exams_tbl)
                mainForm.fillMyLanguages()
                mainForm.Show()
                Me.Close()
            Else
                MessageBox.Show("Exam already exist ")
            End If

        End If
    End Sub


    Private Sub insertExam()
        Try
            Dim queryA, queryB, queryC As String
            Dim cmd As SqlCommand
            queryA = "INSERT INTO Exams_tbl (Name_Exam, Id_type,Id_Language)
        VALUES(@Name_Exams, (select Id_type from Exams_type where Name_type like 'A'),(select Id_Language from Exams_Language where Name_Language=@Name_Language ));"
            cmd = New SqlCommand(queryA, conn.openConnection())
            cmd.Parameters.AddWithValue("@Name_Exams", TextBox_ExamName.Text)
            cmd.Parameters.AddWithValue("@Name_Language", ComboBox_Lang.SelectedItem)
            cmd.ExecuteNonQuery()

            queryA = "INSERT INTO ExamsCheckAns_tbl (State_ExamsCheckAns, Id_Exam)
            VALUES('Non Answers', (select  MAX (Id_Exam) from Exams_tbl  ));"
            cmd = New SqlCommand(queryA, conn.openConnection())
            cmd.ExecuteNonQuery()

            queryB = "INSERT INTO Exams_tbl (Name_Exam, Id_type,Id_Language)
        VALUES(@Name_Exams, (select Id_type from Exams_type where Name_type like 'B'), (select Id_Language from Exams_Language where Name_Language=@Name_Language ));"
            cmd = New SqlCommand(queryB, conn.openConnection())
            cmd.Parameters.AddWithValue("@Name_Exams", TextBox_ExamName.Text)
            cmd.Parameters.AddWithValue("@Name_Language", ComboBox_Lang.SelectedItem)
            cmd.ExecuteNonQuery()

            queryB = "INSERT INTO ExamsCheckAns_tbl (State_ExamsCheckAns, Id_Exam)
            VALUES('Non Answers', (select  MAX (Id_Exam) from Exams_tbl  ));"
            cmd = New SqlCommand(queryB, conn.openConnection())
            cmd.ExecuteNonQuery()

            queryC = "INSERT INTO Exams_tbl (Name_Exam, Id_type,Id_Language)
        VALUES(@Name_Exams, (select Id_type from Exams_type where Name_type like 'C'),(select Id_Language from Exams_Language where Name_Language=@Name_Language ));"
            cmd = New SqlCommand(queryC, conn.openConnection())
            cmd.Parameters.AddWithValue("@Name_Exams", TextBox_ExamName.Text)
            cmd.Parameters.AddWithValue("@Name_Language", ComboBox_Lang.SelectedItem)
            cmd.ExecuteNonQuery()

            queryC = "INSERT INTO ExamsCheckAns_tbl (State_ExamsCheckAns, Id_Exam)
            VALUES('Non Answers', (select  MAX (Id_Exam) from Exams_tbl  ));"
            cmd = New SqlCommand(queryC, conn.openConnection())
            cmd.ExecuteNonQuery()
            '    '---------------------------------------------------------------------------------------------------------------------------------------------------------------


            MessageBox.Show("added suceffuly ")
        Catch ex As Exception
            conn.closeConnection()
            MessageBox.Show("error :failed to insert new Exam" + ex.Message)
        End Try
    End Sub

    Private Function checkIfexist() As Boolean
        Dim reader As SqlDataReader
        Dim result As Boolean
        result = False
        Dim cmd As SqlCommand
        Dim querry As String
        querry = "select * from Exams_tbl where Name_Exam='" + TextBox_ExamName.Text + "' And Id_Language=(select Id_Language from Exams_Language where Name_Language=@Name_Language );"
        cmd = New SqlCommand(querry, conn.openConnection())
        cmd.Parameters.AddWithValue("@Name_Language", ComboBox_Lang.SelectedItem)
        reader = cmd.ExecuteReader()

        If reader.HasRows Then
            result = True

        End If
        conn.closeConnection()
        Return result
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MessageBox.Show(ComboBox_Lang.SelectedItem)
    End Sub
End Class
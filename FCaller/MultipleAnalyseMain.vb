Imports System.Data.SqlClient
Public Class MultipleAnalyseMain
    Public myConn As MyConnection

    Sub New(main As MainForm)
        myConn = New MyConnection()
        InitializeComponent()
        MainForm = main
        main.Hide()
    End Sub

    Private Sub MultipleAnalyseMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MyDataSet.Exams_tbl' table. You can move, or remove it, as needed.
        Me.Exams_tblTableAdapter.Fill(Me.MyDataSet.Exams_tbl)

    End Sub

    Private Sub Btn_Back_Click(sender As Object, e As EventArgs) Handles Btn_Back.Click
        Me.Hide()

        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox_ExamN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_ExamN.SelectedIndexChanged
        fillMyLanguages()
    End Sub
    Public Sub fillMyLanguages()


        Dim querry As String
        Dim mysqlAdapter As SqlDataAdapter
        Dim ds As New DataSet()
        querry = "select  distinct Name_Language from Exams_Language join Exams_tbl on Exams_tbl.Id_Language=Exams_Language.Id_Language where  Name_Exam ='" + ComboBox_ExamN.SelectedValue + "';"

        Dim myCmd1 As New SqlCommand(querry)
        mysqlAdapter = New SqlDataAdapter(myCmd1.CommandText, myConn.openConnection)
        ds.Clear()
        mysqlAdapter.Fill(ds)
        ComboBox_Lang.DataSource = ds.Tables(0)

        ComboBox_Lang.ValueMember = "Name_Language"
        ComboBox_Lang.DisplayMember = "Name_Language"

        myConn.closeConnection()
    End Sub


End Class
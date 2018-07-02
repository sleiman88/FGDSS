Imports System.Data.SqlClient
Imports System.IO

Public Class MainForm
    Public myConn As MyConnection
    Dim FolderBrowserDialog1 As New FolderBrowserDialog()
    Dim MyOmrPic As gdssomr
    Dim dir As DirectoryInfo
    Dim files() As FileInfo


    Private Sub ComboBox_ExamN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_ExamN.SelectedIndexChanged
        fillMyLanguages()
    End Sub

    Sub New()
        myConn = New MyConnection()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

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
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CheckForIllegalCrossThreadCalls = False
        If myConn.checkMyStatus = True Then



            'TODO: This line of code loads data into the 'MyDataSet.Exams_tbl' table. You can move, or remove it, as needed.
            Me.Exams_tblTableAdapter.Fill(Me.MyDataSet.Exams_tbl)

        fillMyLanguages()
        'If checkIfIdErrorExist() = False Then
        '    addMyIdError()
        'End If
        'to insert A b C and Error to exams type 
        If checkIfTypeExist() = False Then
            addType()
        End If

        If checkIfLanguage() = False Then
            addLanguage()
        End If

        Else
            MessageBox.Show("check connection please ")
        End If

    End Sub
    Private Sub addLanguage()
        Try
            Dim cmd As SqlCommand

            Dim querryInsert As String
            querryInsert = "INSERT INTO Exams_Language (Name_Language)  VALUES('Francais');"
            cmd = New SqlCommand(querryInsert, myConn.openConnection)
            cmd.ExecuteNonQuery()
            myConn.closeConnection()
            querryInsert = "INSERT INTO Exams_Language (Name_Language)  VALUES('Arabic');"
            cmd = New SqlCommand(querryInsert, myConn.openConnection)
            cmd.ExecuteNonQuery()
            myConn.closeConnection()
            querryInsert = "INSERT INTO Exams_Language (Name_Language)  VALUES('English');"
            cmd = New SqlCommand(querryInsert, myConn.openConnection)
            cmd.ExecuteNonQuery()
            myConn.closeConnection()


        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function checkIfLanguage()
        Try
            Dim cmd As SqlCommand
            cmd = New SqlCommand("select * from Exams_Language where Name_Language like 'Francais' or Name_Language like 'Arabic '  or Name_Language like 'English'", myConn.openConnection())
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
    Private Function checkIfTypeExist() As Boolean
        Try
            Dim cmd As SqlCommand
            cmd = New SqlCommand("select * from Exams_type where Name_type like 'A' or Name_type like 'B' or Name_type like 'C' or Name_type like 'error'", myConn.openConnection())
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

    Private Sub addType()
        Try
            Dim cmd As SqlCommand

            Dim querryInsert As String
            querryInsert = "INSERT INTO Exams_type (Name_type)  VALUES('A');"
            cmd = New SqlCommand(querryInsert, myConn.openConnection)
            cmd.ExecuteNonQuery()
            myConn.closeConnection()
            querryInsert = "INSERT INTO Exams_type (Name_type)  VALUES('B');"
            cmd = New SqlCommand(querryInsert, myConn.openConnection)
            cmd.ExecuteNonQuery()
            myConn.closeConnection()
            querryInsert = "INSERT INTO Exams_type (Name_type)  VALUES('C');"
            cmd = New SqlCommand(querryInsert, myConn.openConnection)
            cmd.ExecuteNonQuery()
            myConn.closeConnection()
            querryInsert = "INSERT INTO Exams_type (Name_type)  VALUES('error');"
            cmd = New SqlCommand(querryInsert, myConn.openConnection)
            cmd.ExecuteNonQuery()
            myConn.closeConnection()

        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Function checkIfIdErrorExist() As Boolean
    '    Try
    '        Dim cmd As SqlCommand
    '        cmd = New SqlCommand("select * from Scan_tbl where Name_Exam_Scan like 'error'", myConn.openConnection())
    '        Dim reader As SqlDataReader

    '        reader = cmd.ExecuteReader()

    '        If reader.HasRows = False Then
    '            myConn.closeConnection()
    '            Return False
    '        End If
    '        myConn.closeConnection()
    '        Return True
    '    Catch ex As Exception
    '        myConn.closeConnection()

    '        MessageBox.Show(ex.Message)
    '        Return False
    '    End Try
    'End Function
    'Private Sub addMyIdError()
    '    Try

    '        Dim querryInsert As String
    '        querryInsert = "INSERT INTO Scan_tbl (Name_Exam_Scan)  VALUES('error');"
    '        Dim cmd As New SqlCommand(querryInsert, myConn.openConnection)
    '        cmd.ExecuteNonQuery()
    '        myConn.closeConnection()

    '    Catch ex As Exception
    '        myConn.closeConnection()
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub

    Private Sub Btn_NewExam_Click(sender As Object, e As EventArgs) Handles Btn_NewExam.Click
        Dim NewExam As New FAddNewExam(Me)
        NewExam.StartPosition = FormStartPosition.Manual

        NewExam.DesktopLocation = Me.DesktopLocation
        NewExam.Activate()

        NewExam.Show()
    End Sub

    Private Sub Button_browse_Click(sender As Object, e As EventArgs) Handles Button_browse.Click

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TextBox_Path.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button_Start_Click(sender As Object, e As EventArgs) Handles Button_Start.Click
        If ComboBox_ExamN.SelectedValue Is Nothing Then
            MessageBox.Show("Please choose an Exam !!!")
        Else


            If TextBox_desc.Text.Length = 0 Then
                MessageBox.Show("Please add a description like class number or other info!!! ")
            Else
                If TextBox_Path.Text.Length = 0 Then
                    MessageBox.Show("Please choose a folder ")
                Else



                    Button_Start.Enabled = False
                    Dim counter As Int32
                    counter = 0
                    'start action
                    Dim directoryPath As String = TextBox_Path.Text

                    Dim CountFile As Int32 = countFiles()


                    If CountFile <> 0 Then

                        ProgressBar_Action.Visible = True
                        ProgressBar_Action.Minimum = 0
                        ProgressBar_Action.Maximum = CountFile
                        ProgressBar_Action.Step = 1

                        insertNewScan()


                        Dim LastScan As Int32
                        LastScan = getLastScanId()
                        insertNewScanCheck(LastScan)
                        'Dim lst As New List(Of FileInfo)
                        For Each file As FileInfo In files

                            My.Application.Log.WriteEntry("Calling OMR " & file.DirectoryName + "\" + file.Name & ".")
                            ' lst.Add(file)
                            MyOmrPic = New gdssomr(file.DirectoryName + "\" + file.Name, LastScan)

                            MyOmrPic.startdetect(Nothing, Nothing)


                            counter += 1
                            ProgressBar_Action.PerformStep()
                        Next

                        'Dim th1, th2 As Threading.Thread
                        'th1 = New Threading.Thread(AddressOf callGdssOmr)
                        'th2 = New Threading.Thread(AddressOf callGdssOmr)

                        'Dim LastIndexList As Int32
                        'LastIndexList = lst.IndexOf(lst.Last)
                        'Dim tempIndex As Int32
                        'tempIndex = 0

                        'If CountFile Mod 2 <> 0 Then
                        '    th1.Start(lst(0))
                        '    th1.Join()
                        '    counter += 1
                        '    ProgressBar_Action.PerformStep()
                        '    tempIndex = 1

                        'End If
                        'For i = tempIndex To LastIndexList Step 2
                        '    th1.Start(lst(i))
                        '    th2.Start(lst(i + 1))
                        '    th1.Join()
                        '    th2.Join()
                        '    counter += 2
                        '    ProgressBar_Action.PerformStep()
                        '    ProgressBar_Action.PerformStep()
                        'Next


                        My.Computer.Audio.Play("c:\windows\media\Windows Ding.wav", AudioPlayMode.Background)
                        MessageBox.Show("finish Scanned " + counter.ToString + "  Paper")
                            ProgressBar_Action.Value = 0


                    Else

                            MessageBox.Show("non jpg files found ")
                    End If
                    Button_Start.Enabled = True
                End If
            End If
        End If
    End Sub
    'Private Sub callGdssOmr(file As FileInfo)
    '    Dim LastScan As Int32
    '    LastScan = getLastScanId()
    '    MyOmrPic = New gdssomr(file.DirectoryName + "\" + file.Name, LastScan)

    '    MyOmrPic.startdetect(Nothing, Nothing)
    'End Sub
    Private Function getLastScanId() As Int32
        Dim resultID As Int32

        Try
            Dim Dtable As DataTable

            Dim queryId As String
            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            queryId = "Select ISNULL ( Max(Id_Scan ),1) from Scan_tbl;"

            cmd = New SqlCommand(queryId)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)


            resultID = Dtable.Rows(0)(0)

            myConn.closeConnection()


        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try
        Return resultID
    End Function
    Private Sub insertNewScan()
        Try
            Dim query As String
            Dim cmd As SqlCommand
            query = "INSERT INTO Scan_tbl (Description_Scan,Name_Exam_Scan,Name_Language_Scan,Date_Scan,GradedAlready_Scan)
              VALUES(@Description_Scan,@Name_Exam_Scan,@Name_Language_Scan,@Date_Scan,'False');"
            cmd = New SqlCommand(query, myConn.openConnection())
            cmd.Parameters.AddWithValue("@Description_Scan", TextBox_desc.Text)

            cmd.Parameters.AddWithValue("@Name_Exam_Scan", ComboBox_ExamN.SelectedValue)
            cmd.Parameters.AddWithValue("@Name_Language_Scan", ComboBox_Lang.SelectedValue)
            cmd.Parameters.AddWithValue("@Date_Scan", Date.Now.ToString("dd/MM/yyyy HH/mm/ss"))
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
        End Try
        myConn.closeConnection()
    End Sub
    Private Sub insertNewScanCheck(IdScan As Int32)
        Try
            Dim query As String
            Dim cmd As SqlCommand
            query = "INSERT INTO GradeCheck_tbl (StatusGraded_GradeCheck,Id_Scan)
              VALUES(@state,@Id_Scan);"
            cmd = New SqlCommand(query, myConn.openConnection())
            cmd.Parameters.AddWithValue("@Id_Scan", IdScan)
            cmd.Parameters.AddWithValue("@state", "False")


            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
        End Try
        myConn.closeConnection()
    End Sub
    Private Function countFiles() As Integer
        dir = New DirectoryInfo(TextBox_Path.Text)

        files = dir.GetFiles("*.jpg", IO.SearchOption.AllDirectories)
        Dim counter As Int64
        counter = 0
        For Each file As FileInfo In files
            counter += 1

        Next

        Return counter
    End Function

    Private Sub ComboBox_ExamN_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox_ExamN.SelectionChangeCommitted
        fillMyLanguages()
    End Sub

    Private Sub ComboBox_ExamN_Click(sender As Object, e As EventArgs) Handles ComboBox_ExamN.Click
        fillMyLanguages()
    End Sub

    Private Sub Button_GradeAndAnswers_Click(sender As Object, e As EventArgs) Handles Button_GradeAndAnswers.Click
        Dim NewGradeAndAnswers As New GradeAndAnswers(Me)
        NewGradeAndAnswers.StartPosition = FormStartPosition.Manual

        NewGradeAndAnswers.DesktopLocation = Me.DesktopLocation
        NewGradeAndAnswers.Activate()

        NewGradeAndAnswers.Show()
    End Sub
    Dim WithEvents ommm As gdssomr

    Private Sub Button_AddNames_Click(sender As Object, e As EventArgs) Handles Button_AddNames.Click
        If checkIfExist() = False Then
            Dim addNames As New AddExcelNames
            addNames.Show()
        End If

    End Sub
    Private Function checkIfExist() As Boolean
        Dim result As Boolean
        result = False
        Dim reader As SqlDataReader
        Try


            ' Dim querry As String = "select * From PaperOmr_tbl where Path_PaperOmr= @Path_PaperOmr;"
            Dim querry As String = "select * from CandidatNames_tbl"
            Dim cmdChek As SqlCommand
            cmdChek = New SqlCommand(querry, myConn.openConnection())

            reader = cmdChek.ExecuteReader()

            If reader.HasRows Then

                MsgBox(" Names already exist ")

                result = True

            Else
                result = False

            End If
            reader.Close()
        Catch ex As SqlException
            MessageBox.Show("savetoDb check if exist" + ex.Message)
            reader.Close()
            myConn.closeConnection()
        End Try

        myConn.closeConnection()
        Return result
    End Function
End Class

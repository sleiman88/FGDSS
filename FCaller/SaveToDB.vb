Imports System.Data.SqlClient

Public Class SaveToDB
    Dim WithEvents myGdsOmr As gdssomr
    Dim TypeOfExams As String
    Public reader, readerCheck As SqlDataReader
    Dim grade As Int32
    Dim query2, query3 As String
    Dim resolvedPath As String
    Dim conn As New SqlConnection("Data Source=DESKTOP-N9RS2QO;Initial Catalog=FOmrExams;Integrated Security=True")
    Dim myCmd, myCmdId, myCmdQue As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim mysqlAdapter As SqlDataAdapter
    Public Lerror As Label
    Public myconn As New MyConnection()
    Dim TrueAnswer(20) As Char
    Dim CandidatAnswer(20) As Char

    'data base tables

    'desktop-on9kaal\sleimansqlserver.OmrExamsDB.dbo
    'create Exams_tbl tabel 

    '  resomrbookel type of exams 
    Sub New(ByVal omrpic As gdssomr)
        myGdsOmr = omrpic
        myconn = New MyConnection()


        If myGdsOmr.PaperError = True Then

            addPaperWithError(0)
        Else

            If myGdsOmr.resomrbookel Is Nothing Then
                addPaperWithError(1)
                Me.addClientId()
                Me.addQuetion()

            Else
                If myGdsOmr.resomrbookel.Length <> 1 Then
                    addPaperWithError(1)
                    Me.addClientId()
                    Me.addQuetion()
                Else



                    '       




                    Me.addPaper()             ' add paper OMR to DB 
                    Me.addClientId()
                    Me.addQuetion()








                End If
            End If
        End If




    End Sub
    Private Sub addPaperWithError(ref As Int32)
        Try
            Dim query1 As String
            If ref = 0 Then
                query1 = "  insert into PaperOmr_tbl (Path_PaperOmr,Id_Scan,error_exit) values 
        (@Path_PaperOmr,@Id_Scan,'True');"
            Else


                query1 = "  insert into PaperOmr_tbl (Path_PaperOmr,Id_Scan,ResolvedPath_PaperOmr,Id_type) values 
        (@Path_PaperOmr,@Id_Scan,@ResolvedPath_PaperOmr,(select Id_type from Exams_type where Name_type like 'error'));"
            End If

            Dim cmdError As SqlCommand


            cmdError = New SqlCommand(query1, myconn.openConnection())
            cmdError.Parameters.AddWithValue("@Path_PaperOmr", myGdsOmr.imgpath.ToString)
            cmdError.Parameters.AddWithValue("@Id_Scan", myGdsOmr.lastScanId)
            If ref = 1 Then
                cmdError.Parameters.AddWithValue("@ResolvedPath_PaperOmr", myGdsOmr.imgpath.ToString + "_solved.jpg")
            End If

            cmdError.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("savetoDB :addPaperWithErro" + ex.Message)
            myconn.closeConnection()
        End Try
        myconn.closeConnection()
    End Sub
    Private Sub buildTables()
        '    Dim tb1, tb2, tb3, tb4, tb5, tb6, ins1, ins2, ins3, ins4, ins5 As String

        '    tb1 = "   CREATE TABLE Exams_tbl(
        '    [Id_Exams]       Int           IDENTITY (1, 1) Not NULL,
        '    [Name_Exams]     NVARCHAR(50) NULL,
        '    [Boucklet_Exams] NVARCHAR(50) NULL,
        '    PRIMARY KEY CLUSTERED ([Id_Exams] ASC)
        '          );"

        '    tb2 = "
        '    CREATE TABLE PaperOmr_tbl
        '(
        '	Id_PaperOmr      Int           IDENTITY (1, 1) Not NULL,
        '	 Path_PaperOmr     NVARCHAR(100) NULL,
        '    ResolvedPath_PaperOmr NVARCHAR(100) NULL,
        '    DateOfExams   NVARCHAR(50) NULL,
        '     Id_Exams Int FOREIGN KEY REFERENCES Exams_tbl(Id_Exams)
        '	 PRIMARY KEY(Id_PaperOmr ASC)
        ')"
        'tb3 = "

        '    CREATE TABLE PaperOmrId_tbl
        '(
        '	Id_PaperOmrId      Int           IDENTITY (1, 1) Not NULL, 
        '	 D0_PaperOmrId     NVARCHAR(50) NULL,
        '     D1_PaperOmrId     NVARCHAR(50) NULL,
        '     D2_PaperOmrId     NVARCHAR(50) NULL,
        '     D3_PaperOmrId     NVARCHAR(50) NULL,
        '     D4_PaperOmrId     NVARCHAR(50) NULL,
        '     Id_PaperOmr Int FOREIGN KEY REFERENCES PaperOmr_tbl(Id_PaperOmr)
        '	 PRIMARY KEY(Id_PaperOmr ASC)
        ')"
        '    tb4 = "

        'CREATE TABLE PaperOmrQues_tbl
        '(   Id_PaperOmrQues      INT           IDENTITY (1, 1) Not NULL, 
        '	 QuesId_PaperOmrQues NVARCHAR(50) NULL,
        '     QuesAns_paperOmrQues NVARCHAR(50)NULL,
        '     Id_PaperOmr Int FOREIGN KEY REFERENCES PaperOmr_tbl(Id_PaperOmr)
        '	 PRIMARY KEY(Id_PaperOmrQues ASC)
        ')"



        '    tb5 = " CREATE TABLE Answers_tbl
        '(
        '	Id_Answers_tbl     Int           IDENTITY (1, 1) Not NULL, 
        '	QuesID_Ans     NVARCHAR(50) NULL,
        '    Ans_Ans     NVARCHAR(50) NULL,
        '    Id_Exam Int FOREIGN KEY REFERENCES Exams_tbl(Id_Exams)
        '	 PRIMARY KEY(Id_Answers_tbl ASC)
        ')"
        '    tb6 = "  CREATE TABLE Grade_tbl(
        '    [Id_Grade]       Int           IDENTITY (1, 1) Not NULL,
        '    [Grade]     NVARCHAR(50) NULL,
        'Id_PaperOmrId Int FOREIGN KEY REFERENCES PaperOmr_tbl(Id_PaperOmr),
        '   PRIMARY KEY CLUSTERED ([Id_Grade] ASC)
        '          );"

        '    ins1 = "  INSERT INTO Exams_tbl (Name_Exams, Boucklet_Exams)
        'VALUES('Math', 'A');"
        '    ins2 = "
        '    INSERT INTO Exams_tbl (Name_Exams, Boucklet_Exams)
        '    VALUES('Math', 'B');"

        '    ins3 = "  INSERT INTO Exams_tbl (Name_Exams, Boucklet_Exams)
        '    VALUES('Math', 'C');"

        '    ins4 = "   INSERT INTO Exams_tbl (Name_Exams, Boucklet_Exams)
        '    VALUES('Math', 'FFFF');"
        '    ins5 = "   INSERT INTO Exams_tbl (Name_Exams, Boucklet_Exams)
        '    VALUES('error', 'error');"
        '    Try
        '        openConnection()

        '        Dim tableCmd As SqlCommand
        '        tableCmd = New SqlCommand(tb1, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(tb2, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(tb3, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(tb4, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(tb5, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(tb6, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(ins1, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(ins2, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(ins3, conn)
        '        tableCmd.ExecuteNonQuery()
        '        tableCmd = New SqlCommand(ins4, conn)
        '        tableCmd.ExecuteNonQuery()

        '    Catch ex As Exception
        '        closeConnection()
        '        MessageBox.Show("error could not create tables" + ex.Message)


        '    End Try


        '    closeConnection()
    End Sub
    Private Sub checkTables()
        'Try
        '    Dim qq As String
        '    Dim cmdTable As SqlCommand
        '    '   Dim readerTable As SqlDataAdapter
        '    ' readerTable = New SqlDataAdapter()
        '    qq = "Select * From INFORMATION_SCHEMA.TABLES  Where TABLE_SCHEMA = 'dbo'   And TABLE_NAME = 'Exams_tbl'"




        '    openConnection()
        '    cmdTable = New SqlCommand(qq, conn)
        '    Dim readerTable As SqlDataReader = cmdTable.ExecuteReader()


        '    If readerTable.HasRows = False Then
        '        readerTable.Close()
        '        buildTables()
        '        ' MessageBox.Show("table created")
        '    Else


        '        readerTable.Close()
        '        'MessageBox.Show("tables exist ")
        '    End If



        'Catch ex As SqlException
        '    MessageBox.Show("create table" + ex.Message)
        '    closeConnection()
        'End Try
    End Sub

    Private Function getMyGrade(trueAns As Char(), candAns As Char()) As Int32

        'Dim Fgrade As Int32
        'Fgrade = 0

        'For k = 0 To 19

        '    If String.Equals(trueAns(k), candAns(k)) Then

        '        Fgrade = Fgrade + 1
        '    End If

        'Next

        'Return Fgrade
    End Function

    Private Sub insertGradeToDB(Agrade As Integer)
        'Try
        '    Dim Gradecmd As SqlCommand
        '    Dim Gradequerry As String
        '    Gradequerry = "insert into Grade_tbl (Grade,Id_PaperOmrId) values (@Grade,(select Id_PaperOmr  from PaperOmr_tbl  where Path_PaperOmr =@Path_PaperOmr and Id_Exams =@Id_Exams));"
        '    Gradecmd = New SqlCommand(Gradequerry, myconn.openConnection)
        '    Gradecmd.Parameters.AddWithValue("@Path_PaperOmr", myGdsOmr.imgpath.ToString)

        '    Gradecmd.Parameters.AddWithValue("@Id_Exams", myGdsOmr.MyIdExam)
        '    Gradecmd.Parameters.AddWithValue("@Grade", Agrade.ToString)
        '    Gradecmd.ExecuteNonQuery()
        '    myconn.closeConnection()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        '    myconn.closeConnection()
        'End Try
    End Sub

    'Private Function getCandidatAnswersFromDB() As Char()
    'Try
    '    Dim myGdsOmr As New gdssomr("", 1)
    '    Dim temdataSet As New DataSet()
    '    Dim tempSqlAdapter As SqlDataAdapter
    '    Dim candCmd As SqlCommand
    '    Dim query As String
    '    query = "select * from PaperOmrQues_tbl where Id_PaperOmr = (select Id_PaperOmr  from PaperOmr_tbl  where Path_PaperOmr = '" + myGdsOmr.imgpath.ToString + "' and Id_Exams ='" + myGdsOmr.MyIdExam + "') ;"
    '    candCmd = New SqlCommand(query)


    '    tempSqlAdapter = New SqlDataAdapter(candCmd.CommandText, myconn.openConnection)
    '    temdataSet.Clear()
    '    tempSqlAdapter.Fill(temdataSet)
    '    myconn.closeConnection()
    '    Dim Dtable As DataTable = temdataSet.Tables(0)

    '    For k = 0 To 19

    '        CandidatAnswer(k) = Dtable.Rows(k)("QuesAns_paperOmrQues")

    '    Next
    'Catch ex As Exception
    '    myconn.closeConnection()
    '    MessageBox.Show(ex.Message)
    'End Try
    'Dim aa As String


    'Return CandidatAnswer
    'End Function
    ' Private Function getTrueAnswersFromDb() As Char()
    'Try

    '    Dim temdataSet As New DataSet()
    '    Dim tempSqlAdapter As SqlDataAdapter
    '    Dim myCmd1 As SqlCommand
    '    Dim query As String
    '    query = "select * from Answers_tbl where Id_Exam =" + myGdsOmr.MyIdExam + " ;"
    '    myCmd1 = New SqlCommand(query)
    '    tempSqlAdapter = New SqlDataAdapter(myCmd1.CommandText, myconn.openConnection)
    '    temdataSet.Clear()
    '    tempSqlAdapter.Fill(temdataSet)
    '    myconn.closeConnection()
    '    Dim Dtable As DataTable = temdataSet.Tables(0)
    '    'Dim Drow As DataRow
    '    ' Dim Dcolumn As DataColumn

    '    'result = Dtable.Rows(0)("LName")
    '    For k = 0 To 19

    '        TrueAnswer(k) = Dtable.Rows(k)("Ans_Ans")

    '    Next
    'Catch ex As Exception
    '    MessageBox.Show(ex.Message)
    '    myconn.closeConnection()
    'End Try


    'Return TrueAnswer
    'End Function

    Private Sub addPaper()

        '    ' getMygrade(myGdsOmr.MyIdExam,)
        Dim querryAdd As String
        querryAdd = "insert into PaperOmr_tbl (Path_PaperOmr,Id_Scan,ResolvedPath_PaperOmr,Id_type) values 
        (@Path_PaperOmr,@Id_Scan,@ResolvedPath_PaperOmr,(select Id_type from Exams_type where Name_type like '" + myGdsOmr.resomrbookel + "'));"
        Try

            myCmd = New SqlCommand(querryAdd, myconn.openConnection())
            myCmd.Parameters.AddWithValue("@Path_PaperOmr", myGdsOmr.imgpath.ToString)
            myCmd.Parameters.AddWithValue("@ResolvedPath_PaperOmr", myGdsOmr.imgpath.ToString + "_solved.jpg")
            myCmd.Parameters.AddWithValue("@Id_Scan", myGdsOmr.lastScanId)
            myCmd.ExecuteNonQuery()

        Catch ex As SqlException
            myconn.closeConnection()
            MessageBox.Show("querry1" + ex.ToString)


        End Try

        myconn.closeConnection()






    End Sub

    Private Function checkIfExist() As Boolean
        Dim result As Boolean
        result = False
        Try


            ' Dim querry As String = "select * From PaperOmr_tbl where Path_PaperOmr= @Path_PaperOmr;"
            Dim querry As String = "SELECT * FROM 
                                                 PaperOmr_tbl INNER JOIN PaperOmrId_tbl ON PaperOmr_tbl.Id_PaperOmr = PaperOmrId_tbl.Id_PaperOmr 
                                                 Where (PaperOmr_tbl.Path_PaperOmr=@Path_PaperOmr AND PaperOmrId_tbl .D0_PaperOmrId = @D0_paperOmrId And 
                                                 PaperOmrId_tbl.D1_PaperOmrId  =@D1_paperOmrId AND PaperOmrId_tbl .D2_PaperOmrId =@D2_paperOmrId AND 
                                                 PaperOmrId_tbl .D3_PaperOmrId =@D3_paperOmrId And PaperOmrId_tbl .D4_PaperOmrId =@D4_paperOmrId)
                                                  ;"
            Dim cmdChek As SqlCommand
            cmdChek = New SqlCommand(querry, myconn.openConnection())
            For k = 0 To 4
                If String.IsNullOrEmpty(myGdsOmr.resomrid(k)) Then
                    myGdsOmr.resomrid(k) = "empty"
                End If
            Next
            cmdChek.Parameters.AddWithValue("@D0_paperOmrId", myGdsOmr.resomrid(0))
            cmdChek.Parameters.AddWithValue("@D1_paperOmrId", myGdsOmr.resomrid(1))
            cmdChek.Parameters.AddWithValue("@D2_paperOmrId", myGdsOmr.resomrid(2))
            cmdChek.Parameters.AddWithValue("@D3_paperOmrId", myGdsOmr.resomrid(3))
            cmdChek.Parameters.AddWithValue("@D4_paperOmrId", myGdsOmr.resomrid(4))

            cmdChek.Parameters.AddWithValue("@Path_PaperOmr", myGdsOmr.imgpath.ToString)

            reader = cmdChek.ExecuteReader()

            If reader.HasRows Then

                MsgBox(" Paper Already exist  " + myGdsOmr.imgpath.ToString)

                result = True
                reader.Close()
            Else
                result = False

            End If
            reader.Close()
        Catch ex As SqlException
            MessageBox.Show("savetoDb check if exist" + ex.Message)
            myconn.closeConnection()
        End Try

        myconn.closeConnection()
        Return result
    End Function
    Private Sub addClientId()
        Try

            query2 = "insert into PaperOmrId_tbl (D0_paperOmrId,D1_paperOmrId,D2_paperOmrId,D3_paperOmrId,D4_PaperOmrId,Id_PaperOmr) values
(@D0_paperOmrId,@D1_paperOmrId,@D2_paperOmrId,@D3_paperOmrId,@D4_PaperOmrId,(select top 1 Id_PaperOmr  from PaperOmr_tbl where Path_PaperOmr = @imgpath and Id_Scan=@Id_Scan));"

            For k = 0 To 4
                If String.IsNullOrEmpty(myGdsOmr.resomrid(k)) Then
                    myGdsOmr.resomrid(k) = "empty"
                End If
            Next

            myCmdId = New SqlCommand(query2, myconn.openConnection())
            myCmdId.Parameters.AddWithValue("@D0_paperOmrId", myGdsOmr.resomrid(0))
            myCmdId.Parameters.AddWithValue("@D1_paperOmrId", myGdsOmr.resomrid(1))
            myCmdId.Parameters.AddWithValue("@D2_paperOmrId", myGdsOmr.resomrid(2))
            myCmdId.Parameters.AddWithValue("@D3_paperOmrId", myGdsOmr.resomrid(3))
            myCmdId.Parameters.AddWithValue("@D4_paperOmrId", myGdsOmr.resomrid(4))
            myCmdId.Parameters.AddWithValue("@imgpath", myGdsOmr.imgpath.ToString)
            myCmdId.Parameters.AddWithValue("@Id_Scan", myGdsOmr.lastScanId)

            myCmdId.ExecuteNonQuery()


        Catch ex As Exception
            myconn.closeConnection()
            MessageBox.Show("querry2" + ex.ToString)

        End Try
        myconn.closeConnection()
    End Sub
    Private Sub addQuetion()

        Try

            For k = 0 To 19

                query3 = "insert into PaperOmrQues_tbl (QuesId_PaperOmrQues ,QuesAns_paperOmrQues ,Id_PaperOmr ) values
                     (@QuesId_PaperOmrQues,@QuesAns_paperOmrQues,(select top 1 Id_PaperOmr from PaperOmr_tbl where Path_PaperOmr =@imgpath ));"

                'adding the questions with answers 
                myCmd = New SqlCommand(query3, myconn.openConnection())
                myCmd.Parameters.AddWithValue("@QuesId_PaperOmrQues", k.ToString)
                If String.IsNullOrEmpty(myGdsOmr.resomrques(k)) Then
                    myCmd.Parameters.AddWithValue("@QuesAns_paperOmrQues", "empty")
                Else
                    myCmd.Parameters.AddWithValue("@QuesAns_paperOmrQues", myGdsOmr.resomrques(k))
                End If

                myCmd.Parameters.AddWithValue("@imgpath", myGdsOmr.imgpath)

                myCmd.ExecuteNonQuery()

            Next


        Catch ex As Exception
            myconn.closeConnection()
            MessageBox.Show("querry 3" + ex.ToString)



        End Try

        myconn.closeConnection()
    End Sub

















End Class

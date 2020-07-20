Imports System.Data.SqlClient
Public Class MyGrade
    Dim myConn As MyConnection
    Dim IdScan As String
    Dim Caller As AnalyseAndReport
    Sub New(IdScan As String, Caller As AnalyseAndReport)
        myConn = New MyConnection()
        Me.IdScan = IdScan
        Me.Caller = Caller
        startAction()
    End Sub
    Private Sub startAction()
        Try
            Dim QuerryCaller As MyQuerry
            QuerryCaller = New MyQuerry
            Dim reader As SqlDataReader
            Dim Adapter As SqlDataAdapter
            Dim ds As New DataSet()

            Dim cmd As SqlCommand
            cmd = New SqlCommand(QuerryCaller.getQuerryGoodIdforGrades(IdScan))
            Adapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)
            Adapter.Fill(ds)
            Adapter.Dispose()
            Dim Dtable As DataTable = ds.Tables(0)
            Dim LocalIdPaper As String
            Dim ExamId As String
            Dim Grade As String
            Grade = ""
            If Dtable.Rows.Count > 0 Then
                LocalIdPaper = Dtable.Rows(0)(0).ToString
                ExamId = getIdExam(LocalIdPaper)
                Dim TrueAnswerA(20), TrueAnswerB(20), TrueAnswerC(20) As Char
                TrueAnswerA = getTrueAnswer(ExamId, "A")
                TrueAnswerB = getTrueAnswer(ExamId, "B")
                '              TrueAnswerC = getTrueAnswer(ExamId, "C")

                'Dim tempa, tempb, tempc As String
                'tempa = ""
                'tempb = ""
                'tempc = ""
                'For k = 0 To 19
                '    tempa = tempa + TrueAnswerA(k)
                'Next

                'For k = 0 To 19
                '    tempb = tempb + TrueAnswerB(k)
                'Next

                'For k = 0 To 19
                '    tempc = tempc + TrueAnswerC(k)
                'Next

                'MessageBox.Show("a" + tempa + "B" + tempb + "C" + tempc)

                Dim tempType As String
                For i As Integer = 0 To Dtable.Rows.Count - 1
                    ''Dim DataType() As String = myTableData.Rows(i).Item(1)

                    LocalIdPaper = Dtable.Rows(i)(0).ToString
                    ExamId = getIdExam(LocalIdPaper)
                    tempType = GetTypeExam(LocalIdPaper)
                    If String.Equals(tempType, "A") Then
                        Grade = getMyGrade(TrueAnswerA, getCandidatAnswersFromDB(LocalIdPaper)).ToString()

                    ElseIf String.Equals(tempType, "B") Then
                        Grade = getMyGrade(TrueAnswerB, getCandidatAnswersFromDB(LocalIdPaper)).ToString()

                    ElseIf String.Equals(tempType, "C") Then
                        Grade = getMyGrade(TrueAnswerC, getCandidatAnswersFromDB(LocalIdPaper)).ToString()

                    End If

                    insertGradeToDB(LocalIdPaper, ExamId, Grade)
                    Caller.ProgressBar_Grade.PerformStep()
                Next
            End If

            'reader = cmd.ExecuteReader()
            'Dim LocalIdPaper As String

            'While reader.Read = True
            '    LocalIdPaper = reader.GetInt32(0).ToString
            '    MessageBox.Show(LocalIdPaper)
            '    MessageBox.Show(getMyGrade(getTrueAnswersFromDb(getIdExam(LocalIdPaper)), getCandidatAnswersFromDB(LocalIdPaper)).ToString)
            'End While

            'reader.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try




    End Sub

    Private Function GetTypeExam(localIdPaper As String) As String
        Dim type As String
        type = ""
        Try
            Dim querry As String
            querry = " select Name_type from Exams_type join PaperOmr_tbl on Exams_type .Id_type =PaperOmr_tbl .Id_type 
where Id_PaperOmr = " + localIdPaper + ";"

            Dim Dtable As DataTable

            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter


            cmd = New SqlCommand(querry)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)


            type = Dtable.Rows(0)("Name_type").ToString

            myConn.closeConnection()
            sqlAdapter.Dispose()
            Dtable.Dispose()
            Return type
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return "A"
        End Try



    End Function

    Private Function getMyGrade(trueAns As Char(), candAns As Char()) As Int32

        Dim Fgrade As Int32
        Fgrade = 0

        For k = 0 To 19

            If String.Equals(trueAns(k), candAns(k)) Then

                Fgrade = Fgrade + 1
            End If

        Next

        Return Fgrade
    End Function


    Private Sub insertGradeToDB(IdPaper As String, IdExam As String, Grade As String)
        Try
            Dim Gradecmd As SqlCommand
            Dim Gradequerry As String
            Gradequerry = "insert into FinalAnswer_tbl (CandidatNumber_FinalAnswer, Grade_FinalAnswer, ExamName_FinalAnswer, LanguageName_FinalAnswer, Id_PaperOmr, EditedByAdmin_FinalAnswer) 
values ((Select (D0_PaperOmrId +D1_PaperOmrId+D2_PaperOmrId +D3_PaperOmrId +D4_PaperOmrId  ) AS 'Candidat Number' from PaperOmrId_tbl
where Id_PaperOmr=@IdPaper),@Grade,(select Name_Exam from Exams_tbl where Id_Exam =" + IdExam + " ),(select t2.Name_Language_scan  from PaperOmr_tbl as t1 join Scan_tbl as t2 on t1 .Id_Scan =t2.Id_Scan 
where Id_PaperOmr =@IdPaper),@IdPaper,(select EditedByAdmin_PaperOmr from PaperOmr_tbl where Id_PaperOmr=@IdPaper));"
            Gradecmd = New SqlCommand(Gradequerry, myConn.openConnection)
            Gradecmd.Parameters.AddWithValue("@Grade", Grade)
            Gradecmd.Parameters.AddWithValue("@IdPaper", IdPaper)
            Gradecmd.ExecuteNonQuery()
            myConn.closeConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
        End Try
    End Sub

    Private Function getCandidatAnswersFromDB(IdPaper As String) As Char()
        Dim CandidatAnswer(20) As Char
        Try

            Dim temdataSet As New DataSet()
            Dim tempSqlAdapter As SqlDataAdapter
            Dim candCmd As SqlCommand
            Dim query As String
            query = "select * from PaperOmrQues_tbl where Id_PaperOmr =" + IdPaper + "  ;"
            candCmd = New SqlCommand(query)


            tempSqlAdapter = New SqlDataAdapter(candCmd.CommandText, myConn.openConnection)
            temdataSet.Clear()
            tempSqlAdapter.Fill(temdataSet)
            myConn.closeConnection()
            Dim Dtable As DataTable = temdataSet.Tables(0)

            For k = 0 To 19

                CandidatAnswer(k) = Dtable.Rows(k)("QuesAns_paperOmrQues")

            Next
            tempSqlAdapter.Dispose()
            Return CandidatAnswer
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return Nothing
        End Try

    End Function
    Private Function getTrueAnswer(IdExam As String, type As String) As Char()
        Dim TrueAnswerType(20) As Char
        Try

            Dim temdataSet As New DataSet()
            Dim tempSqlAdapter As SqlDataAdapter
            Dim myCmd1 As SqlCommand
            Dim query As String
            query = "select * from Answers_tbl where Id_Exam =(
select T1.Id_Exam from Exams_tbl as T1 join Exams_tbl as T2 
on T1.Name_Exam =T2.Name_Exam and T1.Id_Language =T2.Id_Language 
where t2.Id_Exam =" + IdExam + " and t1.Id_type =(select Id_type from Exams_type where Name_type ='" + type + "'))"

            myCmd1 = New SqlCommand(query)
            tempSqlAdapter = New SqlDataAdapter(myCmd1.CommandText, myConn.openConnection)
            temdataSet.Clear()
            tempSqlAdapter.Fill(temdataSet)
            myConn.closeConnection()
            Dim Dtable As DataTable = temdataSet.Tables(0)
            'Dim Drow As DataRow
            ' Dim Dcolumn As DataColumn

            'result = Dtable.Rows(0)("LName")
            For k = 0 To 19

                TrueAnswerType(k) = Dtable.Rows(k)("Ans_Ans")

            Next
            tempSqlAdapter.Dispose()
            Return TrueAnswerType
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
            Return Nothing
        End Try


    End Function
    Private Function getTrueAnswersFromDb(IdExam As String) As Char()
        Dim TrueAnswer(20) As Char
        Try

            Dim temdataSet As New DataSet()
            Dim tempSqlAdapter As SqlDataAdapter
            Dim myCmd1 As SqlCommand
            Dim query As String
            query = "select * from Answers_tbl where Id_Exam =" + IdExam + " ;"
            myCmd1 = New SqlCommand(query)
            tempSqlAdapter = New SqlDataAdapter(myCmd1.CommandText, myConn.openConnection)
            temdataSet.Clear()
            tempSqlAdapter.Fill(temdataSet)
            myConn.closeConnection()
            Dim Dtable As DataTable = temdataSet.Tables(0)
            'Dim Drow As DataRow
            ' Dim Dcolumn As DataColumn

            'result = Dtable.Rows(0)("LName")
            For k = 0 To 19

                TrueAnswer(k) = Dtable.Rows(k)("Ans_Ans")

            Next
            tempSqlAdapter.Dispose()
            Return TrueAnswer
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
            Return Nothing
        End Try



    End Function
    Private Function getIdExam(IdPaper As String) As String
        Dim ExamId As String
        Try
            Dim querryCaller As MyQuerry
            querryCaller = New MyQuerry()
            Dim querry As String
            querry = querryCaller.getQuerryGetIdExam(IdPaper)




            Dim Dtable As DataTable

            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter


            cmd = New SqlCommand(querry)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)


            ExamId = Dtable.Rows(0)("IdExam").ToString

            myConn.closeConnection()
            sqlAdapter.Dispose()
            Dtable.Dispose()
            Return ExamId
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return "999"
        End Try



    End Function
End Class

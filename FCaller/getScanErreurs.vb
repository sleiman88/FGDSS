Imports System.Data.SqlClient
Public Class getScanErreurs
    Dim IdScan As String
    Dim myConn As MyConnection

    Sub New(IdScan As String)
        Me.IdScan = IdScan
        myConn = New MyConnection
    End Sub

    Public Function getTotalpapers() As Integer
        Dim result As Int32

        Try
            Dim Dtable As DataTable

            Dim query As String
            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            query = "select count(*) from PaperOmr_tbl where Id_Scan =" + IdScan + " Group by Id_Scan ;"

            cmd = New SqlCommand(query)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)
            Else
                result = 0
            End If



            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return 0
        End Try

    End Function

    Public Function getTotalPapersWithErreurs() As Integer


        Dim result As Int32

        Try
            Dim Dtable As DataTable

            Dim queryeR As String
            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            queryeR = "Select count(*) from PaperOmr_tbl where Id_Scan = " + IdScan + "  And error_exit ='True' Group by Id_Scan;"

            cmd = New SqlCommand(queryeR)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)
            Else
                result = 0
            End If
            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return 0
        End Try


        Return 0
    End Function

    Public Function getTotalPapersWithIdErreurs() As Integer
        Dim result As Int32

        Try
            Dim Dtable As DataTable

            Dim queryId As String
            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            queryId = "select count(*) from PaperOmr_tbl join PaperOmrId_tbl on PaperOmr_tbl .Id_PaperOmr =PaperOmrId_tbl .Id_PaperOmr 
where Id_Scan =" + IdScan + " And error_exit IS  NULL And (D0_PaperOmrId not Like '_' or D1_PaperOmrId not Like '_' or D2_PaperOmrId not Like '_' or D3_PaperOmrId not Like '_' or D4_PaperOmrId not Like '_'
or D4_PaperOmrId not Like '_') Group by Id_Scan ;"

            cmd = New SqlCommand(queryId)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)
            Else
                result = 0
            End If
            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return 0
        End Try


        Return 0



    End Function

    Public Function getTotalPapersWithTypeExamErreurs() As Integer

        Dim result As Int32

        Try
            Dim Dtable As DataTable

            Dim queryId As String
            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            queryId = "select count(*) from PaperOmr_tbl where Id_Scan=" + IdScan + " And Id_type =(select Id_type from Exams_type where Name_type='error') group by Id_Scan ;"

            cmd = New SqlCommand(queryId)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)


            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)
            Else
                result = 0
            End If
            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return 0
        End Try


        Return 0



    End Function
    Public Function getTotalGood() As Int32
        Dim result As Int32

        Try
            Dim Dtable As DataTable

            Dim queryGood As String
            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            queryGood = "select count(ResolvedPath_PaperOmr) From  PaperOmr_tbl join PaperOmrId_tbl on PaperOmr_tbl .Id_PaperOmr =PaperOmrId_tbl .Id_PaperOmr 
where   error_exit IS  NULL And (D0_PaperOmrId  Like '_' And D1_PaperOmrId  Like '_' And D2_PaperOmrId  Like '_' And D3_PaperOmrId  Like '_' And D4_PaperOmrId  Like '_'
And D4_PaperOmrId  Like '_') And Id_Scan=" + IdScan + " And Id_type <>(select Id_type from Exams_type where Name_type='error') 
And PaperOmr_tbl.Id_PaperOmr not in 

(

select T4.Id_PaperOmr from 
(select D0_PaperOmrId ,D1_PaperOmrId ,D2_PaperOmrId ,D3_PaperOmrId ,D4_PaperOmrId From  
PaperOmrId_tbl As T1 join PaperOmr_tbl As T2 
on T1.Id_PaperOmr =T2.Id_PaperOmr 
where T2.Id_Scan =" + IdScan + "
group by D0_PaperOmrId ,D1_PaperOmrId ,D2_PaperOmrId ,D3_PaperOmrId ,D4_PaperOmrId
having count(T2.Id_PaperOmr )>1)  AS T1  join( Select PaperOmrId_tbl.Id_PaperOmr,D0_PaperOmrId,D1_PaperOmrId ,D2_PaperOmrId,D3_PaperOmrId,D4_PaperOmrId From   PaperOmrId_tbl  join PaperOmr_tbl on PaperOmrId_tbl.Id_PaperOmr= PaperOmr_tbl.Id_PaperOmr where Id_Scan =" + IdScan + ") As T4 on 
T1.D0_PaperOmrId=T4.D0_PaperOmrId And T1.D1_PaperOmrId=T4.D1_PaperOmrId And T1.D2_PaperOmrId=T4.D2_PaperOmrId And T1.D3_PaperOmrId=T4.D3_PaperOmrId And T1.D4_PaperOmrId=T4.D4_PaperOmrId
) 

And PaperOmr_tbl.Id_PaperOmr not in 
(

Select T7.Id_PaperOmr   from (

Select T12.D0_PaperOmrId ,T12.D1_PaperOmrId ,T12.D2_PaperOmrId ,T12.D3_PaperOmrId ,T12.D4_PaperOmrId From 

(select T1.D0_PaperOmrId ,t1.D1_PaperOmrId ,T1 .D2_PaperOmrId ,T1.D3_PaperOmrId ,t1.D4_PaperOmrId  from PaperOmrId_tbl as T1 join 
PaperOmr_tbl As T2 on T1.Id_PaperOmr =T2.Id_PaperOmr 
where T2.Id_Scan =" + IdScan + ") AS T12

join 
(
select T3.D0_PaperOmrId ,T3.D1_PaperOmrId ,T3 .D2_PaperOmrId ,T3.D3_PaperOmrId ,T3.D4_PaperOmrId  from PaperOmrId_tbl as T3 join 
PaperOmr_tbl As T4 on T3.Id_PaperOmr =T4.Id_PaperOmr 

where T4.Id_Scan <>" + IdScan + " and T4.Id_Scan in (select TscanId2 .Id_Scan from Scan_tbl as TscanId1 join Scan_tbl as TscanId2
                                              on TscanId1 .Name_Exam_Scan =TscanId2 .Name_Exam_Scan and TscanId1 .Name_Language_scan =TscanId2 .Name_Language_scan 
                                              where TscanId1 .Id_Scan =" + IdScan + ")) AS T34
on
T12.D0_PaperOmrId=T34.D0_PaperOmrId And T12.D1_PaperOmrId=T34.D1_PaperOmrId And T12.D2_PaperOmrId=T34.D2_PaperOmrId And T12.D3_PaperOmrId=T34.D3_PaperOmrId And T12.D4_PaperOmrId=T34.D4_PaperOmrId
 

) AS T5 join PaperOmrId_tbl  AS T6 on 
T5.D0_PaperOmrId=T6.D0_PaperOmrId And T5.D1_PaperOmrId=T6.D1_PaperOmrId And T5.D2_PaperOmrId=T6.D2_PaperOmrId 
  join PaperOmr_tbl AS T7 on T6.Id_PaperOmr =T7 .Id_PaperOmr 
  where (T6.Id_PaperOmr In(select Id_PaperOmr from PaperOmr_tbl where Id_Scan IN(select TscanId2 .Id_Scan from Scan_tbl as TscanId1 join Scan_tbl as TscanId2
                                              on TscanId1 .Name_Exam_Scan =TscanId2 .Name_Exam_Scan and TscanId1 .Name_Language_scan =TscanId2 .Name_Language_scan 
                                              where TscanId1 .Id_Scan =" + IdScan + "))
              And T5.D3_PaperOmrId=T6.D3_PaperOmrId And T5.D4_PaperOmrId=T6.D4_PaperOmrId)

);"

            cmd = New SqlCommand(queryGood)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)
            Else
                result = 0
            End If
            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return 0
        End Try


        Return 0

    End Function
    Public Function getDuplicatedWithOtherScan() As Int32
        Dim result As Int32

        Try
            Dim Dtable As DataTable


            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            Dim querry As String
            querry = "Select count(T7.ResolvedPath_PaperOmr)  from (

Select T12.D0_PaperOmrId ,T12.D1_PaperOmrId ,T12.D2_PaperOmrId ,T12.D3_PaperOmrId ,T12.D4_PaperOmrId From 

(select T1.D0_PaperOmrId ,t1.D1_PaperOmrId ,T1 .D2_PaperOmrId ,T1.D3_PaperOmrId ,t1.D4_PaperOmrId  from PaperOmrId_tbl as T1 join 
PaperOmr_tbl As T2 on T1.Id_PaperOmr =T2.Id_PaperOmr 
where T2.Id_Scan =" + IdScan + ") AS T12

join 
(
select T3.D0_PaperOmrId ,T3.D1_PaperOmrId ,T3 .D2_PaperOmrId ,T3.D3_PaperOmrId ,T3.D4_PaperOmrId  from PaperOmrId_tbl as T3 join 
PaperOmr_tbl As T4 on T3.Id_PaperOmr =T4.Id_PaperOmr 

where T4.Id_Scan <>" + IdScan + " and T4.Id_Scan in (select TscanId2 .Id_Scan from Scan_tbl as TscanId1 join Scan_tbl as TscanId2
                                              on TscanId1 .Name_Exam_Scan =TscanId2 .Name_Exam_Scan and TscanId1 .Name_Language_scan =TscanId2 .Name_Language_scan 
                                              where TscanId1 .Id_Scan =" + IdScan + ")) AS T34
on
T12.D0_PaperOmrId=T34.D0_PaperOmrId And T12.D1_PaperOmrId=T34.D1_PaperOmrId And T12.D2_PaperOmrId=T34.D2_PaperOmrId And T12.D3_PaperOmrId=T34.D3_PaperOmrId And T12.D4_PaperOmrId=T34.D4_PaperOmrId
 

) AS T5 join PaperOmrId_tbl  AS T6 on 
T5.D0_PaperOmrId=T6.D0_PaperOmrId And T5.D1_PaperOmrId=T6.D1_PaperOmrId And T5.D2_PaperOmrId=T6.D2_PaperOmrId 
  join PaperOmr_tbl AS T7 on T6.Id_PaperOmr =T7 .Id_PaperOmr 
  where (T6.Id_PaperOmr In(select Id_PaperOmr from PaperOmr_tbl where Id_Scan IN(select TscanId2 .Id_Scan from Scan_tbl as TscanId1 join Scan_tbl as TscanId2
                                              on TscanId1 .Name_Exam_Scan =TscanId2 .Name_Exam_Scan and TscanId1 .Name_Language_scan =TscanId2 .Name_Language_scan 
                                              where TscanId1 .Id_Scan =" + IdScan + "))
              And T5.D3_PaperOmrId=T6.D3_PaperOmrId And T5.D4_PaperOmrId=T6.D4_PaperOmrId)
"


            cmd = New SqlCommand(querry)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)
                result = result / 2
            Else
                result = 0
            End If
            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return 0
        End Try


        Return 0
    End Function
    Public Function getDuplicatedId()



        Dim result As Int32

        Try
            Dim Dtable As DataTable
            Dim querry As String
            querry = "select count(T4.Id_PaperOmr) from 
(select D0_PaperOmrId ,D1_PaperOmrId ,D2_PaperOmrId ,D3_PaperOmrId ,D4_PaperOmrId From  
PaperOmrId_tbl As T1 join PaperOmr_tbl As T2 
on T1.Id_PaperOmr =T2.Id_PaperOmr 
where T2.Id_Scan =" + IdScan + "
group by D0_PaperOmrId ,D1_PaperOmrId ,D2_PaperOmrId ,D3_PaperOmrId ,D4_PaperOmrId
having count(T2.Id_PaperOmr )>1)  AS T1  join( Select PaperOmrId_tbl.Id_PaperOmr,D0_PaperOmrId,D1_PaperOmrId ,D2_PaperOmrId,D3_PaperOmrId,D4_PaperOmrId
From   PaperOmrId_tbl  join PaperOmr_tbl on PaperOmrId_tbl.Id_PaperOmr= PaperOmr_tbl.Id_PaperOmr where Id_Scan =" + IdScan + ") As T4 
on 
T1.D0_PaperOmrId=T4.D0_PaperOmrId And T1.D1_PaperOmrId=T4.D1_PaperOmrId And T1.D2_PaperOmrId=T4.D2_PaperOmrId And T1.D3_PaperOmrId=T4.D3_PaperOmrId And T1.D4_PaperOmrId=T4.D4_PaperOmrId
"

            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter

            cmd = New SqlCommand(querry)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)
                result = result
            Else
                result = 0
            End If
            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return 0
        End Try


        Return 0




    End Function
End Class

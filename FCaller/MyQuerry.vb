Public Class MyQuerry


    Public Function getQuerryDataGridNotScanned(IdScan As String) As String
        Dim temp As String
        temp = "Select Path_PaperOmr As 'Path', count(*) over() As 'count' From PaperOmr_tbl Where Id_Scan =" + IdScan + " And error_exit ='True' ;"
        Return temp
    End Function
    Public Function getQuerryDataGridDuplicated(IdScan As String) As String
        Dim querry As String
        querry = "select ResolvedPath_PaperOmr AS 'Path' , count(*) over() As 'count' from 
								(select D0_PaperOmrId ,D1_PaperOmrId ,D2_PaperOmrId ,D3_PaperOmrId ,D4_PaperOmrId From  
								PaperOmrId_tbl As T1 join PaperOmr_tbl As T2 
								on T1.Id_PaperOmr =T2.Id_PaperOmr 
								where T2.Id_Scan =" + IdScan + "
								group by D0_PaperOmrId ,D1_PaperOmrId ,D2_PaperOmrId ,D3_PaperOmrId ,D4_PaperOmrId
								having count(T2.Id_PaperOmr )>1)  AS T1     join         
								                                            ( Select PaperOmrId_tbl.Id_PaperOmr,D0_PaperOmrId,D1_PaperOmrId ,D2_PaperOmrId,D3_PaperOmrId,D4_PaperOmrId,ResolvedPath_PaperOmr,Path_PaperOmr
								                                              From   PaperOmrId_tbl  join PaperOmr_tbl on PaperOmrId_tbl.Id_PaperOmr= PaperOmr_tbl.Id_PaperOmr where Id_Scan =" + IdScan + ") As T4 
								                                             on 
								                                                   T1.D0_PaperOmrId=T4.D0_PaperOmrId And T1.D1_PaperOmrId=T4.D1_PaperOmrId And T1.D2_PaperOmrId=T4.D2_PaperOmrId And T1.D3_PaperOmrId=T4.D3_PaperOmrId And T1.D4_PaperOmrId=T4.D4_PaperOmrId
"
        Return querry
    End Function

    Public Function getQuerryDataGridDuplicatedWithOtherScan(IdScan As String) As String
        Dim querry As String
        querry = "with countDistinct_by_ID_and_Material as (
SELECT paperomrid_tbl.d0_paperomrid, paperomrid_tbl.d1_paperomrid, paperomrid_tbl .d2_paperomrid, paperomrid_tbl.d3_paperomrid, paperomrid_tbl.d4_paperomrid,name_language_scan,name_exam_scan ,Scan_tbl.Id_Scan,
dense_rank() over (partition by paperomrid_tbl.d0_paperomrid, paperomrid_tbl.d1_paperomrid, paperomrid_tbl .d2_paperomrid, paperomrid_tbl.d3_paperomrid, paperomrid_tbl.d4_paperomrid,name_language_scan,name_exam_scan 
order by paperomr_tbl.Id_Scan
) + dense_rank() over (partition by paperomrid_tbl.d0_paperomrid, paperomrid_tbl.d1_paperomrid, paperomrid_tbl .d2_paperomrid, paperomrid_tbl.d3_paperomrid, paperomrid_tbl.d4_paperomrid,name_language_scan,name_exam_scan 
order by paperomr_tbl.Id_Scan desc) - 1 as distinctScans
FROM   paperomrid_tbl JOIN paperomr_tbl ON paperomrid_tbl.id_paperomr = paperomr_tbl.id_paperomr 
JOIN Scan_tbl ON paperomr_tbl.Id_Scan = Scan_tbl.Id_Scan
),
T2 as (
select Id_Paperomrid,D0_PaperOmrId,D1_PaperOmrId,D2_PaperOmrId,D3_PaperOmrId,D4_PaperOmrId,name_language_scan,name_exam_scan,paperomr_tbl.Id_Scan,resolvedpath_paperomr FROM paperomrid_tbl 
JOIN paperomr_tbl ON paperomrid_tbl.id_paperomr = paperomr_tbl.id_paperomr 
JOIN Scan_tbl ON paperomr_tbl.Id_Scan = Scan_tbl.Id_Scan
)

select Id_Scan As 'Scan',resolvedpath_paperomr As 'Path',count(*) over() As 'count' from
(select d0_paperomrid, d1_paperomrid, d2_paperomrid, d3_paperomrid, d4_paperomrid,name_language_scan,name_exam_scan from 
countDistinct_by_ID_and_Material where distinctScans >1 and Id_Scan =" + IdScan + ")T1
JOIN T2
on T1.d0_paperomrid = T2.d0_paperomrid AND T1.d1_paperomrid = T2.d1_paperomrid AND T1.d2_paperomrid = T2.d2_paperomrid AND T1.d3_paperomrid = T2.d3_paperomrid AND T1.d4_paperomrid = T2.d4_paperomrid AND T1.name_exam_scan = T2 .name_exam_scan AND T1 .name_language_scan = T2.name_language_scan 
"
        Return querry
    End Function



    Public Function getQuerryDataGridIdErrors(IdScan As String) As String
        Dim querry As String
        querry = "select ResolvedPath_PaperOmr As 'Path' , count(*) over() As 'count' from PaperOmr_tbl join PaperOmrId_tbl on PaperOmr_tbl .Id_PaperOmr =PaperOmrId_tbl .Id_PaperOmr 
where Id_Scan =" + IdScan + " And error_exit IS  NULL And (D0_PaperOmrId not Like '_' or D1_PaperOmrId not Like '_' or D2_PaperOmrId not Like '_' or D3_PaperOmrId not Like '_' or D4_PaperOmrId not Like '_'
or D4_PaperOmrId not Like '_')  ;"

        Return querry
    End Function

    Public Function getQuerryDataGridTypeExamError(IdScan As String) As String
        Dim querry As String
        querry = "select ResolvedPath_PaperOmr As 'Path'  , count(*) over() As 'count' from PaperOmr_tbl where Id_Scan=" + IdScan + " And Id_type =(select Id_type from Exams_type where Name_type='error')  ;"
        Return querry
    End Function

    Public Function getQuerryDataGridGood(IdScan As String) As String
        Dim query As String
        query = "SELECT Min(resolvedpath_paperomr) AS resolvedpath_paperomr , count(*) over() As 'count'
FROM   paperomr_tbl JOIN paperomrid_tbl ON paperomr_tbl.id_paperomr = paperomrid_tbl.id_paperomr 
WHERE  error_exit IS NULL 
       AND d0_paperomrid LIKE '_' 
       AND d1_paperomrid LIKE '_' 
       AND d2_paperomrid LIKE '_' 
       AND d3_paperomrid LIKE '_' 
       AND d4_paperomrid LIKE '_' 
       AND id_scan = " + IdScan + "
       AND id_type <> (SELECT id_type 
                       FROM   exams_type 
                       WHERE  name_type = 'error') 
GROUP  BY d0_paperomrid, 
          d1_paperomrid, 
          d2_paperomrid, 
          d3_paperomrid, 
          d4_paperomrid 
HAVING Count(*) = 1 
ORDER  BY Min(paperomrid_tbl.id_paperomr) "
        Return query
    End Function
    Public Function getQuerryGoodIdforGrades(IdScan As String) As String
        Dim querry As String
        querry = "SELECT Min( paperomr_tbl.Id_PaperOmr) AS resolvedpath_paperomr 
FROM   paperomr_tbl JOIN paperomrid_tbl ON paperomr_tbl.id_paperomr = paperomrid_tbl.id_paperomr 
WHERE  error_exit IS NULL 
       AND d0_paperomrid LIKE '_' 
       AND d1_paperomrid LIKE '_' 
       AND d2_paperomrid LIKE '_' 
       AND d3_paperomrid LIKE '_' 
       AND d4_paperomrid LIKE '_' 
       AND id_scan = " + IdScan + "
       AND id_type <> (SELECT id_type 
                       FROM   exams_type 
                       WHERE  name_type = 'error') 
GROUP  BY d0_paperomrid, 
          d1_paperomrid, 
          d2_paperomrid, 
          d3_paperomrid, 
          d4_paperomrid 
HAVING Count(*) = 1 
ORDER  BY Min(paperomrid_tbl.id_paperomr) "
        Return querry
    End Function


    Public Function getQuerryGetIdExam(IdPaper As String) As String
        Dim querry As String
        querry = "select t2.Id_Exam AS IdExam  from PaperOmr_tbl as t1 join Exams_tbl as t2 on t1.Id_type =t2 .Id_type 
                                 join Scan_tbl  as t3 on t1.Id_Scan =t3.Id_Scan 
								 join Exams_Language as t4 on t2.Id_Language=t4.Id_Language 
		where t1.Id_PaperOmr=" + IdPaper + " 
		And   t2.Name_Exam =t3.Name_Exam_Scan 
		And  t3.Name_Language_scan =t4.Name_Language ;"
        Return querry
    End Function

End Class

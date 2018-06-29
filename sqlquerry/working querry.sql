declare @IdScan int
set @IdScan=42
(

select Id_PaperOmr from PaperOmr_tbl 
where Id_PaperOmr In(
								(select T1 .Id_PaperOmr from PaperOmrId_tbl as T1 join 
								PaperOmr_tbl As T2 on T1.Id_PaperOmr =T2.Id_PaperOmr 
								where T2.Id_Scan =@IdScan ) AS T12 join 

(

select T3.Id_PaperOmr   from PaperOmrId_tbl as T3 join 
PaperOmr_tbl As T4 on T3.Id_PaperOmr =T4.Id_PaperOmr  
where T4.Id_Scan <>@IdScan And t4.Id_Scan IN (select TscanId2 .Id_Scan from Scan_tbl as TscanId1 join Scan_tbl as TscanId2
                                              on TscanId1 .Name_Exam_Scan =TscanId2 .Name_Exam_Scan and TscanId1 .Name_Language_scan =TscanId2 .Name_Language_scan 
                                              where TscanId1 .Id_Scan =@IdScan)
                                               ) AS T34 
								 on T12.Id_PaperOmr=T34.Id_PaperOmr
								 )




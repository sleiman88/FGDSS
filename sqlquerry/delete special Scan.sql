USE FOmrExams ;
declare @IdScan int
set @IdScan=50
delete from PaperOmrQues_tbl where Id_PaperOmr IN(select Id_PaperOmr from PaperOmr_tbl where Id_Scan =@IdScan);
delete from PaperOmrId_tbl where Id_PaperOmr IN(select Id_PaperOmr from PaperOmr_tbl where Id_Scan =@IdScan);
delete from FinalAnswer_tbl where Id_PaperOmr IN(select Id_PaperOmr from PaperOmr_tbl where Id_Scan =@IdScan);
delete from PaperOmr_tbl  where Id_Scan =@IdScan;

delete from GradeCheck_tbl where Id_Scan =@IdScan;
delete from Scan_tbl  where Id_Scan =@IdScan;

use FOmrExamsDB 
CREATE PROCEDURE Insert3Languages
AS
INSERT INTO Exams_Language (Name_Language)  VALUES('Francais');
INSERT INTO Exams_Language (Name_Language)  VALUES('Arabic');
INSERT INTO Exams_Language (Name_Language)  VALUES('English');
GO

CREATE PROCEDURE InsertExamsType
AS
INSERT INTO Exams_type (Name_type)  VALUES('A');
INSERT INTO Exams_type (Name_type)  VALUES('B');
INSERT INTO Exams_type (Name_type)  VALUES('C');
INSERT INTO Exams_type (Name_type)  VALUES('error');

GO


CREATE PROCEDURE getLastScanId
AS
Select ISNULL ( Max(Id_Scan ),1) from Scan_tbl;

GO

CREATE PROCEDURE getAllCandidat
AS
select * from CandidatNames_tbl;

GO



GO

CREATE PROCEDURE getWithIdError @IdScan nvarchar(30) = NULL
AS
select ResolvedPath_PaperOmr As 'Path' , count(*) over() As 'count' from PaperOmr_tbl join PaperOmrId_tbl on PaperOmr_tbl .Id_PaperOmr =PaperOmrId_tbl .Id_PaperOmr 
where Id_Scan =@IdScan  And error_exit IS  NULL And (D0_PaperOmrId not Like '_' or D1_PaperOmrId not Like '_' or D2_PaperOmrId not Like '_' or D3_PaperOmrId not Like '_' or D4_PaperOmrId not Like '_'
or D4_PaperOmrId not Like '_')  
GO

CREATE PROCEDURE getNotAllowed @IdScan nvarchar(30) = NULL
AS
select ResolvedPath_PaperOmr As 'Path' , count(*) over() As 'count' from  PaperOmr_tbl join PaperOmrId_tbl on PaperOmr_tbl .Id_PaperOmr =PaperOmrId_tbl .Id_PaperOmr 
where Id_Scan =@IdScan 
and concat(D0_PaperOmrId ,D1_PaperOmrId ,D2_PaperOmrId ,D3_PaperOmrId ,D4_PaperOmrId )not IN (select CandidatNumber_Candidat from  CandidatNames_tbl  )
GO
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
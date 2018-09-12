USE FOmrExams ;

CREATE TABLE CandidatNames_tbl(
        [Id_Candidat]       Int           IDENTITY (1, 1) Not NULL,
        [CandidatNumber_Candidat]     NVARCHAR(10) NULL,
		 [CandidatName_Candidat]     NVARCHAR(60) Collate Arabic_100_CS_AI_KS_WS_SC  NULL,
		  [CandidatName_Rank]     NVARCHAR(60) Collate Arabic_100_CS_AI_KS_WS_SC  NULL,
		   [CandidatName_Station]     NVARCHAR(60) Collate Arabic_100_CS_AI_KS_WS_SC  NULL,
        PRIMARY KEY CLUSTERED ([Id_Candidat] ASC)
              );





CREATE TABLE Exams_type(
        [Id_type]       Int           IDENTITY (1, 1) Not NULL,
        [Name_type]     NVARCHAR(10) NULL,
        PRIMARY KEY CLUSTERED ([Id_type] ASC)
              );





 CREATE TABLE Exams_Language(
        [Id_Language]       Int           IDENTITY (1, 1) Not NULL,
        [Name_Language]     NVARCHAR(50) NULL,
        PRIMARY KEY CLUSTERED (Id_Language ASC)
              );



			   CREATE TABLE Exams_tbl
    (
    	Id_Exam      Int           IDENTITY (1, 1) Not NULL,
    	Name_Exam     NVARCHAR(50) NULL,
         Id_type Int FOREIGN KEY REFERENCES Exams_type(Id_type),
         Id_Language Int FOREIGN KEY REFERENCES Exams_Language(Id_Language),
    	 PRIMARY KEY(Id_Exam  ASC)
    )



	 CREATE TABLE Scan_tbl
    (
    	Id_Scan     Int     IDENTITY (1, 1) Not NULL,
    	description_Scan    NVARCHAR(100) NULL,
		Name_Exam_Scan          NVARCHAR(50) NULL,
		Name_Language_scan       NVARCHAR(50) NULL,
		Date_scan       NVARCHAR(100) NULL,
        GradedAlready_Scan   NVARCHAR(20) NULL,
    	 PRIMARY KEY(Id_Scan  ASC)
    )



			   CREATE TABLE PaperOmr_tbl
    (
    	Id_PaperOmr      Int           IDENTITY (1, 1) Not NULL,
    	Path_PaperOmr     NVARCHAR(100) NULL,
		ResolvedPath_PaperOmr     NVARCHAR(100) NULL,
		error_exit     NVARCHAR(50) NULL,
		EditedByAdmin_PaperOmr NVARCHAR(10) NULL,
         Id_Scan Int FOREIGN KEY REFERENCES Scan_tbl(Id_Scan),
		 Id_type Int FOREIGN KEY REFERENCES Exams_type(Id_type),
    	 PRIMARY KEY(Id_PaperOmr  ASC)
    )


	    

            CREATE TABLE PaperOmrId_tbl
        (
        	 Id_PaperOmrId      Int           IDENTITY (1, 1) Not NULL, 
        	 D0_PaperOmrId     NVARCHAR(20) NULL,
             D1_PaperOmrId     NVARCHAR(20) NULL,
             D2_PaperOmrId     NVARCHAR(20) NULL,
             D3_PaperOmrId     NVARCHAR(20) NULL,
             D4_PaperOmrId     NVARCHAR(20) NULL,
             Id_PaperOmr Int FOREIGN KEY REFERENCES PaperOmr_tbl(Id_PaperOmr),
        	 PRIMARY KEY(Id_PaperOmrId ASC)
        )



		   CREATE TABLE PaperOmrQues_tbl
        (   Id_PaperOmrQues      INT           IDENTITY (1, 1) Not NULL, 
        	 QuesId_PaperOmrQues NVARCHAR(10) NULL,
             QuesAns_paperOmrQues NVARCHAR(10)NULL,
             Id_PaperOmr Int FOREIGN KEY REFERENCES PaperOmr_tbl(Id_PaperOmr)
        	 PRIMARY KEY(Id_PaperOmrQues ASC)
        )




		   CREATE TABLE ExamsCheckAns_tbl
        (   Id_ExamsCheckAns     INT           IDENTITY (1, 1) Not NULL, 
        	State_ExamsCheckAns NVARCHAR(20) NULL,
            Id_Exam   Int FOREIGN KEY REFERENCES Exams_tbl(Id_Exam  )
        	PRIMARY KEY(Id_ExamsCheckAns ASC)
        )



		   CREATE TABLE Answers_tbl
    (
    	Id_Answers_tbl     Int           IDENTITY (1, 1) Not NULL, 
    	QuesID_Ans     NVARCHAR(10) NULL,
        Ans_Ans     NVARCHAR(10) NULL,
        Id_Exam Int FOREIGN KEY REFERENCES Exams_tbl(Id_Exam)
    	 PRIMARY KEY(Id_Answers_tbl ASC)
    )


	
		   CREATE TABLE GradeCheck_tbl
    (
    	Id_GradeCheck    Int           IDENTITY (1, 1) Not NULL, 
    	StatusGraded_GradeCheck     NVARCHAR(10) NULL,
		Id_Scan Int FOREIGN KEY REFERENCES Scan_tbl(Id_Scan),
    	 PRIMARY KEY(Id_GradeCheck  ASC)
    )

	
		   CREATE TABLE FinalAnswer_tbl
    (
    	Id_FinalAnswer_tbl    Int           IDENTITY (1, 1) Not NULL, 
		CandidatNumber_FinalAnswer  NVARCHAR(20) NULL,
    	Grade_FinalAnswer     NVARCHAR(10) NULL,
		ExamName_FinalAnswer  NVARCHAR(50) NULL,
		LanguageName_FinalAnswer NVARCHAR(50) NULL,
		EditedByAdmin_FinalAnswer NVARCHAR(10) NULL,
        Id_PaperOmr Int FOREIGN KEY REFERENCES PaperOmr_tbl(Id_PaperOmr)
    	 PRIMARY KEY(Id_FinalAnswer_tbl  ASC)
    )
CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(30)
)
INSERT INTO Students (  Name)
	VALUES 
	('Mila'),
	('Toni'),
	('Ron')

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(30)
)

INSERT INTO Exams ( Name)
	VALUES 
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

CREATE TABLE StudentsExams
 (
 StudentID INT  FOREIGN KEY REFERENCES Students(StudentID),
 ExamID INT  FOREIGN KEY REFERENCES Exams(ExamID)
 PRIMARY KEY(StudentID, ExamID)
 )




 SELECT * FROM StudentsExams


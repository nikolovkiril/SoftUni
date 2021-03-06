--CREATE DATABASE UniversityDatabase

--USE UniversityDatabase

CREATE TABLE Majors
(
	MajorID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(20)
)


CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY NOT NULL,
	StudentNumber VARCHAR(10),
	StudentName VARCHAR(30),
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT IDENTITY PRIMARY KEY NOT NULL,
	PaymentDate DATE,
	PaymentAmount DECIMAL(6,2),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT IDENTITY PRIMARY KEY NOT NULL,
	SubjectName VARCHAR(100)
)

CREATE TABLE Agenda
(
	StudentID INT  FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT  FOREIGN KEY REFERENCES Subjects(SubjectID)
	PRIMARY KEY (StudentID,SubjectID)
)

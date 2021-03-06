--CREATE DATABASE Bitbucket
--USE Bitbucket

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY ,
	Username VARCHAR(30) NOT NULL,
	[Password]  VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL 
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY ,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT   REFERENCES Repositories(Id),
	ContributorId INT   REFERENCES Users(Id)
	PRIMARY KEY (RepositoryId,ContributorId)
)


CREATE TABLE Issues 
(
	Id INT PRIMARY KEY IDENTITY ,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT    REFERENCES Repositories(Id),
	AssigneeId INT    REFERENCES Users(Id)
)

CREATE TABLE Commits 
(
	Id INT PRIMARY KEY IDENTITY ,
	[Message] VARCHAR(255) NOT NULL,
	IssueId  INT   REFERENCES Issues(Id),
	RepositoryId INT    REFERENCES Repositories(Id),
	ContributorId INT    REFERENCES Users(Id)
)

CREATE TABLE Files 
(
	Id INT PRIMARY KEY IDENTITY ,
	[Name] VARCHAR(100) NOT NULL,
	Size  DECIMAL (15,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT  REFERENCES Commits(Id)
)
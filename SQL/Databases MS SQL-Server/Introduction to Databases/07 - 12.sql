--CREATE DATABASE Minions

--     Problem 7. Create Table People


CREATE TABLE People
(
	Id	INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture varbinary(MAX),
	Height FLOAT(2),
	[Weight] FLOAT(2),
	Gender char(1) NOT NULL,
	Birthdate date NOT NULL,
	Biography NVARCHAR(MAX)
)
INSERT INTO People ([Name], Picture , Height ,[Weight],Gender,Birthdate,Biography) VALUES 
('IVO', 011010101, 1.64, 65.77, 'f', '1985/01/17', 'AZ SUM IVO'),
('G', 01111101, 1.88, 87.00, 'F', '1980/06/11', 'G'),
('I', 100000001, 1.64, 65.77, 'f', '1985/05/03', 'I'),
('N', 000011010, 1.70, 60.52, 'f', '1975/06/06', 'N'),
('T', 101010101, 1.90, 85.7, 'F', '1995/08/08', NULL)

SELECT * FROM People

--     Problem 8. Create Table Users


CREATE TABLE Users
(
	Id	bigint PRIMARY KEY IDENTITY not null,
	Username VARCHAR(30) not null,
	[Password] VARCHAR(26),
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)
INSERT INTO Users (Username, [Password] , ProfilePicture ,LastLoginTime,IsDeleted) VALUES 
('IVO', 011010101, 'https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg',
GETDATE(), 0),
('G', 011010101, 'https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg',
GETDATE(), 1),
('I', 011010101, 'https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg',
GETDATE(), 0),
('N', 011010101, 'https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg',
GETDATE(), 0),
('T', 011010101, 'https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg',
GETDATE(), 0)

--     Problem 9. Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07C7114F4B

ALTER TABLE Users
ADD CONSTRAINT PK__IdUser 
PRIMARY KEY (Id,Username)


SELECT * FROM Users

--     Problem 10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CH_PasswordFieldAtLeast5Symbols CHECK (LEN([Password])>=5);

--     Problem 11. Set Default Value of a Field

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--    Problem 12. Set Unique Field

ALTER TABLE Users
DROP CONSTRAINT PK__IdUser 

ALTER TABLE Users
ADD CONSTRAINT PK__Id 
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameFieldAtLeast3Symbols CHECK (LEN([Password])>=3);
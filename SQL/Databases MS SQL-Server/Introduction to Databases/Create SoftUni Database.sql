--CREATE DATABASE SoftUni
--      Problem 16. Create SoftUni Database
CREATE TABLE Towns 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AddressText VARCHAR(150) NOT NULL,
	TownId INT NOT NULL,
	CONSTRAINT FK_Addresses_TownId 
		FOREIGN KEY (TownId) 
			REFERENCES Towns(Id)
)

CREATE TABLE Departments 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL, 
	MiddleName NVARCHAR(20) NOT NULL, 
	LastName NVARCHAR(20) NOT NULL, 
	JobTitle NVARCHAR(40) NOT NULL, 
	DepartmentId INT FOREIGN KEY REFERENCES Departments (Id), 
	HireDate DATE NOT NULL,
	Salary DECIMAL(10,2) NOT NULL, 
	AddressId INT FOREIGN KEY REFERENCES Addresses (Id)
) 

--      Problem 17. Backup Database

-- ?????????????????????????????????????????????????????

--      Problem 18. Backup Database

INSERT INTO Towns (Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments (Name) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName,
JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer',4,'02/01/2013',3500.00),
('Petar','Petrov', 'Petrov', 'Senior Engineer',1, '03/02/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern',5, '08/28/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO',2, '12/09/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern',3, '08/28/2016', 599.88)


--      Problem 19.Basic Select All Fields

SELECT * FROM Towns 

SELECT * FROM Departments 

SELECT * FROM Employees 


--      Problem 20.Basic Select All Fields and Order Them


SELECT * FROM Towns 
	ORDER BY [Name] ASC

SELECT * FROM Departments 
	ORDER BY [Name] ASC

SELECT * FROM Employees 
	ORDER BY Salary DESC

--      Problem 21.Basic Select Some Fields

SELECT Name FROM Towns 
	ORDER BY [Name] ASC

SELECT Name FROM Departments 
	ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle,Salary FROM Employees 
	ORDER BY Salary DESC

--      Problem 22.Increase Employees Salary

UPDATE Employees
SET Salary +=Salary*0.1

SELECT Salary FROM Employees
USE SoftUni
GO
CREATE TABLE Deleted_Employees(
	EmployeeID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(MAX),
	LastName NVARCHAR(MAX),
	MiddleName NVARCHAR(MAX),
	JobTitle NVARCHAR(MAX),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentId),
	Salary DECIMAL(15, 2)
)

CREATE TRIGGER tr_DeleteEmployees ON Employees FOR DELETE 
AS
INSERT INTO Deleted_Employees(FirstName,LastName,Middlename,JobTitle,DepartmentId,Salary)
	SELECT  FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted
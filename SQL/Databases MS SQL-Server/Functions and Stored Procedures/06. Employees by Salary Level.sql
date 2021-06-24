CREATE PROC usp_EmployeesBySalaryLevel (@PARAM VARCHAR(10))
AS
SELECT 
	FirstName ,
	LastName 
	FROM Employees
	WHERE [dbo].[ufn_GetSalaryLevel](Salary) LIKE @PARAM

EXEC usp_EmployeesBySalaryLevel LOW


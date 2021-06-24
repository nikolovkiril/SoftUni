CREATE PROC usp_GetEmployeesSalaryAboveNumber (@InputSalary DECIMAL (18,4))
AS
SELECT FirstName , LastName FROM Employees
WHERE Salary >= @InputSalary

EXEC  usp_GetEmployeesSalaryAboveNumber 48100
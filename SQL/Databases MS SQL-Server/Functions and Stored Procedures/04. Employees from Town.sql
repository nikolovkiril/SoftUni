CREATE PROC usp_GetEmployeesFromTown (@TOWN NVARCHAR(40))
AS
SELECT FirstName , LastName FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID 
JOIN Towns AS t ON t.TownID = a.TownID
WHERE t.Name LIKE @TOWN 

EXEC usp_GetEmployeesFromTown SOFIA
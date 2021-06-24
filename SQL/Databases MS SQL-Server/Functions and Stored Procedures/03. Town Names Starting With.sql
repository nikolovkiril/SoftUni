CREATE PROC usp_GetTownsStartingWith (@TownsStartingWith NVARCHAR(50))
AS
SELECT Name AS Town FROM Towns
WHERE Name LIKE @TownsStartingWith + '%'

EXEC usp_GetTownsStartingWith b
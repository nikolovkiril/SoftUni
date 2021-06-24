CREATE PROC usp_SearchForFiles(@extension VARCHAR(MAX))
AS
SELECT f.Id,f.[Name],CONCAT(f.Size, 'KB') AS [Size]
FROM Files AS f
WHERE SUBSTRING(f.[Name], CHARINDEX('.', f.[Name], 1) + 1, LEN(f.[Name])) = @extension
ORDER BY f.Id ASC,f.[Name] ASC,f.Size DESC

GO

GO
EXEC usp_SearchForFiles 'txt'
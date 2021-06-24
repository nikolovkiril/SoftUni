CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
RETURNS INT
AS
BEGIN
DECLARE @commitsCount INT = (SELECT COUNT(c.Id)
FROM Users AS u
JOIN Commits AS c
ON u.Id = c.ContributorId
WHERE u.Username = @username)

RETURN @commitsCount
END

GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein') AS [Output];

GO
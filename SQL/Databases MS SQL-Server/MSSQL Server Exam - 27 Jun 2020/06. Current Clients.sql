SELECT * FROM (
SELECT
	c.FirstName + ' ' + c.LastName AS Client , 
	DATEDIFF(day , j.IssueDate , '2017-04-24') AS [Days going] , 
	j.[Status] 
	FROM Clients AS c
JOIN Jobs AS j ON j.ClientId = c.ClientId
WHERE [Status] NOT LIKE 'Finished'
) AS A
ORDER BY LEN(A.[Days going]) DESC 

SELECT 
	m.FirstName + ' ' + m.LastName AS Mechanic ,
	AVG(DATEDIFF(DAY , j.IssueDate , j.FinishDate)) AS [Average Days]
FROM Jobs AS j
JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName , j.MechanicId
ORDER BY j.MechanicId
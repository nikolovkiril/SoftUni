SELECT * FROM 
	(SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank] 
	FROM Employees) AS Rank2
WHERE Salary BETWEEN 10000 AND 50000 AND [Rank] = 2
ORDER BY Salary DESC
SELECT FirstName , LastName 
	FROM Employees
		WHERE 
	(
	Salary IN 
		(
    SELECT TOP (5) Salary
	 FROM Employees
	    GROUP BY Salary

		)
	)
    ORDER BY Salary DESC

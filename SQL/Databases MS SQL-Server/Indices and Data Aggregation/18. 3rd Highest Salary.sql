SELECT DISTINCT Result.DepartmentID,Result.Salary AS ThirdHighestSalary FROM 
(SELECT DepartmentId,Salary,
	DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY SALARY DESC) AS [Rank] FROM Employees
) as Result
WHERE [Rank] IN (3)



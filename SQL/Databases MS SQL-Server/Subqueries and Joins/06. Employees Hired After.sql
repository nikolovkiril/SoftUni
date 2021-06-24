SELECT FirstName , LastName , HireDate , d.Name AS DeptName FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND  d.Name = 'Finance' OR d.Name = 'Sales'
ORDER BY e.HireDate

SELECT 
	cu.FirstName,
	cu.Age,
	cu.PhoneNumber
FROM Customers AS cu
	JOIN Countries AS co ON co.Id = cu.CountryId
WHERE	
	(cu.FirstName LIKE '%an%'  AND
	cu.Age >= 21 ) OR 
	(RIGHT(cu.PhoneNumber , 2) = '38' AND 
	co.Name NOT LIKE 'Greece')
ORDER BY cu.FirstName , cu.Age DESC
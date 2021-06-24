SELECT a.FirstName , a.LastName ,CONVERT (varchar , a.BirthDate , 110), c.Name AS Hometown , a.Email FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.Name ASC
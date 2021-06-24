SELECT TOP(10) c.Id , c.Name AS City ,c.CountryCode AS Country , COUNT(*) AS Accounts FROM Cities AS c
JOIN Accounts AS ac ON ac.CityId = c.ID
WHERE ac.Id > 0
GROUP BY c.Id , c.Name , c.CountryCode
ORDER BY Accounts DESC

SELECT * FROM Accounts
WHERE (CityId = 76)

SELECT  TOP(5)  e.Country, e.[Highest Peak Name], e.[Highest Peak Elevation], e.Mountain 
FROM ( SELECT CountryName AS Country , 
	ISNULL (p.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL (MAX(p.Elevation), 0) AS [Highest Peak Elevation],
	ISNULL (m.MountainRange, '(no mountain)') AS Mountain ,
	DENSE_RANK () OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
	FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = mc.MountainId
GROUP BY CountryName , p.PeakName , m.MountainRange) AS e
WHERE Ranked = 1
ORDER BY e.Country,e.[Highest Peak Name]

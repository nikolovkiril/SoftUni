SELECT mc.CountryCode ,COUNT(mc.MountainId) AS MountainRanges FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode 
AND c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY mc.CountryCode 

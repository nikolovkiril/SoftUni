SELECT TOP(5) CountryName , MAX(p.Elevation) AS HighestPeakElevation , MAX(r.Length)AS LongestRiverLength
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Peaks AS p ON p.MountainId = mC.MountainId
JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC , LongestRiverLength DESC

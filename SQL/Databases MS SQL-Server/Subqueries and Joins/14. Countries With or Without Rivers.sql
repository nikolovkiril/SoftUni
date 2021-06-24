SELECT TOP(5)  c.CountryName, r.RiverName  FROM Rivers AS r
JOIN CountriesRivers AS cr ON r.Id = cr.RiverId
RIGHT JOIN Countries AS c ON c.CountryCode = cr.CountryCode
JOIN Continents AS con ON c.ContinentCode = con.ContinentCode
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName
SELECT pl.Name AS PlanetName ,  COUNT(j.DestinationSpaceportId) AS JourneysCount
FROM Journeys AS j
join Spaceports AS sp ON j.DestinationSpaceportId = sp.id
JOIN Planets AS pl ON pl.Id = sp.PlanetId
GROUP BY pl.Name 
ORDER BY JourneysCount DESC , pl.Name ASC

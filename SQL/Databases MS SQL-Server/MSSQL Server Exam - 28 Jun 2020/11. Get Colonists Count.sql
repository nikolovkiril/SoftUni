GO
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
	BEGIN
		RETURN (
		SELECT COUNT(*) FROM Planets AS p 
		JOIN Spaceports AS s ON s.PlanetId = p.Id
		JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
		JOIN TravelCards AS tc ON tc.JourneyId = j.Id
		JOIN Colonists AS c ON c.Id = tc.ColonistId
		WHERE p.Name = @PlanetName)
	END
GO

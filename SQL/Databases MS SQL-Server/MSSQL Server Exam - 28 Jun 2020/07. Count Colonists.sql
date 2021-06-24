SELECT count(*) AS count
FROM Colonists AS c
JOIN TravelCards AS tc ON tc.ColonistId = c.id
JOIN Journeys AS j ON j.id = tc. JourneyId
WHERE j.purpose = 'Technical';



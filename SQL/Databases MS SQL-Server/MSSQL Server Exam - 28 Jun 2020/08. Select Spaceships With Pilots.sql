

select * from spaceships
select * from journeys
select * from TravelCards

select * from colonists as c
WHERE 2019 - YEAR(c.BirthDate) < 30
order by BirthDate asc


SELECT sh.Name , sh.Manufacturer
FROM spaceships AS sh
JOIN journeys AS j ON j.SpaceshipId = sh.id
JOIN TravelCards AS tc ON tc.JourneyId = j.id
JOIN colonists AS c ON c.id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
AND 2019 - YEAR(c.BirthDate) < 30
ORDER BY sh.name;
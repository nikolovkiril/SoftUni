SELECT * FROM (
		SELECT tc.JobDuringJourney,
		(c.FirstName + ' ' + c.LastName) AS [FullName],
		DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.Birthdate ) AS [JobRank]
		FROM Colonists AS c
		JOIN TravelCards AS tc ON tc.ColonistId = c.Id
			   ) AS t
WHERE t.[JobRank] = 2


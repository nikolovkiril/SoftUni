delete from TravelCards
where JourneyId in (
					select JourneyId from TravelCards
					where JourneyId between 1 and 3
					)

delete from Journeys
where Id between 1 and 3

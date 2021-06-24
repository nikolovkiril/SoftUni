select c.Id ,c.FirstName + ' ' + c.LastName AS full_name from colonists AS c
join TravelCards AS t on c.Id = t.ColonistId
where JobDuringJourney = 'pilot'
order by id asc

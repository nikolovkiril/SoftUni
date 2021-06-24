SELECT atr.AccountId ,
	   ac.FirstName + ' ' + ac.LastName AS FullName ,
	   MAX(DATEDIFF(DAY ,tr.ArrivalDate, tr.ReturnDate)) AS LongestTrip ,
	   MIN(DATEDIFF(DAY ,tr.ArrivalDate, tr.ReturnDate)) AS ShortestTrip 
	FROM AccountsTrips AS atr
	JOIN Trips AS tr ON tr.Id = atr.TripId
	JOIN Accounts AS ac ON atr.AccountId = ac.Id
			WHERE ac.MiddleName IS NULL AND tr.CancelDate IS NULL
			GROUP BY atr.AccountId, ac.FirstName,ac.LastName
				ORDER BY LongestTrip DESC, ShortestTrip


 
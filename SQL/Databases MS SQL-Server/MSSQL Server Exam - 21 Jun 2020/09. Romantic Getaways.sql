SELECT a.Id , a.Email ,c.Name AS City , COUNT(*) AS Trips FROM Accounts AS a
	JOIN AccountsTrips AS act ON act.AccountId = a.Id
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN Trips AS t ON act.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h on r.HotelId = h.Id
		WHERE a.CityId = h.CityId
		GROUP BY a.Id,a.Email,c.Name
		ORDER BY Trips DESC, a.Id


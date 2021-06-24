SELECT 
		u.Username, 
	    g.Name AS [Game],
		MAX(c.Name) AS [Character],  
		SUM(s.Strength) + MAX(s1.Strength) + MAX(s2.Strength) AS [Strength], 
		SUM(s.Defence) + MAX(s1.Defence) + MAX(s2.Defence) AS [Defence], 
		SUM(s.Speed) + MAX(s1.Speed) + MAX(s2.Speed) AS [Speed], 
		SUM(s.Mind) + MAX(s1.Mind) + MAX(s2.Mind) AS [Mind], 
		SUM(s.Luck) + MAX(s1.Luck) + MAX(s2.Luck) AS [Luck]
FROM Users AS u
	JOIN UsersGames AS ug 
			ON u.Id = ug.UserId
	JOIN UserGameItems AS ugi 
			ON ug.Id = ugi.UserGameId
	JOIN Items AS i 
			ON ugi.ItemId = i.Id
	JOIN [Statistics] AS s 
			ON i.StatisticId = s.Id
	JOIN Games AS g 
			ON ug.GameId = g.Id
	JOIN GameTypes AS gt 
			ON g.GameTypeId = gt.Id
	JOIN [Statistics] AS s1 
			ON gt.BonusStatsId = s1.Id
	JOIN Characters AS c 
			ON ug.CharacterId = c.Id
	JOIN [Statistics] AS s2 
			ON c.StatisticId = s2.Id
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

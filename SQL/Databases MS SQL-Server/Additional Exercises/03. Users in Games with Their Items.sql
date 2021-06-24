SELECT 
		u.Username ,
		g.[Name] AS Game,
		COUNT(*) AS [Items Count],
		SUM(i.Price) AS  [Items Price] 
	FROM Games AS g
	 JOIN UsersGames AS ug ON ug.GameId = g.Id
	 JOIN Users AS u ON u.Id = ug.UserId
	 JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
	 JOIN Items AS i ON	 i.Id = ugi.ItemId
GROUP BY u.Username , g.[Name]
HAVING COUNT(*) >= 10
ORDER BY [Items Count] DESC,[Items Price] DESC,Username

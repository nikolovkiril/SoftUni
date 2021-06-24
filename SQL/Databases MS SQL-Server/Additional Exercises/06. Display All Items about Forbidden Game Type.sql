SELECT 
	i.Name AS Item,
	i.Price,
	i.MinLevel,
	gt.Name
		FROM Items AS i
LEFT  JOIN GameTypeForbiddenItems AS f ON f.ItemId = i.Id
LEFT  JOIN GameTypes AS gt ON gt.Id = f.GameTypeId
ORDER BY gt.Name DESC , i.Name 
SELECT p.PeakName, r.RiverName,
LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName) - 1)) AS Mix 
	FROM Peaks as p
	JOIN Rivers as r
	ON RIGHT (PeakName,1) = LEFT(RiverName, 1)
	ORDER BY Mix
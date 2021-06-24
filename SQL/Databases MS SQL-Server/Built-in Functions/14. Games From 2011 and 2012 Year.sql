SELECT TOP(50) [NAME] , FORMAT([Start], 'yyyy-MM-dd' ) AS [Start]  FROM Games
WHERE DATEPART(YEAR, Start) IN (2011, 2012)
ORDER BY [Start] , [NAME]


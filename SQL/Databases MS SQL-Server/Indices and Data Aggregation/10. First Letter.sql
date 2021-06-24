SELECT LEFT(FirstName,1) AS FirstLetter  FROM WizzardDeposits
WHERE DepositGroup LIKE '%Troll%'
GROUP BY LEFT(FirstName,1)

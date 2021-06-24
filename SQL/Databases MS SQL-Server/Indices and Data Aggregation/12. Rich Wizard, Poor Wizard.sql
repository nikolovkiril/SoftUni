SELECT SUM([final].[Difference]) AS [SumDifference] FROM 
(
	SELECT *  , [FullTable].[Host Wizard Deposit] - [FullTable].[Guest Wizard Deposit] AS [Difference] 
	FROM 
	(
		SELECT FirstName AS [Host Wizard],
		DepositAmount AS [Host Wizard Deposit],
		LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard],
		LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit]
		FROM WizzardDeposits
	) AS [FullTable]
) AS [final]

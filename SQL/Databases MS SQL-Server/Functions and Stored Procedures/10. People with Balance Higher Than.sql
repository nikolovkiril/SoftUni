CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(15,4) )
AS
	WITH cte_AccountHoldersBalance (AccountHolderID, Balance) AS(
		SELECT AccountHolderId, SUM(Balance) AS TotalBalance
		FROM Accounts
		GROUP BY AccountHolderId)
	SELECT FirstName, LastName
		FROM AccountHolders AS ah
		JOIN cte_AccountHoldersBalance AS cab ON cab.AccountHolderID = ah.Id
		WHERE cab.Balance > @number
		ORDER BY ah.FirstName, ah.LastName


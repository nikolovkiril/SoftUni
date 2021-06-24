CREATE PROCEDURE usp_AddItemsToUserAndDisplayUsersItemsInTheGame
AS
	BEGIN TRANSACTION
		DECLARE @UserName VARCHAR(50) = 'Alex';
		DECLARE @GameName VARCHAR(50) = 'Edinburgh';

		DECLARE @UserID INT = (SELECT Id FROM Users WHERE Username = @UserName);
			IF(@UserID IS NULL)
				BEGIN
					ROLLBACK;
					THROW 50001, 'Invalid UserId', 1;
				END

		DECLARE @GameID INT = (SELECT Id FROM Games WHERE [Name] = @GameName );
			IF(@GameID IS NULL)
				BEGIN
					ROLLBACK;
					THROW 50002, 'Invalid UserId', 1;
				END

		DECLARE @UserGameID INT = (SELECT Id FROM UsersGames WHERE GameId = @GameID AND UserId = @UserID)		
			IF(@UserGameID IS NULL)
				BEGIN
					ROLLBACK;
					THROW 50003, 'Invalid GameId', 1;
				END

		DECLARE @Counter INT = 1;
		DECLARE @ItemsCount INT = (SELECT COUNT(*) FROM Items WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 
												'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 
												'Golden Gorget of Leoric')); 
		SELECT * FROM ITEMS WHere Name Like 'Hellfire Amulet'

		WHILE(@Counter <= @ItemsCount)
			BEGIN
			DECLARE @UserCach MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameID)

			DECLARE @UserLevel INT = (SELECT [Level] FROM UsersGames WHERE ID = @UserGameId)

			DECLARE @ItemID	INT = (SELECT ID FROM (SELECT ID, ROW_NUMBER() OVER(ORDER BY ID) AS [Rows]
												FROM Items WHERE Name IN 
												('Blackguard', 'Bottomless Potion of Amplification', 
												'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 
												'Golden Gorget of Leoric', 'Hellfire Amulet')) AS R
												WHERE Rows = @Counter);
			DECLARE @ItemPrice MONEY = (SELECT Price FROM Items WHERE ID = @ItemID)
			DECLARE @ItemMinLevel INT = (SELECT MinLevel FROM Items WHERE ID = @ItemID)
				IF(@ItemPrice <= @UserCach AND @UserLevel >=@ItemMinLevel)
					BEGIN
						UPDATE UsersGames
						SET Cash -= @ItemPrice
						WHERE Id = @UserGameId;
						INSERT INTO UserGameItems
						VALUES (@ItemID, @UserGameId);
						--SET @Counter += 1;
					END
				/*ELSE
					BEGIN
						ROLLBACK;
						THROW 50004, 'Not Enough Funds!', 1;
					END*/
				SET @Counter += 1;
			END
	COMMIT

SELECT u.Username, g.Name, ug.Cash, i.Name AS [Item Name]
FROM Games AS g
JOIN UsersGames AS ug ON g.Id = ug.GameId
JOIN Users AS u ON ug.UserId = u.Id
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Items AS i ON ugi.ItemId = i.Id
WHERE g.Name = @GameName	
ORDER BY [Item Name]

GO

EXEC usp_AddItemsToUserAndDisplayUsersItemsInTheGame

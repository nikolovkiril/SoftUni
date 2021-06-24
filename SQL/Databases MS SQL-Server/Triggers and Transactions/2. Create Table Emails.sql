USE Bank
GO
CREATE TABLE NotificationEmails(
	Recipient INT PRIMARY KEY IDENTITY,
	Subject NVARCHAR(MAX),
	Body NVARCHAR(MAX)
)

CREATE TRIGGER tr_EmailsNotificationsAfterInsert
ON Logs AFTER INSERT 
AS
BEGIN
INSERT INTO NotificationEmails(Recipient,[Subject],Body)
SELECT i.AccountID, 
CONCAT('Balance change for account: ',i.AccountId),
CONCAT('On ',GETDATE(),' your balance was changed from ',i.NewSum,' to ',i.OldSum)
  FROM inserted AS i
END
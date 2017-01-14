USE [T-SQL-Task1-SimpleAccountSystem]

/***
Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
***/
GO

CREATE PROCEDURE usp_WithdrawMoney 
 @AccountId int, 
 @money money

AS
	UPDATE Accounts
		SET Balance = Balance - @money
		WHERE @AccountID = Id
GO

CREATE PROCEDURE usp_DepositMoney
 @AccountId int, 
 @money money

AS
	UPDATE Accounts
		SET Balance = Balance + @money
		WHERE @AccountID = Id
GO

EXEC dbo.usp_WithdrawMoney 5, 5555.99
EXEC dbo.usp_DepositMoney 6, 17000.01


EXEC dbo.usp_SelectFullNameOfPersons
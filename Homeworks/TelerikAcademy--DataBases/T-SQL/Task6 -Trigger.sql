USE [T-SQL-Task1-SimpleAccountSystem]


/***
Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
Add a trigger to the Accounts table that enters a new entry into the Logs table 
every time the sum on an account changes.
***/
GO

CREATE TABLE Logs
(
        LogId INT IDENTITY,
                CONSTRAINT PK_Logs PRIMARY KEY(LogId),
        OldSum MONEY,
        NewSum MONEY,
        AccId INT,
                CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccId)
                        REFERENCES Accounts(Id)
)
 
GO
 
CREATE TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
AS
        DECLARE deletedCursor CURSOR READ_ONLY FOR
                SELECT Balance, Id FROM deleted
        DECLARE insertedCursor CURSOR READ_ONLY FOR
                SELECT Balance FROM inserted
 
        OPEN deletedCursor
        OPEN insertedCursor
 
        DECLARE @oldSum MONEY, @accountId INT
        FETCH NEXT FROM deletedCursor INTO @oldSum, @accountId
 
        DECLARE @newSum MONEY
        FETCH NEXT FROM insertedCursor INTO @newSum
 
        WHILE @@FETCH_STATUS = 0
        BEGIN
                INSERT INTO Logs (OldSum, NewSum, AccId)
                VALUES (@oldSum, @newSum, @accountId)
                FETCH NEXT FROM deletedCursor INTO @oldSum, @accountId
                FETCH NEXT FROM insertedCursor INTO @newSum
        END
 
        CLOSE deletedCursor
        DEALLOCATE deletedCursor
        CLOSE insertedCursor
        DEALLOCATE insertedCursor
GO
 
EXEC dbo.usp_WithdrawMoney 1, 55.99
EXEC dbo.usp_WithdrawMoney 2, 55.99
EXEC dbo.usp_WithdrawMoney 3, 55.99
EXEC dbo.usp_WithdrawMoney 4, 55.99
EXEC dbo.usp_WithdrawMoney 5, 55.99
EXEC dbo.usp_WithdrawMoney 6, 55.99
EXEC dbo.usp_WithdrawMoney 3, 55.99

EXEC dbo.usp_DepositMoney 1, 6555.99
EXEC dbo.usp_DepositMoney 2, 6555.99
EXEC dbo.usp_DepositMoney 3, 6555.99
EXEC dbo.usp_DepositMoney 4, 6555.99
EXEC dbo.usp_DepositMoney 5, 6555.99
EXEC dbo.usp_DepositMoney 6, 6555.99
EXEC dbo.usp_DepositMoney 3, 6555.99

EXEC dbo.usp_DepositMoney 6, 170.01
EXEC dbo.usp_DepositMoney 7, 170.01
EXEC dbo.usp_DepositMoney 8, 170.01
EXEC dbo.usp_DepositMoney 9, 170.01
EXEC dbo.usp_DepositMoney 10, 170.01
EXEC dbo.usp_DepositMoney 6, 17.01
EXEC dbo.usp_DepositMoney 9, 100.01

SELECT * FROM Logs

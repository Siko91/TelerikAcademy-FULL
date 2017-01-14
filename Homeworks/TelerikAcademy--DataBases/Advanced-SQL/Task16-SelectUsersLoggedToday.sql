USE [TelerikAcademy]

/*** 
Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
Test if the view works correctly.
***/

INSERT INTO Users (Username, [UserPassword], LastLogin)
VALUES ('Alex', 'AlexPassword123456', GETDATE());
GO
INSERT INTO Users (Username, [UserPassword], LastLogin)
VALUES ('Alex2', 'AlexPassword123456', GETDATE());
GO
INSERT INTO Users (Username, [UserPassword], LastLogin)
VALUES ('Alex3', 'AlexPassword123456', GETDATE());
GO
INSERT INTO Users (Username, [UserPassword], LastLogin)
VALUES ('IWillNotBeShown', 'AlexPassword123456', TRY_PARSE('01/01/1995 00:00:00 PM' AS DATETIME USING 'en-us'));
GO

SELECT *
	FROM Users
	WHERE LastLogin >= TRY_PARSE(CONVERT(VARCHAR(10), GETDATE(), 101) + ' 00:00:00 PM' AS DATETIME USING 'en-us');

/*RESTORE*/

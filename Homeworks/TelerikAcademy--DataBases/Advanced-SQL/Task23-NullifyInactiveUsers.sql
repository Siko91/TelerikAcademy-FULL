USE [TelerikAcademy]

/*** 
Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
***/


UPDATE Users
	SET UserPassword = NULL
	WHERE LastLogin < TRY_PARSE('10/03/2010 00:00:00 PM' AS DATETIME USING 'en-us');
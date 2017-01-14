USE [TelerikAcademy]

/*** 
Write SQL statements to delete some of the records from the Users and Groups tables.
***/

UPDATE Groups
	SET Name += 'UPDATED_GROUP_' + CONVERT ( nvarchar , GroupID )
	WHERE Name LIKE '%Group';

UPDATE Users
	SET UserPassword += 'UPDATED_Password'
	WHERE Username LIKE '%New%';



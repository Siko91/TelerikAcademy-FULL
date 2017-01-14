USE [TelerikAcademy]

/*** 
Write SQL statements to delete some of the records from the Users and Groups tables.
***/

DELETE FROM Groups
	WHERE Name LIKE '%UPDATED%';

DELETE FROM Users
	WHERE Username LIKE '%New%';



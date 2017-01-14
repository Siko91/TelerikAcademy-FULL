USE [TelerikAcademy]

/*** 
Write a SQL statement that deletes all users without names (NULL names).
***/

/** Passwords can not be null... used fullname instead **/

UPDATE Users
	SET FullName = NULL
	WHERE Username LIKE 'a%'

DELETE Users
	WHERE FullName IS NULL
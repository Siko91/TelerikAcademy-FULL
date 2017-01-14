USE [T-SQL-Task1-SimpleAccountSystem]
GO

/**
Create a stored procedure that accepts a number as a parameter 
and returns all persons who have more money in their accounts than the supplied number.
**/

CREATE PROCEDURE usp_GetPeopleWithAccountsThatHaveMinAmmountOf 
@minAmmount money = 0

AS
  SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance
  FROM Persons p
	INNER JOIN Accounts a ON a.PersonID = p.Id
	WHERE a.Balance > @minAmmount
	ORDER BY a.Balance DESC
GO

EXEC dbo.usp_GetPeopleWithAccountsThatHaveMinAmmountOf 0

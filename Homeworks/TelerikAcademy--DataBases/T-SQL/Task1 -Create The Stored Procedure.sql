USE [T-SQL-Task1-SimpleAccountSystem]
GO

/** Create a database with two tables: 
Persons(Id(PK), FirstName, LastName, SSN) and 
Accounts(Id(PK), PersonId(FK), Balance).

 Insert few records for testing.
 
 Write a stored procedure that selects the full names of all persons.
 **/

CREATE PROC dbo.usp_SelectFullNameOfPersons

AS
  SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance
  FROM Persons p
	INNER JOIN Accounts a ON a.PersonID = p.Id
	ORDER BY a.Balance DESC
GO

EXEC dbo.usp_SelectFullNameOfPersons
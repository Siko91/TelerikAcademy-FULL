USE [T-SQL-Task1-SimpleAccountSystem]
GO

/**
Create a stored procedure that uses the function from the previous example 
to give an interest to a person's account for one month. 
It should take the AccountId and the interest rate as parameters.
**/

CREATE PROCEDURE usp_Give1MonthOfInterestToAnAccount
@PersonId int,
@InterestRate float = 0

AS
  UPDATE Accounts
	SET Balance = dbo.ufn_CalcInterestIncrease(Balance, @InterestRate, 1)
	WHERE PersonID = @PersonId
GO

EXEC dbo.usp_Give1MonthOfInterestToAnAccount 5, 0.2
DROP PROCEDURE usp_Give1MonthOfInterestToAnAccount

EXEC dbo.usp_GetPeopleWithAccountsThatHaveMinAmmountOf 0
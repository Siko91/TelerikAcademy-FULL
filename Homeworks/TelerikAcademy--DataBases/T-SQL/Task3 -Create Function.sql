USE [T-SQL-Task1-SimpleAccountSystem]
GO

/**
Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
**/

CREATE FUNCTION ufn_CalcInterestIncrease(@sum money, @yearlyInterest float, @numberOfMonths int)
  RETURNS money
AS
BEGIN
  RETURN (@sum) * (1 + @yearlyInterest) * (@numberOfMonths / 12)
END

GO

SELECT p.FirstName + ' ' + p.LastName AS FullName, a.Balance, dbo.ufn_CalcInterestIncrease(a.Balance, 0.1, 12) AS BalanceInAnYear
	FROM Persons p
		INNER JOIN Accounts a ON a.PersonID = p.Id
	ORDER BY a.Balance DESC

GO
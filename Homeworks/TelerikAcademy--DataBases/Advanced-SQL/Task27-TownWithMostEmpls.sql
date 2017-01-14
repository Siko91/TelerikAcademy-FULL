USE [TelerikAcademy]

/*** 
Write a SQL query to display the town where maximal number of employees work.
***/

SELECT t.Name, COUNT(*)
	FROM Towns t
		INNER JOIN Addresses a ON t.TownID = a.TownID
		INNER JOIN Employees e ON e.AddressID = a.AddressID 
	WHERE e.ManagerID IS NULL
	GROUP BY t.Name
USE [TelerikAcademy]

/*** 
Write a SQL query to find the number of all employees that have manager.
***/

SELECT COUNT(*) AS [Employee Count]
FROM Employees e
WHERE e.ManagerID IS NOT NULL

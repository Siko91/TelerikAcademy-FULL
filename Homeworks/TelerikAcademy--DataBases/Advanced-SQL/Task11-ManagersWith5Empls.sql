USE [TelerikAcademy]

/*** 
Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
***/

SELECT m.FirstName, m.LastName, m.JobTitle, COUNT(e.ManagerID) AS EmployeeCount
FROM Employees e
	INNER JOIN Employees m
		ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName, m.JobTitle
HAVING COUNT(e.ManagerID) = 5
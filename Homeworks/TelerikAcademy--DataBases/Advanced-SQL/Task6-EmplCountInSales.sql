USE [TelerikAcademy]

/*** 
Write a SQL query to find the number of employees in the "Sales" department.
***/

SELECT e.DepartmentID, d.Name, COUNT(*) AS [Employee Count]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name, e.DepartmentID

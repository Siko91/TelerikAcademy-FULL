USE [TelerikAcademy]

/*** 
Write a SQL query to find the average salary in the department #1.
***/

SELECT e.DepartmentID, d.Name, AVG(e.Salary)
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 1
GROUP BY d.Name, e.DepartmentID

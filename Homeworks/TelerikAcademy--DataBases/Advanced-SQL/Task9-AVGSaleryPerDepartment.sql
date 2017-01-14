USE [TelerikAcademy]

/*** 
Write a SQL query to find all departments and the average salary for each of them.
***/

SELECT e.DepartmentID, d.Name, AVG(e.Salary) AS [Average Salery]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name

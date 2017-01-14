USE [TelerikAcademy]

/*** 
Write a SQL query to display the average employee salary by department and job title.
***/

SELECT e.DepartmentID AS id, d.Name, AVG(e.Salary) AS [Average Salery]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name
UNION
SELECT 0 AS id, e.JobTitle AS Name, AVG(e.Salary) AS [Average Salery]
FROM Employees e
GROUP BY e.JobTitle
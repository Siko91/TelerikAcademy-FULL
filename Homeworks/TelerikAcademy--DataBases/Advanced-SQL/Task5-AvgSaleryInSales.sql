USE [TelerikAcademy]

/*** 
Write a SQL query to find the average salary  in the "Sales" department.
***/

SELECT e.DepartmentID, d.Name, AVG(e.Salary)
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name, e.DepartmentID

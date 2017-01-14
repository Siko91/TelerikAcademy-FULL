USE [TelerikAcademy]

/*** 
Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
***/

SELECT e.DepartmentID AS id, d.Name, e.FirstName, e.LastName, e.Salary
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary = (SELECT MIN(Salary) FROM Employees 
					WHERE DepartmentID = e.DepartmentID)
UNION
SELECT NULL AS id, e.JobTitle AS Name, e.FirstName, e.LastName, e.Salary
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary = (SELECT MIN(Salary) FROM Employees 
					WHERE JobTitle = e.JobTitle)
					W
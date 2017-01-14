USE [TelerikAcademy]

/*** 
Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
***/

SELECT e.FirstName, e.LastName, COALESCE(m.FirstName + ' ' + m.LastName, '(no manager)')
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID
WHERE LEN(e.LastName) = 5
USE [TelerikAcademy]

/*** 
Write a SQL query to find the count of all employees in each department and for each town.
***/

SELECT e.DepartmentID AS [ID], d.Name + ' Department' AS [Where], COUNT(*) AS [Employee Count]
FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name
UNION
SELECT a.TownID AS [ID], t.Name + ' City' AS [Where], COUNT(*) AS [Employee Count]
FROM Employees e
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
			INNER JOIN Towns t
				ON a.TownID = t.TownID
GROUP BY a.TownID, t.Name
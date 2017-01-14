CREATE PROCEDURE usp_GetProjectWorkers
AS 
	SELECT * FROM ProjectWorkers;
GO


---------------------------------------------


CREATE VIEW ProjectWorkers AS
SELECT 
	e.FirstName + ' ' + e.LastName AS FullName,
	p.Name AS Project, 
	d.Name AS Department,
	ep.StartDate,
	ep.EndDate,
	(SELECT COUNT(*) FROM Reports r
		WHERE ep.StartDate <= r.TimeOfReport
		AND ep.EndDate >= r.TimeOfReport) AS ReportsCount

	FROM EmployeesWorkOnProjects ep
	INNER JOIN Projects p ON p.Id = ep.ProjectId
	INNER JOIN Employees e ON e.Id = ep.EmployeeId
	INNER JOIN Departaments d ON e.DepartmentId = d.Id

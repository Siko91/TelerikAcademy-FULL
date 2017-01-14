/*
3.	Get each employee’sfull name (first name + “ “ + last name), 
project’sname, department’sname, starting and ending date for each employee in project.
 Additionally get the number of all reports, which time of reporting is between the start and end date.
  Sort the results first by the employee id, then by the project id. (This query is slow, be patient!)
*/

/*
I Couldn't fill Employee-Project connections with the programs but this query works.
Please test it on your own database.
Thank you.
*/

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


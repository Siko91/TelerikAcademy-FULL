/****** What is SQL? What is DML? What is DDL? Recite the most important SQL commands. ******/
/****** SQL (Structured Query Language) - language handling the CRUD operations. That's it. ******/
/****** SQL is a DML. DML is any language that does the same, or simular things. ******/
/****** SQL is also a DDL. The DDL part is used in the creation of the database, while DML is usefull in filling and viewing it later. ******/


/****** What is Transact-SQL (T-SQL)? ******/
/****** T-SQL is SQL addon language, used for defining transactions. Transactions are used to ensure that a group of operations will eighter be compleated as one, or fail as one. Nothing in between. ******/

/****** Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database. ******/
/****** done ******/

/****** Write a SQL query to find all information about all departments (use "TelerikAcademy" database). ******/
SELECT * FROM [TelerikAcademy].[dbo].Departments;

/****** Write a SQL query to find all department names. ******/
SELECT Name AS DepartmentName FROM [TelerikAcademy].[dbo].Departments;

/****** Write a SQL query to find the salary of each employee. ******/
SELECT FirstName + ' ' + LastName AS Name, Salary FROM [TelerikAcademy].[dbo].Employees;

/****** Write a SQL to find the full name of each employee. ******/
SELECT FirstName + ' ' + LastName AS FullName FROM [TelerikAcademy].[dbo].Employees;

/****** Write a SQL query to find the email addresses of each employee (by his first and last name). Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses". ******/
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses] FROM [TelerikAcademy].[dbo].Employees;

/****** Write a SQL query to find all different employee salaries. ******/
SELECT DISTINCT Salary FROM [TelerikAcademy].[dbo].Employees;

/****** Write a SQL query to find all information about the employees whose job title is “Sales Representative“. ******/
SELECT * FROM [TelerikAcademy].[dbo].Employees
	WHERE JobTitle = 'Sales Representative';

/****** Write a SQL query to find the names of all employees whose first name starts with "SA". ******/
SELECT FirstName + ' ' + LastName AS FullName FROM [TelerikAcademy].[dbo].Employees
	WHERE FirstName LIKE 'SA%';

/****** Write a SQL query to find the names of all employees whose last name contains "ei". ******/
SELECT FirstName + ' ' + LastName AS FullName FROM [TelerikAcademy].[dbo].Employees
	WHERE LastName LIKE '%ei%';

/****** Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. ******/
SELECT FirstName + ' ' + LastName AS FullName, Salary FROM [TelerikAcademy].[dbo].Employees
	WHERE Salary BETWEEN 20000 AND 30000
	ORDER BY Salary;

/****** Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. ******/
SELECT FirstName + ' ' + LastName AS FullName, Salary FROM [TelerikAcademy].[dbo].Employees
	WHERE Salary IN (25000, 14000, 12500, 23600)
	ORDER BY Salary;

/****** Write a SQL query to find all employees that do not have manager. ******/
SELECT FirstName + ' ' + LastName AS FullName, Salary FROM [TelerikAcademy].[dbo].Employees
	WHERE ManagerID IS NULL
	ORDER BY Salary;

/****** Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. ******/
SELECT FirstName + ' ' + LastName AS FullName, Salary FROM [TelerikAcademy].[dbo].Employees
	WHERE Salary >= 50000
	ORDER BY Salary DESC;

/****** Write a SQL query to find the top 5 best paid employees. ******/
SELECT TOP 5 FirstName + ' ' + LastName AS FullName, Salary FROM [TelerikAcademy].[dbo].Employees
	ORDER BY Salary DESC;

/****** Write a SQL query to find all employees along with their address. Use inner join with ON clause. ******/
SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText, t.Name FROM [TelerikAcademy].[dbo].Employees e
	INNER JOIN [TelerikAcademy].[dbo].Addresses a
		ON e.AddressID = a.AddressID
	INNER JOIN [TelerikAcademy].[dbo].Towns t
		ON a.TownID = t.TownID
	ORDER BY t.Name

/****** Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). ******/
SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText, t.Name
	FROM [TelerikAcademy].[dbo].Employees e, [TelerikAcademy].[dbo].Addresses a, [TelerikAcademy].[dbo].Towns t
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

/****** Write a SQL query to find all employees along with their manager. ******/
SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS ManagerName
	FROM [TelerikAcademy].[dbo].Employees e, [TelerikAcademy].[dbo].Employees m
	WHERE e.ManagerID = m.EmployeeID
	ORDER BY e.ManagerID;

/****** Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a. ******/
SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS ManagerName, a.AddressText AS Address
	FROM [TelerikAcademy].[dbo].Employees e, [TelerikAcademy].[dbo].Employees m, [TelerikAcademy].[dbo].Addresses a
	WHERE e.ManagerID = m.EmployeeID AND e.AddressID = a.AddressID
	ORDER BY e.ManagerID;

/****** Write a SQL query to find all departments and all town names as a single list. Use UNION. ******/
SELECT Name AS TownOrDepartment FROM [TelerikAcademy].[dbo].Towns
UNION
SELECT Name AS TownOrDepartment FROM [TelerikAcademy].[dbo].Departments

/****** Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. Use right outer join. Rewrite the query to use left outer join. ******/

/****** left... ******/
SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS ManagerName
	FROM [TelerikAcademy].[dbo].Employees e
	LEFT OUTER JOIN [TelerikAcademy].[dbo].Employees m
		ON e.ManagerID = m.EmployeeID
	ORDER BY e.ManagerID;
/****** right... ******/
SELECT e.FirstName + ' ' + e.LastName AS FullName, m.FirstName + ' ' + m.LastName AS ManagerName
	FROM [TelerikAcademy].[dbo].Employees m
	RIGHT OUTER JOIN [TelerikAcademy].[dbo].Employees e
		ON e.ManagerID = m.EmployeeID
	ORDER BY e.ManagerID;

/****** Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005. ******/
SELECT e.FirstName + ' ' + e.LastName AS FullName, d.Name, e.HireDate
	FROM [TelerikAcademy].[dbo].Employees e, [TelerikAcademy].[dbo].Departments d
	WHERE e.DepartmentID = d.DepartmentID AND 
		d.Name = 'Sales' AND 
		e.HireDate >= TRY_PARSE('01/01/1995 00:00:00 PM' AS DATETIME USING 'en-us') AND
		e.HireDate <= TRY_PARSE('12/31/2005 00:00:00 PM' AS DATETIME USING 'en-us')
	ORDER BY e.ManagerID;

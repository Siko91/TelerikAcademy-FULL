USE [TelerikAcademy]

/*** 
Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
***/

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary <= 
  (SELECT MIN(Salary) FROM Employees) * 1.1
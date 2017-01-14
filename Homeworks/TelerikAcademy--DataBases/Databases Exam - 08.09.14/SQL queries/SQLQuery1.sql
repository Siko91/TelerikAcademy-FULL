/*
1.	Get the full name (first name + “ “ + last name)  of every employee
 and its salary, for each employee with salary between $100 000 and $150 000, inclusive.
  Sort the results by salary in ascending order.
  */

SELECT FirstName + ' ' + LastName AS FullName, YearSalary
FROM Employees
WHERE YearSalary >= 100000 AND YearSalary <= 150000;
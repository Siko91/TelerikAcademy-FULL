USE [TelerikAcademy]

/*** 
Start a database transaction, 
delete all employees from the 'Sales' department
along with all dependent records from the pother tables.
At the end rollback the transaction.
***/

BEGIN TRAN

ALTER TABLE Departments
   DROP CONSTRAINT FK_Departments_Employees   -- or whatever it's called

ALTER TABLE Departments
   ADD CONSTRAINT FK_Departments_Employees_Cascade
   FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE

DELETE FROM Employees
	WHERE DepartmentID = (SELECT DepartmentID FROM Departments
							WHERE Name = 'Sales')
ROLLBACK TRAN
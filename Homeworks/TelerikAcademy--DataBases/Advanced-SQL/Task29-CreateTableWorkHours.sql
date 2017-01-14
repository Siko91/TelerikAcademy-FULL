USE [TelerikAcademy]

/*** 
Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
Don't forget to define  identity, primary key and appropriate foreign key. 

Issue few SQL statements to insert, update and delete of some data in the table.

Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
For each change keep the old record data, the new record data and the command (insert / update / delete).
***/

CREATE TABLE WorkHours
(
WorkID int IDENTITY(1,1) NOT NULL,
EmployeeID int NOT NULL,
WorkDate datetime, 
Task NVARCHAR(100),
WorkHours int NOT NULL,
Comments text,

CONSTRAINT PK_WorkHours PRIMARY KEY(WorkID),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
)

GO


INSERT INTO WorkHours (EmployeeID, WorkDate, Task, WorkHours)
VALUES (2, GETDATE(), 'Cleaned some toilets', 30);
INSERT INTO WorkHours (EmployeeID, WorkDate, Task, WorkHours)
VALUES (2, GETDATE(), 'Cleaned some toilets', 30);
INSERT INTO WorkHours (EmployeeID, WorkDate, Task, WorkHours)
VALUES (2, GETDATE(), 'Cleaned some toilets', 30);
INSERT INTO WorkHours (EmployeeID, WorkDate, Task, WorkHours)
VALUES (2, GETDATE(), 'Cleaned some toilets', 30);

INSERT INTO WorkHours (EmployeeID, WorkDate, Task, WorkHours)
VALUES (1, GETDATE(), 'Watched Worker 2 as he was cleaning toilets', 50);

GO

CREATE TABLE WorkHoursLogs
(
LogID int IDENTITY(1,1) NOT NULL,
LogDate int NOT NULL,
WorkID int NOT NULL,

OldEmployeeID int,
OldWorkDate datetime, 
OldTask NVARCHAR(100),
OldWorkHours int,

NewEmployeeID int,
NewWorkDate datetime, 
NewTask NVARCHAR(100),
NewWorkHours int,

CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(LogID),
CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY (WorkID) REFERENCES WorkHours(WorkID)
)

GO

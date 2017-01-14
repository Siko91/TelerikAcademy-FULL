USE [TelerikAcademy]

/*** 
Write a SQL statement to create a table Groups. 
Groups should have unique name (use unique constraint). 
Define primary key and identity column
***/

CREATE TABLE Groups
(
[GroupID] INT IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(50) NOT NULL,

CONSTRAINT PK_Groups PRIMARY KEY([GroupID]),
CONSTRAINT uc_GroupName UNIQUE (Name)
)


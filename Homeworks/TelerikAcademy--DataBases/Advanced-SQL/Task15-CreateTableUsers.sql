USE [TelerikAcademy]

/*** 
Write a SQL statement to create a table Users. 
Users should have username, password, full name and last login time. 
Choose appropriate data types for the table fields. 
Define a primary key column with a primary key constraint. 
Define the primary key column as identity to facilitate inserting records. 
Define unique constraint to avoid repeating usernames. 
Define a check constraint to ensure the password is at least 5 characters long.
***/


CREATE TABLE Users
(
[UserID] INT IDENTITY(1,1) NOT NULL,
[Username] NVARCHAR(50) NOT NULL,
[UserPassword] NVARCHAR(50) NOT NULL,
[FullName] NVARCHAR(50),
[LastLogin] DATETIME,

CONSTRAINT PK_Users PRIMARY KEY([UserID]),
CONSTRAINT uc_Username UNIQUE ([Username]),
CONSTRAINT [MinPassLengthConstraint] CHECK (DATALENGTH([UserPassword]) >= 5)
)


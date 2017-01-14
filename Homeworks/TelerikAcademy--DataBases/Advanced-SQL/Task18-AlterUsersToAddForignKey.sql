USE [TelerikAcademy]

/*** 
Write a SQL statement to add a column GroupID to the table Users. 
Fill some data in this new column and as well in the Groups table.
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
***/

INSERT INTO Groups (Name)
VALUES ('FirstGroup');
GO

ALTER TABLE Users
	ADD GroupID INT
GO

INSERT INTO Users (Username, [UserPassword], LastLogin, GroupID)
VALUES ('NewUser1', 'Password123456', GETDATE(), 1);
INSERT INTO Users (Username, [UserPassword], LastLogin, GroupID)
VALUES ('NewUser2', 'Password123456', GETDATE(), 1);
INSERT INTO Users (Username, [UserPassword], LastLogin, GroupID)
VALUES ('NewUser3', 'Password123456', GETDATE(), 1);
GO

ALTER TABLE Users
	ADD CONSTRAINT FK_Users_Groups
	  FOREIGN KEY (GroupID)
	  REFERENCES Groups(GroupID)


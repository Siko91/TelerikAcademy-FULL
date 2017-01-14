USE [TelerikAcademy]

/*** 
Write SQL statements to insert several records in the Users and Groups tables.
***/

INSERT INTO Groups (Name)
VALUES ('SecondGroup');
INSERT INTO Groups (Name)
VALUES ('ThirdGroup');
INSERT INTO Groups (Name)
VALUES ('LastGroup');
GO

INSERT INTO Users (Username, [UserPassword], LastLogin, GroupID)
VALUES ('NewestUser1', 'Password123456', GETDATE(), 2);
INSERT INTO Users (Username, [UserPassword], LastLogin, GroupID)
VALUES ('NewestUser2', 'Password123456', GETDATE(), 3);
INSERT INTO Users (Username, [UserPassword], LastLogin, GroupID)
VALUES ('NewestUser3', 'Password123456', GETDATE(), 4);
GO

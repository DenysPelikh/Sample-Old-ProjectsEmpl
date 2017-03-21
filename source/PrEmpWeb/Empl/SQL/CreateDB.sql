CREATE DATABASE [EmployeeDB]

GO
USE [EmployeeDB]

GO
CREATE TABLE [Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[Salary] [int] NOT NULL,
) 

INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Melvin', N'Technicist', 1, 7000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Anthony', N'Manager', 0, 12000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Cameron', N'Systems analyst', 1, 12500)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Louisa', N'Systems analyst', 0, 15500)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Richard', N'Head of Department', 1,30000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Charles', N'Technical Director', 1, 20000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Augustus', N'Manager', 0, 9000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Cassandra', N'Technicist', 1, 14000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Collin', N'Technicist', 1, 24000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Miles', N'Technicist', 1, 10000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Gervase', N'Technicist', 0, 10000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Trevor', N'Technicist', 1, 10000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Cassandra', N'Technicist', 1, 20000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Brian', N'Systems analyst', 0, 18000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Thomas', N'Manager', 1, 12000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Cameron', N'Systems analyst', 1, 19000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Elizabeth', N'Systems analyst', 1, 14000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Brian', N'Head of Department', 0, 34000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Morgan', N'Accountant', 0, 9000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Eustacia', N'Technical Director', 1, 24000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Baldwin', N'Manager', 1, 16000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Milton', N'Technical Director', 1, 24000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Alvin', N'Head of Department', 1, 20000)
INSERT INTO [Employee] ([Name], [Position], [Status], [Salary]) VALUES (N'Thomas', N'Manager', 1, 14000)

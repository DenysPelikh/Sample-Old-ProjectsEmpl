CREATE DATABASE [EmpDB]

GO
USE [EmpDB]

GO
CREATE TABLE [Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[Type] [int] NOT NULL,
	[Payment] DECIMAL (18, 2) NOT NULL,
) 

INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Melvin', 0, 4000)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Anthony', 1, 30)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Cameron', 1, 45)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Louisa', 0, 3000)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Richard', 1, 30)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Charles', 0, 3500)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Augustus', 1, 35)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Cassandra', 0, 2500)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Collin', 1, 45)
INSERT INTO [Employee] ([Name], [Type], [Payment]) VALUES (N'Miles', 0, 4500)

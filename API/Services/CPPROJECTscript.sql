USE [master]
GO
/****** Object:  Database [CP_BACKEND]    Script Date: 28-Apr-22 07:53:58 ******/
CREATE DATABASE [CP_BACKEND]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CP_BACKEND', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CP_BACKEND.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CP_BACKEND_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CP_BACKEND_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CP_BACKEND] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CP_BACKEND].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CP_BACKEND] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CP_BACKEND] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CP_BACKEND] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CP_BACKEND] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CP_BACKEND] SET ARITHABORT OFF 
GO
ALTER DATABASE [CP_BACKEND] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CP_BACKEND] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CP_BACKEND] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CP_BACKEND] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CP_BACKEND] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CP_BACKEND] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CP_BACKEND] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CP_BACKEND] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CP_BACKEND] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CP_BACKEND] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CP_BACKEND] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CP_BACKEND] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CP_BACKEND] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CP_BACKEND] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CP_BACKEND] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CP_BACKEND] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CP_BACKEND] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CP_BACKEND] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CP_BACKEND] SET  MULTI_USER 
GO
ALTER DATABASE [CP_BACKEND] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CP_BACKEND] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CP_BACKEND] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CP_BACKEND] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CP_BACKEND] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CP_BACKEND] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CP_BACKEND] SET QUERY_STORE = OFF
GO
USE [CP_BACKEND]
GO
/****** Object:  User [michaelson]    Script Date: 28-Apr-22 07:53:58 ******/
CREATE USER [michaelson] FOR LOGIN [michaelson] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [michaelson]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[timestamp] [datetime2](7) NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
	[ModelId] [int] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](550) NOT NULL,
	[ImagePath] [nvarchar](550) NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](900) NOT NULL,
	[Description] [nvarchar](900) NOT NULL,
	[Cost] [money] NULL,
	[ImagePath] [nvarchar](900) NOT NULL,
	[UploaderID] [int] NOT NULL,
	[timestamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Names] [nvarchar](550) NOT NULL,
	[Email] [nvarchar](550) NOT NULL,
	[Password] [nvarchar](550) NOT NULL,
	[AccountTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([Id], [Type]) VALUES (1, N'Admin')
INSERT [dbo].[AccountType] ([Id], [Type]) VALUES (2, N'Ordinary')
INSERT [dbo].[AccountType] ([Id], [Type]) VALUES (3, N'string')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (1, 5, 4, CAST(N'2022-04-11T11:52:35.4866667' AS DateTime2), CAST(N'2022-04-28T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (2, 3, 2, CAST(N'2022-04-11T11:55:16.5433333' AS DateTime2), CAST(N'2022-04-30T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (3, 3, 2, CAST(N'2022-04-11T12:23:31.8166667' AS DateTime2), CAST(N'2022-04-23T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (4, 3, 2, CAST(N'2022-04-11T12:23:43.0500000' AS DateTime2), CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (5, 3, 2, CAST(N'2022-04-11T12:24:32.4100000' AS DateTime2), CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (6, 3, 2, CAST(N'2022-04-11T12:24:56.3233333' AS DateTime2), CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (7, 3, 2, CAST(N'2022-04-11T12:26:07.2600000' AS DateTime2), CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (9, 3, 2, CAST(N'2022-04-11T12:30:23.0866667' AS DateTime2), CAST(N'2022-04-30T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (10, 3, 2, CAST(N'2022-04-11T12:36:25.7033333' AS DateTime2), CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (11, 3, 4, CAST(N'2022-04-14T16:09:43.0766667' AS DateTime2), CAST(N'2022-04-20T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (12, 3, 2, CAST(N'2022-04-14T16:15:34.2766667' AS DateTime2), CAST(N'2022-04-12T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Bookings] ([Id], [UserId], [ServiceId], [timestamp], [BookingDate], [ModelId]) VALUES (13, 3, 4, CAST(N'2022-04-14T16:49:16.8266667' AS DateTime2), CAST(N'2022-04-14T00:00:00.0000000' AS DateTime2), 2)
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Models] ON 

INSERT [dbo].[Models] ([Id], [Title], [ImagePath]) VALUES (2, N'BMW', N'59734f8d-261d-4.jpg')
INSERT [dbo].[Models] ([Id], [Title], [ImagePath]) VALUES (3, N'Toyota', NULL)
INSERT [dbo].[Models] ([Id], [Title], [ImagePath]) VALUES (4, N'FORD', NULL)
INSERT [dbo].[Models] ([Id], [Title], [ImagePath]) VALUES (5, N'Ferrari FF', N'e667025a-a8aa-4.jpg')
SET IDENTITY_INSERT [dbo].[Models] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Title], [Description], [Cost], [ImagePath], [UploaderID], [timestamp]) VALUES (2, N'Sample Title 505', N'Sample Description', 500.0000, N'63341ccf-596d-4.png', 3, CAST(N'2022-03-21T15:32:18.8000000' AS DateTime2))
INSERT [dbo].[Services] ([Id], [Title], [Description], [Cost], [ImagePath], [UploaderID], [timestamp]) VALUES (4, N'Service Pro', N'Description', 2331.0000, N'c0677a93-1e96-4.jpg', 3, CAST(N'2022-03-22T16:10:56.8733333' AS DateTime2))
INSERT [dbo].[Services] ([Id], [Title], [Description], [Cost], [ImagePath], [UploaderID], [timestamp]) VALUES (6, N'jj', N'jj', 77.0000, N'26b57ef0-f779-4.jpg', 3, CAST(N'2022-04-14T11:55:44.6566667' AS DateTime2))
INSERT [dbo].[Services] ([Id], [Title], [Description], [Cost], [ImagePath], [UploaderID], [timestamp]) VALUES (7, N'oil change', N'Sample Description', 5000.0000, N'e0889dae-4db8-4.PNG', 3, CAST(N'2022-04-19T20:57:01.3500000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Names], [Email], [Password], [AccountTypeId]) VALUES (3, N'Michael Nawa', N'admin@admin.com', N'admin@admin.com', 1)
INSERT [dbo].[Users] ([Id], [Names], [Email], [Password], [AccountTypeId]) VALUES (5, N'OtherUSer', N'user@email.com', N'user@email.com', 2)
INSERT [dbo].[Users] ([Id], [Names], [Email], [Password], [AccountTypeId]) VALUES (6, N'name', N'ttttttt', N'admin@admin.com', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Bookings] ADD  CONSTRAINT [DF_Bookings_timestamp]  DEFAULT (getdate()) FOR [timestamp]
GO
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF_Services_timestamp]  DEFAULT (getdate()) FOR [timestamp]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Models] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Models] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Models]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Services] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Services]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Users]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Users] FOREIGN KEY([UploaderID])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_AccountType] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_AccountType]
GO
/****** Object:  StoredProcedure [dbo].[AccountTypeCreate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AccountTypeCreate]
	@Type nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	Insert into AccountType (Type)
	Values (@Type)

	Select SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AccountTypeDelete]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[AccountTypeDelete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from AccountType
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[AccountTypeGet]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[AccountTypeGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Select * from AccountType
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[AccountTypeGetAll]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[AccountTypeGetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	Select * from AccountType 
END
GO
/****** Object:  StoredProcedure [dbo].[AccountTypeUpdate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[AccountTypeUpdate]
	@id int,
	@Type nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	Update AccountType
	Set Type = @Type
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[BookingsCreate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BookingsCreate] 
	@UserId int,
	@ModelId int,
	@ServiceId int,
	@BookingDate datetime2
AS
BEGIN
	SET NOCOUNT ON;
	Insert into Bookings (UserId,ServiceId,BookingDate,ModelId)
	Values (@UserId,@ServiceId,@BookingDate,@ModelId)

	Select SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[BookingsDelete]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[BookingsDelete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from Bookings
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[BookingsGet]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[BookingsGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Bookings
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[BookingsGetAll]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[BookingsGetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Bookings 
END
GO
/****** Object:  StoredProcedure [dbo].[BookingsUpdate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[BookingsUpdate]
	@id int,
	@ModelId int,
	@UserId int,
	@ServiceId int,
	@BookingDate datetime2
AS
BEGIN
	SET NOCOUNT ON;
	Update Bookings
	Set UserId=@UserId,ServiceId=@ServiceId,BookingDate = @BookingDate,ModelId = @ModelId
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ModelsCreate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ModelsCreate]
	@Title nvarchar(100),
	@ImagePath nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	Insert into Models (Title,ImagePath)
	Values (@Title,@ImagePath)

	Select SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[ModelsDelete]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[ModelsDelete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from Models
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ModelsGet]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ModelsGet]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Models
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ModelsGetAll]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[ModelsGetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Models 
END
GO
/****** Object:  StoredProcedure [dbo].[ModelsUpdate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[ModelsUpdate]
	@id int,
	@Title nvarchar(100),
	@ImagePath nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;
	Update Models
	Set Title = @Title,ImagePath = @ImagePath
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ServicesCreate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ServicesCreate]
	@Title nvarchar(100),
	@Description nvarchar(100),
	@UploaderID int,
		@Cost money,
	@ImagePath nvarchar(900)
AS
BEGIN
	SET NOCOUNT ON;
	Insert into Services (Title,Description,Cost,ImagePath,UploaderID)
	Values (@Title,@Description,@Cost,@ImagePath,@UploaderID)

	Select SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[ServicesDelete]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[ServicesDelete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from Services
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ServicesGet]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[ServicesGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Services
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ServicesGetAll]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[ServicesGetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Services 
END
GO
/****** Object:  StoredProcedure [dbo].[ServicesUpdate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[ServicesUpdate]
	@id int,
	@Title nvarchar(100),
	@Description nvarchar(100),
	@UploaderID int,
	@Cost money,
	@ImagePath nvarchar(900)
AS
BEGIN
	SET NOCOUNT ON;

	if (@ImagePath is null)
		BEGIN
			Update Services
			Set Title=@Title,Description=@Description,Cost=@Cost,UploaderID=@UploaderID
			where id = @id
		END
	ELSE
		BEGIN
			Update Services
			Set Title=@Title,Description=@Description,Cost=@Cost,ImagePath=@ImagePath,UploaderID=@UploaderID
			where id = @id
		END
END
GO
/****** Object:  StoredProcedure [dbo].[TransactionPerWeek]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[TransactionPerWeek]
	 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @StartDate datetime = GETDATE()-6
DECLARE @EndDate datetime = GETDATE()
	
;WITH days AS
(
	SELECT DATEADD(DAY, n, DATEADD(DAY, DATEDIFF(DAY, 0, @StartDate), 0)) as d
	FROM ( SELECT TOP (DATEDIFF(DAY, @StartDate, @EndDate) + 1)
			n = ROW_NUMBER() OVER (ORDER BY [object_id]) - 1
			FROM sys.all_objects ORDER BY [object_id] ) AS n
)
select days.d as days, isnull(SUM(s.Cost),0) as total,
MONTH(getDate())  as Month,
isnull(datepart(WEEKDAY, t.timestamp),datepart(WEEKDAY, days.d))  as Week
FROM days LEFT OUTER JOIN Bookings as t
INNER JOIN Services s on s.Id = t.ServiceId
ON t.timestamp >= days.d AND t.timestamp < DATEADD(DAY, 1, days.d)
GROUP BY days.d,datepart(WEEKDAY, t.timestamp),YEAR(t.timestamp),MONTH(t.timestamp)
ORDER BY days.d desc;


END
GO
/****** Object:  StoredProcedure [dbo].[TransactionPerYear]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[TransactionPerYear]
	 
AS
BEGIN
	SET NOCOUNT ON;
	 DECLARE @StartDate datetime = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)  
DECLARE @EndDate datetime = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()) + 1, -1)  

;WITH days AS
(
		SELECT DATEADD(month, n, DATEADD(month, DATEDIFF(month, 0, @StartDate), 0)) as d
		FROM ( SELECT TOP (DATEDIFF(month, @StartDate, @EndDate) + 1)
		n = ROW_NUMBER() OVER (ORDER BY [object_id]) - 1
		FROM sys.all_objects ORDER BY [object_id] ) AS n

)
SELECT  days.d as days, isnull(SUM(s.Cost),0) as Total,MONTH(Convert(datetime2,  days.d,103)) as Month,YEAR(GETDATE()) as Year
FROM days LEFT OUTER JOIN Bookings as t 
INNER JOIN Services s on s.Id = t.ServiceId
ON Convert(datetime2, t.timestamp,103) >= days.d AND Convert(datetime2, t.timestamp,103) < DATEADD(month, 1, days.d)
--where YEAR(days.d) = YEAR(GETDATE())
group by  days.d,MONTH(Convert(datetime2, t.timestamp,103)) 
order by days.d,MONTH(Convert(datetime2, t.timestamp,103))

END
GO
/****** Object:  StoredProcedure [dbo].[TransactionStats]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[TransactionStats]
	 
AS
BEGIN
	SET NOCOUNT ON;
	Select 
	(Select COUNT(*) from Bookings) as BookingsCount,
	(Select COUNT(*) from Users) as UserCount,
	(Select COUNT(*) from Services) as ServiceCount,
	(Select SUM(s.Cost) from Bookings b INNER JOIN Services s on s.Id = b.ServiceId) as TransactionValue

END
GO
/****** Object:  StoredProcedure [dbo].[UsersChangePassword]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersChangePassword]
	@Id int,
	@Password nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;
	Update Users
	set Password = @Password
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UsersCreate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsersCreate]
	@Names nvarchar(100),
	@Email nvarchar(100),
	@AccountTypeId int,
	@Password nvarchar(900)
AS
BEGIN
	SET NOCOUNT ON;
	Insert into Users (Names,Email,AccountTypeId,Password)
	Values (@Names,@Email,@AccountTypeId,@Password)

	Select SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[UsersDelete]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[UsersDelete]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Delete from Users
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UsersGet]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[UsersGet]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Users
	where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UsersGetAll]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[UsersGetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	Select * from Users 
END
GO
/****** Object:  StoredProcedure [dbo].[UsersLogin]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersLogin] 
	@Email nvarchar(200),
	@Password nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;
	Select * from 
	users where Email = @Email and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[UsersUpdate]    Script Date: 28-Apr-22 07:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
CREATE PROCEDURE [dbo].[UsersUpdate]
	@id int,
	@Names nvarchar(100),
	@Email nvarchar(100),
	@AccountTypeId int
AS
BEGIN
	SET NOCOUNT ON;
	Update Users
	Set Names = @Names,Email= @Email,AccountTypeId= @AccountTypeId
	where id = @id
END
GO
USE [master]
GO
ALTER DATABASE [CP_BACKEND] SET  READ_WRITE 
GO

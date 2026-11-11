/*
    DVLD System - Database Creation and Schema
    Source: SQL Server Generate Scripts (Schema only), with database creation added.

    IMPORTANT:
    - This script creates the DVLD2 database if it does not already exist.
    - It then creates the database tables, keys, indexes, defaults, checks, and relationships.
    - Run it using an account that has permission to create databases.
    - If DVLD2 already exists, it must be empty; this script does not drop or overwrite it.
    - This script does not insert reference or user data.
*/

USE [master];
GO

IF DB_ID(N'DVLD2') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE [DVLD2];');
END;
GO

USE [DVLD2];
GO

IF EXISTS (
    SELECT 1
    FROM sys.tables
    WHERE is_ms_shipped = 0
)
BEGIN
    THROW 50000, 'The DVLD2 database already contains user tables. Use an empty database.', 1;
END;
GO

/****** Object:  Table [dbo].[Applications]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
	[ApplicationStatusID] [int] NOT NULL,
	[ApplicationDate] [datetime2](0) NOT NULL,
	[ApplicationPaidFees] [decimal](10, 2) NOT NULL,
 CONSTRAINT [Applications_ApplicationID_PK] PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Applications_ApplicationID_PersonID_UQ] UNIQUE NONCLUSTERED 
(
	[ApplicationID] ASC,
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Applications_ApplicationID_ServiceID_UQ] UNIQUE NONCLUSTERED 
(
	[ApplicationID] ASC,
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationStatuses]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationStatuses](
	[ApplicationStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](150) NOT NULL,
 CONSTRAINT [ApplicationStatuses_ApplicationStatusID_PK] PRIMARY KEY CLUSTERED 
(
	[ApplicationStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [ApplicationStatuses_StatusName_QU] UNIQUE NONCLUSTERED 
(
	[StatusName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArabCountries]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArabCountries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](150) NOT NULL,
	[CountryCode] [nvarchar](10) NULL,
 CONSTRAINT [PK_Arab Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](150) NOT NULL,
	[CountryCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FirstTimeLicenseApplicationDetails]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FirstTimeLicenseApplicationDetails](
	[ApplicationID] [int] NOT NULL,
	[LicenseClassID] [int] NOT NULL,
	[ServiceID] [int] NOT NULL,
 CONSTRAINT [FirstTimeLicenseApplicationDetails_ApplicationID_PK] PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseClasses]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseClasses](
	[LicenseClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](150) NOT NULL,
	[MinimumAllowedAge] [tinyint] NOT NULL,
	[LicenseFees] [decimal](10, 2) NOT NULL,
	[DefaultValidityLength] [smallint] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [LicenseClasses_LicenseClassID_PK] PRIMARY KEY CLUSTERED 
(
	[LicenseClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [LicenseClasses_ClassName_QU] UNIQUE NONCLUSTERED 
(
	[ClassName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseIssueReasons]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseIssueReasons](
	[ReasonID] [int] IDENTITY(1,1) NOT NULL,
	[ReasonName] [nvarchar](500) NOT NULL,
 CONSTRAINT [LicenseIssueReasons_ReasonID_PK] PRIMARY KEY CLUSTERED 
(
	[ReasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [LicenseIssueReasons_ReasonName_UQ] UNIQUE NONCLUSTERED 
(
	[ReasonName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Licenses]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licenses](
	[LicenseID] [int] IDENTITY(1,1) NOT NULL,
	[LicenseNumber] [int] NOT NULL,
	[ApplicationID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[LicenseClassID] [int] NOT NULL,
	[IssueDate] [datetime2](0) NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[IssueReasonID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [Licenses_LicenseID_PK] PRIMARY KEY CLUSTERED 
(
	[LicenseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Licenses_ApplicationID_UQ] UNIQUE NONCLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Licenses_LicenseNumber_UQ] UNIQUE NONCLUSTERED 
(
	[LicenseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionName] [nvarchar](250) NOT NULL,
	[PermissionCategory] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [Permissions_PermissionID_PK] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Permissions_PermissionName_UQ] UNIQUE NONCLUSTERED 
(
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[NationalNO] [varchar](250) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[SecondName] [nvarchar](50) NOT NULL,
	[ThirdName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Email] [varchar](550) NULL,
	[Phone] [varchar](50) NOT NULL,
	[Address] [nvarchar](2000) NULL,
	[NationalityCountryID] [int] NULL,
	[ImageName] [nvarchar](1000) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](0) NULL,
 CONSTRAINT [Persons_PersonID_PK] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Persons_NationalON_UQ] UNIQUE NONCLUSTERED 
(
	[NationalNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Persons_Phone_UQ] UNIQUE NONCLUSTERED 
(
	[Phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[FK_RoleID] [int] NOT NULL,
	[FK_PermissionID] [int] NOT NULL,
 CONSTRAINT [RolePermissions_RoleID_PermissionID_PK] PRIMARY KEY CLUSTERED 
(
	[FK_RoleID] ASC,
	[FK_PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](550) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](0) NULL,
 CONSTRAINT [Roles_RoleID_PK] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Roles_RoleName_UQ] UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](150) NOT NULL,
	[ApplicationFees] [decimal](10, 2) NULL,
 CONSTRAINT [Services_ServiceID_PK] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Services_ServiceName_UQ] UNIQUE NONCLUSTERED 
(
	[ServiceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[FK_UserID] [int] NOT NULL,
	[FK_RoleID] [int] NOT NULL,
 CONSTRAINT [UserRoles_UserID_RoleID_PK] PRIMARY KEY CLUSTERED 
(
	[FK_UserID] ASC,
	[FK_RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/11/2026 01:33:05 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[UserName] [varchar](250) NOT NULL,
	[Password] [varchar](550) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](0) NULL,
 CONSTRAINT [Users_UserID_PK] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [Users_UserName_UQ] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [Applications_PersonID_ServiceID_ApplicationStatusIsNew_UX]    Script Date: 09/11/2026 01:33:05 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [Applications_PersonID_ServiceID_ApplicationStatusIsNew_UX] ON [dbo].[Applications]
(
	[PersonID] ASC,
	[ServiceID] ASC
)
WHERE ([ApplicationStatusID]=(1))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Licenses_PersonID_LicenseClassID_Active_UX]    Script Date: 09/11/2026 01:33:05 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [Licenses_PersonID_LicenseClassID_Active_UX] ON [dbo].[Licenses]
(
	[PersonID] ASC,
	[LicenseClassID] ASC
)
WHERE ([IsActive]=(1))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Persons_Email_UQ]    Script Date: 09/11/2026 01:33:05 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [Persons_Email_UQ] ON [dbo].[Persons]
(
	[Email] ASC
)
WHERE ([Email] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [Users_PersonID_Active_UQ]    Script Date: 09/11/2026 01:33:05 م ******/
CREATE UNIQUE NONCLUSTERED INDEX [Users_PersonID_Active_UQ] ON [dbo].[Users]
(
	[PersonID] ASC
)
WHERE ([IsDeleted]=(0))
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Applications] ADD  CONSTRAINT [Applications_ApplicationDate_DF]  DEFAULT (getdate()) FOR [ApplicationDate]
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails] ADD  CONSTRAINT [FirstTimeDetails_ServiceID_DF]  DEFAULT ((1)) FOR [ServiceID]
GO
ALTER TABLE [dbo].[LicenseClasses] ADD  CONSTRAINT [DF_LicenseClasses_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Licenses] ADD  CONSTRAINT [Licenses_IssueDate_DF]  DEFAULT (getdate()) FOR [IssueDate]
GO
ALTER TABLE [dbo].[Licenses] ADD  CONSTRAINT [Licenses_IsActive_DF]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Permissions] ADD  CONSTRAINT [DF_Permissions_IsDeleted]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Persons] ADD  CONSTRAINT [DF_Persons_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [Applications_ApplicationStatusID_FK] FOREIGN KEY([ApplicationStatusID])
REFERENCES [dbo].[ApplicationStatuses] ([ApplicationStatusID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [Applications_ApplicationStatusID_FK]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [Applications_PersonID_FK] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [Applications_PersonID_FK]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD  CONSTRAINT [Applications_ServiceID_FK] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
GO
ALTER TABLE [dbo].[Applications] CHECK CONSTRAINT [Applications_ServiceID_FK]
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails]  WITH CHECK ADD  CONSTRAINT [FirstTimeLicenseApplicationDetails_ApplicationID_FK] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails] CHECK CONSTRAINT [FirstTimeLicenseApplicationDetails_ApplicationID_FK]
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails]  WITH CHECK ADD  CONSTRAINT [FirstTimeLicenseApplicationDetails_ApplicationID_ServiceID_FK] FOREIGN KEY([ApplicationID], [ServiceID])
REFERENCES [dbo].[Applications] ([ApplicationID], [ServiceID])
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails] CHECK CONSTRAINT [FirstTimeLicenseApplicationDetails_ApplicationID_ServiceID_FK]
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails]  WITH CHECK ADD  CONSTRAINT [FirstTimeLicenseApplicationDetails_LicenseClassID_FK] FOREIGN KEY([LicenseClassID])
REFERENCES [dbo].[LicenseClasses] ([LicenseClassID])
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails] CHECK CONSTRAINT [FirstTimeLicenseApplicationDetails_LicenseClassID_FK]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [Licenses_ApplicationID_FK] FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [Licenses_ApplicationID_FK]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [Licenses_ApplicationID_PersonID_FK] FOREIGN KEY([ApplicationID], [PersonID])
REFERENCES [dbo].[Applications] ([ApplicationID], [PersonID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [Licenses_ApplicationID_PersonID_FK]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [Licenses_LicenseClassID_FK] FOREIGN KEY([LicenseClassID])
REFERENCES [dbo].[LicenseClasses] ([LicenseClassID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [Licenses_LicenseClassID_FK]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [Licenses_PersonID_FK] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [Licenses_PersonID_FK]
GO
ALTER TABLE [dbo].[Licenses]  WITH CHECK ADD  CONSTRAINT [Licenses_ReasonID_FK] FOREIGN KEY([IssueReasonID])
REFERENCES [dbo].[LicenseIssueReasons] ([ReasonID])
GO
ALTER TABLE [dbo].[Licenses] CHECK CONSTRAINT [Licenses_ReasonID_FK]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [Persons_NationalityCountryID_FK] FOREIGN KEY([NationalityCountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [Persons_NationalityCountryID_FK]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [RolePermissions_PermissionID_FK] FOREIGN KEY([FK_PermissionID])
REFERENCES [dbo].[Permissions] ([PermissionID])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [RolePermissions_PermissionID_FK]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [RolePermissions_RoleID_FK] FOREIGN KEY([FK_RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [RolePermissions_RoleID_FK]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [UserRoles_RoleID_FK] FOREIGN KEY([FK_RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [UserRoles_RoleID_FK]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [UserRoles_UserID_FK] FOREIGN KEY([FK_UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [UserRoles_UserID_FK]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Users_PersonID_FK] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Users_PersonID_FK]
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails]  WITH CHECK ADD  CONSTRAINT [FirstTimeDetails_ServiceID_CK] CHECK  (([ServiceID]=(1)))
GO
ALTER TABLE [dbo].[FirstTimeLicenseApplicationDetails] CHECK CONSTRAINT [FirstTimeDetails_ServiceID_CK]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [Person_DateOfBirth_CHK] CHECK  (([DateOfBirth]<=getdate() AND [DateOfBirth]>='1900-01-01'))
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [Person_DateOfBirth_CHK]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [Person_Gender_CHK] CHECK  (([Gender]='F' OR [Gender]='M'))
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [Person_Gender_CHK]
GO

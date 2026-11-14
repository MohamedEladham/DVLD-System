/*
    DVLD System - Initial Admin Account Setup

    Run AFTER:
      01_Create_DB_DVLD2_Schema.sql
      02_SeedData.sql

    Instructions:
      1. Set your own username and password.
      2. Execute this script in SQL Server Management Studio.

    Note:
      Passwords must contain printable ASCII characters.
      This ensures compatibility with the application's
      current UTF-8 SHA-256 hashing implementation.
*/

USE [DVLD2];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

-- Customize these values
DECLARE @AdminUserName VARCHAR(250) = 'Admin';

-- Enter Your Password
-- Note: Password must contain at least 3 characters.
DECLARE @AdminPassword NVARCHAR(128) = N'';

DECLARE @PersonID INT;
DECLARE @UserID INT;
DECLARE @UniqueID VARCHAR(36) = CONVERT(VARCHAR(36), NEWID());
DECLARE @NationalNO VARCHAR(250);
DECLARE @Phone VARCHAR(50);
DECLARE @PasswordHash VARCHAR(64);
DECLARE @Index INT = 1;

BEGIN TRY

    -- Validate username
    IF LEN(@AdminUserName) = 0
        THROW 50001, 'Username cannot be empty.', 1;

	-- Validate password length
    IF LEN(@AdminPassword) < 3
        THROW 50002, 'Password must contain at least 3 characters.', 1;

    -- Ensure password contains ASCII characters only
    WHILE @Index <= DATALENGTH(@AdminPassword) / 2
    BEGIN
        IF UNICODE(SUBSTRING(@AdminPassword, @Index, 1))
           NOT BETWEEN 32 AND 126
            THROW 50003, 'Password must use printable ASCII characters only.', 1;

        SET @Index += 1;
    END;

    -- Ensure Admin role exists
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Roles
        WHERE RoleID = 1
          AND RoleName = 'Admin'
          AND IsDeleted = 0
    )
        THROW 50004, 'Active Admin role was not found.', 1;

    -- Prevent duplicate username
    IF EXISTS (
        SELECT 1
        FROM dbo.Users
        WHERE UserName = @AdminUserName
    )
        THROW 50005, 'This username already exists.', 1;

    -- Generate unique person identifiers
    SET @NationalNO = 'BOOTSTRAP-' + @UniqueID;
    SET @Phone = 'BOOT-' + REPLACE(@UniqueID, '-', '');

    -- Generate SHA-256 hash compatible with the application
    SET @PasswordHash = LOWER(
        CONVERT(
            VARCHAR(64),
            HASHBYTES('SHA2_256', CONVERT(VARCHAR(128), @AdminPassword)),
            2
        )
    );

    BEGIN TRANSACTION;

    -- Create Admin person
    INSERT INTO dbo.Persons
    (
        NationalNO,
        FirstName,
        SecondName,
        ThirdName,
        LastName,
        Gender,
        DateOfBirth,
        Email,
        Phone,
        Address,
        NationalityCountryID,
        IsDeleted
    )
    VALUES
    (
        @NationalNO,
        N'Demo',
        N'Admin',
        N'Setup',
        N'User',
        'M',
        '1990-01-01',
        NULL,
        @Phone,
        N'Bootstrap Account',
        250,
        0
    );

    SET @PersonID = SCOPE_IDENTITY();

    -- Create Admin user
    INSERT INTO dbo.Users
    (
        PersonID,
        UserName,
        Password,
        IsActive,
        IsDeleted
    )
    VALUES
    (
        @PersonID,
        @AdminUserName,
        @PasswordHash,
        1,
        0
    );

    SET @UserID = SCOPE_IDENTITY();

    -- Assign Admin role
    INSERT INTO dbo.UserRoles
    (
        FK_UserID,
        FK_RoleID
    )
    VALUES
    (
        @UserID,
        1
    );

    COMMIT TRANSACTION;

    SELECT
        @PersonID AS PersonID,
        @UserID AS UserID,
        @AdminUserName AS UserName,
        'Admin' AS AssignedRole,
        'Created successfully' AS Result;

END TRY
BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;

END CATCH;
GO

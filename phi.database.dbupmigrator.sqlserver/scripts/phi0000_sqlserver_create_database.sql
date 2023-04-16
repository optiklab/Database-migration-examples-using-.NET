-- COPYRIGHT 2022 Anton Yarkov
-- Email: anton.yarkov@gmail.com
-- Skype: optiklab

-----------------------------------------------------------------

--SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

--SET NUMERIC_ROUNDABORT OFF;


--GO
--DECLARE @DatabaseName AS NVARCHAR(15)
--SET @DatabaseName = 'Phi'

--DECLARE @DefaultDataPath AS NVARCHAR(150)
----SET @DatabaseName = 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\'

--DECLARE @DefaultLogPath AS NVARCHAR(150)
----SET @DefaultLogPath = 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\'

--GO
--USE [master];


--GO

--IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
--BEGIN
--    ALTER DATABASE [$(DatabaseName)]
--    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--    DROP DATABASE [$(DatabaseName)];
--END

--GO
--PRINT N'Creating database $(DatabaseName)...'
--GO
--CREATE DATABASE [$(DatabaseName)]
--    ON 
--    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
--    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE Cyrillic_General_CI_AS
--GO
--IF EXISTS (SELECT 1
--           FROM   [master].[dbo].[sysdatabases]
--           WHERE  [name] = N'$(DatabaseName)')
--    BEGIN
--        ALTER DATABASE [$(DatabaseName)]
--            SET AUTO_CLOSE OFF 
--            WITH ROLLBACK IMMEDIATE;
--    END

--GO
--USE [$(DatabaseName)];


-----------------------------------------------------------------
-----------------------------------------------------------------
-----------------------------------------------------------------



--GO
--SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

--SET NUMERIC_ROUNDABORT OFF;
--GO

--USE [Phi];
--GO

--PRINT N'Creating database [Phi]...'
--GO
--CREATE DATABASE [Phi]
--    ON 
--    PRIMARY(NAME = [Phi], FILENAME = N'$Phi_Primary.mdf')
--    LOG ON (NAME = [Phi_log], FILENAME = N'Phi_Primary.ldf') COLLATE Cyrillic_General_CI_AS
--GO
--IF EXISTS (SELECT 1
--           FROM   [master].[dbo].[sysdatabases]
--           WHERE  [name] = N'Phi')
--    BEGIN
--        ALTER DATABASE [Phi]
--            SET AUTO_CLOSE OFF 
--            WITH ROLLBACK IMMEDIATE;
--    END
--GO




IF OBJECT_ID('[dbo].[Logins]', 'U') IS NOT NULL
DROP TABLE [dbo].[Logins]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Logins]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Logs] NVARCHAR(20) NOT NULL UNIQUE,
    [Pass] NVARCHAR(20) NOT NULL,
    [Banned] INT NOT NULL DEFAULT 0
    -- Specify more columns here
);
IF OBJECT_ID('[dbo].[Authors]', 'U') IS NOT NULL
DROP TABLE [dbo].[Authors]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Authors]
(
    [AuthorID] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Name] NVARCHAR(30) NOT NULL UNIQUE,
    -- Specify more columns here
);
IF OBJECT_ID('[dbo].[Type]', 'U') IS NOT NULL
DROP TABLE [dbo].[Type]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Type]
(
    [TypeID] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Name] NVARCHAR(5) NOT NULL,
    -- Specify more columns here
);
IF OBJECT_ID('[dbo].[Books]', 'U') IS NOT NULL
DROP TABLE [dbo].[Books]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Books]
(
    [BookID] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Name] NVARCHAR(40) NOT NULL UNIQUE,
    [AuthorID] INT NOT NULL,
    [Type] INT NOT NULL,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID),
    FOREIGN KEY (Type) REFERENCES Type(TypeID)
    -- Specify more columns here
);
IF OBJECT_ID('[dbo].[Progress]', 'U') IS NOT NULL
DROP TABLE [dbo].[Progress]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Progress]
(
    [ID] INT NOT NULL PRIMARY KEY IDENTITY, -- Primary Key column
    [Reader] NVARCHAR(20) NOT NULL,
    [BooksID] INT NOT NULL UNIQUE,
    [AuthorID] INT NOT NULL,
    [FinishPage] INT NOT NULL DEFAULT 0, 
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID),
    FOREIGN KEY (BooksID) REFERENCES Books(BookID)
    -- Specify more columns here
);
GO
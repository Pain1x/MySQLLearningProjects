-- Create a new stored procedure called 'sp_BookAddToLibrary' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_BookAddToLibrary'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_BookAddToLibrary
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_BookAddToLibrary
    @AName NVARCHAR(20),
    @BName NVARCHAR(40)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
IF (Select Name from Authors where Name=@AName)=@AName
BEGIN
INSERT Books
Values(@BName,(Select AuthorID from Authors where Name=@AName ),1)
    END;
ELSE
INSERT Authors
VALUES(@AName);
INSERT Books
Values(@BName,(Select AuthorID from Authors where Name=@AName ),1)
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.sp_BookAddToLibrary N'Дж. Д. Селінджер', N'Ловець у житті'
GO
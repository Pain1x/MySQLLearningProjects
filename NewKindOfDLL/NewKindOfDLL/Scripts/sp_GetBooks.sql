-- Create a new stored procedure called 'sp_GetBooks' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_GetBooks'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_GetBooks
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_GetBooks
  @Name NVARCHAR(20)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
SELECT Books.Name as BooksName,[Type].Name as Type  from [dbo].[Books]
JOIN Authors ON Authors.AuthorID=Books.AuthorID and  Authors.Name = @Name
JOIN Type ON Type.TypeID=Books.Type
ORDER BY Books.Name

EXEC sp_GetBooks N'Ден Браун'

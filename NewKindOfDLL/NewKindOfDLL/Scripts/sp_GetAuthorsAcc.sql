-- Create a new stored procedure called 'sp_GetAuthorsAcc' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_GetAuthorsAcc'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_GetAuthorsAcc
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_GetAuthorsAcc
    @Name NVARCHAR(20)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
SELECT Books.Name as BooksName,Progress.FinishPage,[Type].Name as Type  from [dbo].[Books]
JOIN Authors ON Authors.AuthorID=Books.AuthorID and  Authors.Name = @Name
JOIN Type ON Type.TypeID=Books.Type
JOIN Progress On Progress.AuthorID=Books.AuthorID
ORDER BY Books.Name
GO
-- example to execute the stored procedure we just created
EXECUTE dbo.sp_GetAuthorsAcc N'Ден Браун'
GO
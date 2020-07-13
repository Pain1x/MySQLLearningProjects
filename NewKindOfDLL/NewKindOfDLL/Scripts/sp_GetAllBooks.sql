-- Create a new stored procedure called 'sp_GetAllBooks' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_GetAllBooks'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_GetAllBooks
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_GetAllBooks
@ReaderID int
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
SELECT Books.Name as Book from Progress
JOIN Books ON Books.BookID=Progress.BooksID
where Reader=(Select Logs from Logins where ID=@ReaderID)
GO
-- example to execute the stored procedure we just created

EXEC sp_GetAllBooks 1
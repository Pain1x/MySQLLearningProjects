-- Create a new stored procedure called 'sp_GetAccBooks' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_GetAccBooks'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_GetAccBooks
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_GetAccBooks
@ReaderID int,
@BooksName NVARCHAR(40)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
SELECT Books.Name,[Type].Name as Type,FinishPage from Progress
JOIN Books ON Books.BookID=Progress.BooksID
JOIN Authors ON Authors.AuthorID=Progress.AuthorID and Books.Name=@BooksName
JOIN [Type] ON [Type].TypeID=Books.[Type]
Where Reader=(Select Logs from Logins where ID=@ReaderID)

-- example to execute the stored procedure we just created
EXECUTE dbo.sp_GetAccBooks  1, N'Янголи та демони'
GO
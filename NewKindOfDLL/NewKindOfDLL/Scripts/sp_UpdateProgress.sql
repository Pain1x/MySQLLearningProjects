-- Create a new stored procedure called 'sp_UpdateProgress' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_UpdateProgress'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_UpdateProgress
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_UpdateProgress
    @ReaderID int,
    @BooksName NVARCHAR(40),
    @AuthorsName NVARCHAR(20)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    -- Insert rows into table 'Progress' in schema '[dbo]'
    INSERT INTO [dbo].[Progress]
    ( -- Columns to insert data into
     [Reader], [BooksID], [AuthorID],[FinishPage]
    )
    VALUES
    ( -- First row: values for the columns in the list above
     (Select Logs from Logins where ID = @ReaderID), (SELECT BookID from Books where Name = @BooksName), (Select AuthorID from Authors where Name=@AuthorsName),DEFAULT
    )
    -- Add more rows here
    GO
GO

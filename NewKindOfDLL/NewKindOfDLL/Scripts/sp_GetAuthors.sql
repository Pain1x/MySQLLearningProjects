-- Create a new stored procedure called 'sp_GetAuthors' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_GetAuthors'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_GetAuthors
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_GetAuthors
@ReaderID INT
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
SELECT Distinct  Authors.Name as Author from Progress
JOIN Authors ON Authors.AuthorID=Progress.AuthorID
where Reader=(Select Logs from Logins where ID=@ReaderID)
GO 

EXEC sp_GetAuthors 1

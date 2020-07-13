-- Create a new stored procedure called 'sp_PassCheker' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_PassCheker'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_PassCheker
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_PassCheker
    @Name NVARCHAR(20)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
   Select Pass from Logins where Logs=@Name
GO

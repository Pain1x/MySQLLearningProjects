-- Create a new stored procedure called 'sp_PassChanger' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_PassChanger'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_PassChanger
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_PassChanger
    @Name  NVARCHAR(20),
    @Pass NVARCHAR(20)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    Update Logins Set Pass = @Pass where Logs=@Name
GO
-- example to execute the stored procedure we just created

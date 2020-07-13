-- Create a new stored procedure called 'sp_Login' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_Login'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_Login
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_Login
    @UserName nvarchar(20),
    @Password  nvarchar(20)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    Select ID,Logs,Pass from Logins where Logs=@UserName and Pass =@Password;
GO


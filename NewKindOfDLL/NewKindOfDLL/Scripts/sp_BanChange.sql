-- Create a new stored procedure called 'sp_BanChange' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_BanChange'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_BanChange
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_BanChange
    @UserName NVARCHAR(20)
-- add more stored procedure parameters here
AS
Update Logins
SET Banned = 1 where Logs=@UserName
GO

-- Create a new stored procedure called 'sp_Ban' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_Ban'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_Ban
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_Ban
    @UserName NVARCHAR(20),
    @Ban INT OUT
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
   SELECT TOP 1 @Ban = Banned FROM Logins
   WHERE Logs=@UserName
GO

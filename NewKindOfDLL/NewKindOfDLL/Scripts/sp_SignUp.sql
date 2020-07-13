-- Create a new stored procedure called 'sp_SignUp' in schema 'dbo'
-- Drop the stored procedure if it already exists

-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_SignUp
    @Login NVARCHAR(20),
    @Pass NVARCHAR(20)
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    Insert Logins VALUES(@Login,@Pass,DEFAULT)
GO

-- Create a new stored procedure called 'sp_Authors' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'sp_Authors'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.sp_Authors
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.sp_Authors
-- add more stored procedure parameters here
AS
    -- body of the stored procedure
    SELECT Name as Author from Authors
GO
-- example to execute the stored procedure we just created

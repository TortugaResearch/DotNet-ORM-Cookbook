/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


:r ".\Data\EmployeeClassification.sql"
:r ".\Data\Employee.sql"
:r ".\Data\Division.sql"
:r ".\Data\Student.sql"

--Ensure all constraints are enabled
 
DECLARE @TableList TABLE
(
    TableId INT NOT NULL IDENTITY,
    SchameName NVARCHAR(100) NOT NULL,
    TableName NVARCHAR(100) NOT NULL
);
 
INSERT INTO @TableList
(
    SchameName,
    TableName
)
SELECT s.name,
       t.name
FROM sys.tables t
    INNER JOIN sys.schemas s
        ON t.schema_id = s.schema_id;
 
DECLARE @LastRow INT = 0;
DECLARE @SQL NVARCHAR(1000);
 
WHILE EXISTS (SELECT * FROM @TableList tl WHERE tl.TableId > @LastRow  )
BEGIN
       SET @LastRow = @LastRow+ 1;
       SELECT @SQL = 'ALTER TABLE [' + tl.SchameName + '].[' + tl.TableName + '] WITH CHECK CHECK CONSTRAINT ALL'
       FROM @TableList tl WHERE tl.TableId = @LastRow;
 
       EXEC sys.sp_executesql @SQL
END
CREATE VIEW HR.EmployeeDetail
WITH SCHEMABINDING
AS
SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey,
       ec.EmployeeClassificationName,
       ec.IsExempt,
       ec.IsEmployee
FROM HR.Employee e
    INNER JOIN HR.EmployeeClassification ec
        ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey;

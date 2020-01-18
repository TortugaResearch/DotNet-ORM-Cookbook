CREATE PROCEDURE HR.CountEmployeesByClassification
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(e.EmployeeKey) AS EmployeeCount,
           ec.EmployeeClassificationKey,
           ec.EmployeeClassificationName
    FROM HR.EmployeeClassification ec
        LEFT JOIN HR.Employee e
            ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey
    GROUP BY ec.EmployeeClassificationKey,
             ec.EmployeeClassificationName
    ORDER BY ec.EmployeeClassificationName;

    RETURN 0;
END;
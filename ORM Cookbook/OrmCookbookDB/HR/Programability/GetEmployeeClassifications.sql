CREATE PROCEDURE HR.GetEmployeeClassifications @EmployeeClassificationKey INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ec.EmployeeClassificationKey,
           ec.EmployeeClassificationName,
           ec.IsExempt,
           ec.IsEmployee
    FROM HR.EmployeeClassification ec
    WHERE (@EmployeeClassificationKey IS NULL)
          OR (ec.EmployeeClassificationKey = @EmployeeClassificationKey);

    RETURN 0;
END;
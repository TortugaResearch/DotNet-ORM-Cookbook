CREATE PROCEDURE HR.CreateEmployeeClassification
    @EmployeeClassificationName VARCHAR(30),
    @IsExempt BIT,
    @IsEmployee BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO HR.EmployeeClassification
    (
        EmployeeClassificationName,
        IsExempt,
        IsEmployee
    )
    VALUES
    (@EmployeeClassificationName, @IsExempt, @IsEmployee);

	--Use a temp variable to ensure the correct data type
	DECLARE @EmployeeClassificationKey INT = SCOPE_IDENTITY();
    SELECT @EmployeeClassificationKey AS EmployeeClassificationKey;

    RETURN 0;
END;
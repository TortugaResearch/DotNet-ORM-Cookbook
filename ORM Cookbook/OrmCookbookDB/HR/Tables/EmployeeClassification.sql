CREATE TABLE HR.EmployeeClassification
(
    EmployeeClassificationKey INT NOT NULL IDENTITY(1000, 1)
        CONSTRAINT PK_EmployeeClassification PRIMARY KEY,
    EmployeeClassificationName VARCHAR(30) NOT NULL
        CONSTRAINT UX_EmployeeClassification_EmployeeClassificationName
        UNIQUE,
    IsExempt BIT NOT NULL
        CONSTRAINT D_EmployeeClassification_IsExempt
            DEFAULT (0),
    IsEmployee BIT NOT NULL
        CONSTRAINT D_EmployeeClassification_IsEmployee
            DEFAULT (1)
);
GO

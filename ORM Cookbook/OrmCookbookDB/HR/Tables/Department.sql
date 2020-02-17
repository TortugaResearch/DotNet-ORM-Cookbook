CREATE TABLE HR.Department
(
    DepartmentKey INT NOT NULL IDENTITY(1000, 1)
        CONSTRAINT PK_Department PRIMARY KEY,
    DepartmentName NVARCHAR(30) NOT NULL
        CONSTRAINT UX_Department_DepartmentName
        UNIQUE,
    DivisionKey INT NOT NULL
        CONSTRAINT FK_Department_DivisionKey
        REFERENCES HR.Division (DivisionKey),
    CreatedDate DATETIME2(7) NULL,
    ModifiedDate DATETIME2(7) NULL,
    CreatedByEmployeeKey INT NULL
        CONSTRAINT FK_Department_CreatedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    ModifiedByEmployeeKey INT NULL
        CONSTRAINT FK_Department_ModifiedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    IsDeleted BIT NOT NULL
        CONSTRAINT D_Department_IsDeleted
            DEFAULT (0)
);

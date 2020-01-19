CREATE TABLE HR.Division
(
    DivisionKey INT NOT NULL IDENTITY(1000, 1)
        CONSTRAINT PK_Division PRIMARY KEY,
    DivisionId UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT D_Division_DivisionId
            DEFAULT (NEWSEQUENTIALID()),
    DivisionName NVARCHAR(30) NOT NULL
        CONSTRAINT UX_Division_DivisionName
        UNIQUE,
    CreatedDate DATETIME2(7) NOT NULL
        CONSTRAINT D_Division_CreatedDate
            DEFAULT SYSUTCDATETIME(),
    ModifiedDate DATETIME2(7) NOT NULL
        CONSTRAINT D_Division_ModifiedDate
            DEFAULT SYSUTCDATETIME(),
    CreatedByEmployeeKey INT NOT NULL
        CONSTRAINT FK_Division_CreatedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    ModifiedByEmployeeKey INT NOT NULL
        CONSTRAINT FK_Division_ModifiedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    SalaryBudget DECIMAL(14, 4) NULL,
    FteBudget NUMERIC(5, 1) NULL,
    SuppliesBudget DECIMAL(14, 4) NULL,
    FloorSpaceBudget FLOAT(24) NULL,
    MaxEmployees INT NULL,
    LastReviewCycle DATETIMEOFFSET NULL,
    StartTime TIME NULL
);

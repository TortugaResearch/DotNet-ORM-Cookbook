CREATE TABLE HR.Employee
(
    EmployeeKey INT NOT NULL IDENTITY(1000, 1)
        CONSTRAINT PK_Employee PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50) NULL,
    LastName NVARCHAR(50) NOT NULL,
    Title NVARCHAR(100) NULL,
    OfficePhone VARCHAR(15) NULL,
    CellPhone VARCHAR(15) NULL,
    EmployeeClassificationKey INT NOT NULL
        CONSTRAINT FK_Employee_EmployeeClassificationKey
        REFERENCES HR.EmployeeClassification (EmployeeClassificationKey)
);

GO

CREATE INDEX IX_Employee_LastName ON HR.Employee (LastName);

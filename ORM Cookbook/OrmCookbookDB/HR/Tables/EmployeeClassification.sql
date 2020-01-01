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
            DEFAULT (1),
    IncludeInHolidayParty BIT NULL
        CONSTRAINT D_EmployeeClassification_IncludeInHolidayParty
            DEFAULT (1)
);
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description',
                                @value = N'An unusual case where there is a default for a nullable column.',
                                @level0type = N'SCHEMA',
                                @level0name = N'HR',
                                @level1type = N'TABLE',
                                @level1name = N'EmployeeClassification',
                                @level2type = N'COLUMN',
                                @level2name = N'IncludeInHolidayParty';

GO

DECLARE @Division TABLE
(
    DivisionKey INT NOT NULL PRIMARY KEY,
    DivisionName NVARCHAR(30) NOT NULL
        UNIQUE,
    CreatedByEmployeeKey INT NOT NULL
        DEFAULT 1,
    ModifiedByEmployeeKey INT NOT NULL
        DEFAULT 1,
    SalaryBudget DECIMAL(14, 4) NULL,
    FteBudget NUMERIC(5, 1) NULL,
    SuppliesBudget DECIMAL(14, 4) NULL,
    FloorSpaceBudget FLOAT(24) NULL,
    MaxEmployees INT NULL,
    LastReviewCycle DATETIMEOFFSET NULL
        DEFAULT SYSDATETIMEOFFSET(),
    StartTime TIME NULL
);


INSERT INTO @Division
(
    DivisionKey,
    DivisionName,
    SalaryBudget,
    FteBudget,
    SuppliesBudget,
    FloorSpaceBudget,
    MaxEmployees,
    StartTime
)
VALUES
(1, 'HR', 875000, 10.5, 20000, 12000, 15, '9:00'),
(2, 'Accounting', null, null, null, null, null, null),
(3, 'Sales', 2312000, 40.5, 65000, 1000, 60, '12:00'),
(4, 'Manufacturing', 323000, 30, 24520000, 120000, 35, '6:00'),
(5, 'Engineering', 23000, 4, 25000, 32000, 8, '11:00');

SET IDENTITY_INSERT HR.Division ON;

MERGE INTO HR.Division t
USING @Division s
ON t.DivisionKey = s.DivisionKey
WHEN NOT MATCHED THEN
    INSERT
    (
        DivisionKey,
        DivisionName,
        CreatedByEmployeeKey,
        ModifiedByEmployeeKey,
        SalaryBudget,
        FteBudget,
        SuppliesBudget,
        FloorSpaceBudget,
        MaxEmployees,
        LastReviewCycle,
        StartTime
    )
    VALUES
    (s.DivisionKey, s.DivisionName, s.CreatedByEmployeeKey, s.ModifiedByEmployeeKey, s.SalaryBudget, s.FteBudget,
     s.SuppliesBudget, s.FloorSpaceBudget, s.MaxEmployees, s.LastReviewCycle, s.StartTime)
WHEN MATCHED THEN
    UPDATE SET t.DivisionName = s.DivisionName,
               t.ModifiedByEmployeeKey = s.ModifiedByEmployeeKey,
               t.SalaryBudget = s.SalaryBudget,
               t.FteBudget = s.FteBudget,
               t.SuppliesBudget = s.SuppliesBudget,
               t.FloorSpaceBudget = s.FloorSpaceBudget,
               t.ModifiedDate = SYSUTCDATETIME(),
               MaxEmployees = s.MaxEmployees,
               LastReviewCycle = s.LastReviewCycle,
               StartTime = s.StartTime
WHEN NOT MATCHED BY SOURCE AND t.DivisionKey < 1000 THEN
    DELETE;


SET IDENTITY_INSERT HR.Division OFF;


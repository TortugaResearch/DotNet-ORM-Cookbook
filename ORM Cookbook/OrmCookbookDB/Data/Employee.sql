GO
DECLARE @Employee TABLE
(
    EmployeeKey INT NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50) NULL,
    LastName NVARCHAR(50) NOT NULL,
    Title NVARCHAR(100) NULL,
    OfficePhone VARCHAR(15) NULL,
    CellPhone VARCHAR(15) NULL,
    EmployeeClassificationKey INT NOT NULL
);

INSERT INTO @Employee
(
    EmployeeKey,
    FirstName,
    MiddleName,
    LastName,
    Title,
    OfficePhone,
    CellPhone,
    EmployeeClassificationKey
)
VALUES
(1, 'John', NULL, 'Doe', NULL, NULL, NULL, 1),
(2, 'Jane', NULL, 'Doe', NULL, NULL, NULL, 2),
(3, 'Tom', NULL, 'Jones', NULL, NULL, NULL, 3);





SET IDENTITY_INSERT HR.Employee ON;

MERGE INTO HR.Employee t
USING @Employee s
ON t.EmployeeKey = s.EmployeeKey
WHEN NOT MATCHED THEN
    INSERT
    (
        EmployeeKey,
        FirstName,
        MiddleName,
        LastName,
        Title,
        OfficePhone,
        CellPhone,
        EmployeeClassificationKey
    )
    VALUES
    (s.EmployeeKey, s.FirstName, s.MiddleName, s.LastName, s.Title, s.OfficePhone, s.CellPhone,
     s.EmployeeClassificationKey)
WHEN MATCHED THEN
    UPDATE SET t.FirstName = s.FirstName,
               t.MiddleName = s.MiddleName,
               t.LastName = s.LastName,
               t.Title = s.Title,
               t.OfficePhone = s.OfficePhone,
               t.CellPhone = s.CellPhone,
               t.EmployeeClassificationKey = s.EmployeeClassificationKey
WHEN NOT MATCHED BY SOURCE AND t.EmployeeKey < 1000 THEN
    DELETE;


SET IDENTITY_INSERT HR.Employee OFF;


GO


DECLARE	@EmployeeClassification TABLE
(
 EmployeeClassificationKey INT NOT NULL,
 EmployeeClassificationName VARCHAR(30) NOT NULL,
 IsExempt BIT NOT NULL,
 IsEmployee BIT NOT NULL
);

INSERT	INTO @EmployeeClassification
		(EmployeeClassificationKey, EmployeeClassificationName, IsExempt, IsEmployee)
VALUES	(1, 'Full Time Salary', 1, 1),
		(2, 'Full Time Wage', 0, 1),
		(3, 'Part Time Wage', 0, 1),
		(4, 'Contractor', 0, 0),
		(5, 'Paid Intern', 0, 1),
		(6, 'Unpaid Intern', 1, 1);




SET IDENTITY_INSERT HR.EmployeeClassification ON;

MERGE INTO HR.EmployeeClassification t
USING @EmployeeClassification s
ON t.EmployeeClassificationKey = s.EmployeeClassificationKey
WHEN NOT MATCHED THEN
	INSERT (EmployeeClassificationKey,
			EmployeeClassificationName,
			IsExempt, IsEmployee
		   )
	VALUES (s.EmployeeClassificationKey,
			s.EmployeeClassificationName,
			s.IsExempt, s.IsEmployee
		   )
WHEN MATCHED THEN
	UPDATE SET t.EmployeeClassificationName = s.EmployeeClassificationName, t.IsExempt=s.IsExempt, t.IsEmployee = s.IsEmployee
WHEN NOT MATCHED BY SOURCE AND t.EmployeeClassificationKey < 1000 THEN
	DELETE;


SET IDENTITY_INSERT HR.EmployeeClassification OFF;


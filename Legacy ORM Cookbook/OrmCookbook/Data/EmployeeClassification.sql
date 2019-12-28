GO


DECLARE	@EmployeeClassification TABLE
(
 EmployeeClassificationKey INT NOT NULL,
 EmployeeClassificationName VARCHAR(30)
);

INSERT	INTO @EmployeeClassification
		(EmployeeClassificationKey, EmployeeClassificationName)
VALUES	(1, 'Full Time Salary'),
		(2, 'Full Time Wage'),
		(3, 'Part Time Wage'),
		(4, 'Contractor'),
		(5, 'Paid Intern'),
		(6, 'Unpaid Intern');




SET IDENTITY_INSERT HR.EmployeeClassification ON;

MERGE INTO HR.EmployeeClassification t
USING @EmployeeClassification s
ON t.EmployeeClassificationKey = s.EmployeeClassificationKey
WHEN NOT MATCHED THEN
	INSERT (EmployeeClassificationKey,
			EmployeeClassificationName
		   )
	VALUES (s.EmployeeClassificationKey,
			s.EmployeeClassificationName
		   )
WHEN MATCHED THEN
	UPDATE SET t.EmployeeClassificationName = s.EmployeeClassificationName
WHEN NOT MATCHED BY SOURCE AND t.EmployeeClassificationKey < 1000 THEN
	DELETE;


SET IDENTITY_INSERT HR.EmployeeClassification OFF;


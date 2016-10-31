GO

DECLARE	@Division TABLE
(
 DivisionKey INT NOT NULL
				 PRIMARY KEY,
 DivisionName NVARCHAR(30) NOT NULL
);


INSERT	INTO @Division
		(DivisionKey, DivisionName)
VALUES	(1, 'HR'),
		(2, 'Accounting'),
		(3, 'Sales'),
		(4, 'Manufactoring'),
		(5, 'Engineering');

SET IDENTITY_INSERT HR.Division ON;

MERGE INTO HR.Division t
USING @Division s
ON t.DivisionKey = s.DivisionKey
WHEN NOT MATCHED THEN
	INSERT (DivisionKey,
			DivisionName
		   )
	VALUES (s.DivisionKey,
			s.DivisionName
		   )
WHEN MATCHED THEN
	UPDATE SET t.DivisionName = s.DivisionName
WHEN NOT MATCHED BY SOURCE AND t.DivisionKey < 1000 THEN
	DELETE;


SET IDENTITY_INSERT HR.Division OFF;


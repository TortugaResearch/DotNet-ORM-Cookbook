CREATE VIEW HR.DepartmentDetail
AS
	SELECT	d.DepartmentKey,
			d.DepartmentName,
			d.DivisionKey,
			d2.DivisionName
	FROM	HR.Department d
	LEFT JOIN HR.Division d2 ON d2.DivisionKey = d.DivisionKey;

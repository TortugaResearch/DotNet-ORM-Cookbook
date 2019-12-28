CREATE TABLE HR.Department
(
 DepartmentKey INT NOT NULL
				   IDENTITY(1000, 1)
				   CONSTRAINT PK_Department PRIMARY KEY,
 DepartmentName NVARCHAR(30) NOT NULL
							 CONSTRAINT UX_Department_DepartmentName UNIQUE,
 DivisionKey INT NOT NULL
				 CONSTRAINT FK_Department_DivisionKey REFERENCES HR.Division (DivisionKey)
);

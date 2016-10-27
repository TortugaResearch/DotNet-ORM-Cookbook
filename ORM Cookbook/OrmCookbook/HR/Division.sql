CREATE TABLE HR.Division
(
 DivisionKey INT NOT NULL
				 IDENTITY
				 CONSTRAINT PK_Division PRIMARY KEY,
 DivisionName NVARCHAR(30) NOT NULL
						   CONSTRAINT UX_Division_DivisionName UNIQUE
);

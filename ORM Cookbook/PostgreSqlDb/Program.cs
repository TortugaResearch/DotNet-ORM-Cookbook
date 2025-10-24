using Microsoft.Extensions.Configuration;
using Npgsql;

namespace PostgreSqlDb;

class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
        var postgreSqlConnectionString = configuration.GetSection("ConnectionStrings")["PostgreSqlTestDatabase"];

        using (var con = new NpgsqlConnection(postgreSqlConnectionString))
        {
            con.Open();

            Execute("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");
            Execute("DROP SCHEMA IF Exists Sales Cascade;");
            Execute("DROP SCHEMA IF Exists HR Cascade;");
            Execute("DROP SCHEMA IF Exists Production Cascade;");

            Execute("CREATE SCHEMA HR;");
            Execute("CREATE SCHEMA Production;");
            Execute("CREATE SCHEMA Sales;");

            Execute(@"CREATE TABLE HR.EmployeeClassification
(
    EmployeeClassificationKey INT NOT NULL GENERATED ALWAYS AS IDENTITY(START 1000)
        CONSTRAINT PK_EmployeeClassification PRIMARY KEY,
    EmployeeClassificationName VARCHAR(30) NOT NULL
        CONSTRAINT UX_EmployeeClassification_EmployeeClassificationName
        UNIQUE,
    IsExempt BOOLEAN NOT NULL
        CONSTRAINT D_EmployeeClassification_IsExempt
            DEFAULT(false),
    IsEmployee BOOLEAN NOT NULL
        CONSTRAINT D_EmployeeClassification_IsEmployee
            DEFAULT(true)
);");

            Execute(@"CREATE TABLE HR.Employee
(
    EmployeeKey INT NOT NULL GENERATED ALWAYS AS IDENTITY(START 1000)
        CONSTRAINT PK_Employee PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NULL,
    LastName VARCHAR(50) NOT NULL,
    Title VARCHAR(100) NULL,
    OfficePhone VARCHAR(15) NULL,
    CellPhone VARCHAR(15) NULL,
    EmployeeClassificationKey INT NOT NULL
        CONSTRAINT FK_Employee_EmployeeClassificationKey
        REFERENCES HR.EmployeeClassification (EmployeeClassificationKey)
);");

            Execute(@"CREATE TABLE HR.Division
(
    DivisionKey INT NOT NULL GENERATED ALWAYS AS IDENTITY(START 1000)
        CONSTRAINT PK_Division PRIMARY KEY,
    DivisionId CHAR(36) NOT NULL
        CONSTRAINT D_Division_DivisionId
            DEFAULT (uuid_generate_v4()),
    DivisionName VARCHAR(30) NOT NULL
        CONSTRAINT UX_Division_DivisionName
        UNIQUE,
    CreatedDate TIMESTAMP(6) NOT NULL
        CONSTRAINT D_Division_CreatedDate
            DEFAULT (now() at time zone 'utc'),
    ModifiedDate TIMESTAMP(6) NOT NULL
        CONSTRAINT D_Division_ModifiedDate
            DEFAULT (now() at time zone 'utc'),
    CreatedByEmployeeKey INT NOT NULL
        CONSTRAINT FK_Division_CreatedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    ModifiedByEmployeeKey INT NOT NULL
        CONSTRAINT FK_Division_ModifiedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    SalaryBudget DECIMAL(14, 4) NULL,
    FteBudget NUMERIC(5, 1) NULL,
    SuppliesBudget DECIMAL(14, 4) NULL,
    FloorSpaceBudget FLOAT(24) NULL,
    MaxEmployees INT NULL,
    LastReviewCycle TIMESTAMP(6) WITH TIME ZONE NULL,
    StartTime TIME NULL
);");

            Execute(@"CREATE TABLE HR.Department
(
    DepartmentKey INT NOT NULL GENERATED ALWAYS AS IDENTITY(START 1000)
        CONSTRAINT PK_Department PRIMARY KEY,
    DepartmentName VARCHAR(30) NOT NULL
        CONSTRAINT UX_Department_DepartmentName
        UNIQUE,
    DivisionKey INT NOT NULL
        CONSTRAINT FK_Department_DivisionKey
        REFERENCES HR.Division (DivisionKey),
    CreatedDate  TIMESTAMP(6) NULL,
    ModifiedDate TIMESTAMP(6) NULL,
    CreatedByEmployeeKey INT NULL
        CONSTRAINT FK_Department_CreatedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    ModifiedByEmployeeKey INT NULL
        CONSTRAINT FK_Department_ModifiedByEmployeeKey
        REFERENCES HR.Employee (EmployeeKey),
    IsDeleted BOOLEAN NOT NULL
        CONSTRAINT D_Department_IsDeleted
            DEFAULT (false)
);");

            Execute(@"CREATE VIEW HR.DepartmentDetail
AS
	SELECT	d.DepartmentKey,
			d.DepartmentName,
			d.DivisionKey,
			d2.DivisionName
	FROM	HR.Department d
	LEFT JOIN HR.Division d2 ON d2.DivisionKey = d.DivisionKey;
");

            Execute(@"CREATE VIEW HR.EmployeeDetail
AS
SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey,
       ec.EmployeeClassificationName,
       ec.IsExempt,
       ec.IsEmployee
FROM HR.Employee e
    INNER JOIN HR.EmployeeClassification ec
        ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey;
");

            Execute(@"CREATE TABLE Production.ProductLine
(
    ProductLineKey INT NOT NULL GENERATED ALWAYS AS IDENTITY(START 1000)
        CONSTRAINT PK_ProductLine PRIMARY KEY,
    ProductLineName VARCHAR(50) NOT NULL
        CONSTRAINT UX_ProductLine_ProductLineName
        UNIQUE
);");
            Execute(@"CREATE TABLE Production.Product
(
    ProductKey INT NOT NULL GENERATED ALWAYS AS IDENTITY(START 1000)
        CONSTRAINT PK_Product PRIMARY KEY,
    ProductName VARCHAR(50) NOT NULL,
    ProductLineKey INT NOT NULL
        CONSTRAINT FK_Product_ProductLineKey
        REFERENCES Production.ProductLine (ProductLineKey),
    ShippingWeight NUMERIC(10, 4) NULL,
    ProductWeight NUMERIC(10, 4) NULL,
    CONSTRAINT C_Product_Weight CHECK (ShippingWeight IS NULL
                                       OR ProductWeight IS NULL
                                       OR ShippingWeight >= ProductWeight
                                      )
);");
            Execute(@"INSERT	INTO HR.EmployeeClassification
		(EmployeeClassificationKey, EmployeeClassificationName, IsExempt, IsEmployee)
		OVERRIDING SYSTEM VALUE
VALUES	(1, 'Full Time Salary', true, true),
		(2, 'Full Time Wage', false, true),
		(3, 'Part Time Wage', false, true),
		(4, 'Contractor', false, false),
		(5, 'Paid Intern', false, true),
		(6, 'Unpaid Intern', true, true),
		(7, 'Consultant', true, false);");

            Execute(@"INSERT INTO hr.Employee
(
    EmployeeKey,
    FirstName,
    MiddleName,
    LastName,
    Title,
    OfficePhone,
    CellPhone,
    EmployeeClassificationKey
) OVERRIDING SYSTEM VALUE
VALUES
(1, 'John', NULL, 'Doe', NULL, NULL, NULL, 1),
(2, 'Jane', NULL, 'Doe', NULL, NULL, NULL, 2),
(3, 'Tom', NULL, 'Jones', NULL, NULL, NULL, 3),
(4, 'Chuck', NULL, 'Jones', NULL, NULL, NULL, 4);");

            Execute(@"INSERT INTO HR.Division
(
    DivisionKey,
    DivisionName,
    SalaryBudget,
    FteBudget,
    SuppliesBudget,
    FloorSpaceBudget,
    MaxEmployees,
    StartTime,
	CreatedByEmployeeKey,
	ModifiedByEmployeeKey
) OVERRIDING SYSTEM VALUE
VALUES
(1, 'HR', 875000, 10.5, 20000, 12000, 15, '9:00', 1, 1),
(2, 'Accounting', null, null, null, null, null, null, 1, 1),
(3, 'Sales', 2312000, 40.5, 65000, 1000, 60, '12:00', 1, 1),
(4, 'Manufacturing', 323000, 30, 24520000, 120000, 35, '6:00', 1, 1),
(5, 'Engineering', 23000, 4, 25000, 32000, 8, '11:00', 1, 1);
");

            /************************/
            void Execute(string sql)
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, con))
                    cmd.ExecuteNonQuery();
            }
        }
    }
}
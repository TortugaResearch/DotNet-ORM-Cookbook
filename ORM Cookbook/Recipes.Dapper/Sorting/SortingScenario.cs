using Dapper;
using Microsoft.Data.SqlClient;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Dapper.Sorting
{
    public class SortingScenario : ISortingScenario<EmployeeSimple>
    {
        readonly string m_ConnectionString;

        public SortingScenario(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            const string sql = @"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey
VALUES
(@FirstName, @MiddleName, @LastName, @Title, @OfficePhone, @CellPhone, @EmployeeClassificationKey);";

            using (var con = OpenConnection())
                return con.ExecuteScalar<int>(sql, employee);
        }

        public IList<EmployeeSimple> SortByLastName()
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e ORDER BY e.LastName";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql).ToList();
        }

        public IList<EmployeeSimple> SortByLastNameDescFirstName()
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e ORDER BY e.LastName DESC, e.FirstName";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql).ToList();
        }

        public IList<EmployeeSimple> SortByLastNameFirstName()
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e ORDER BY e.LastName, e.FirstName";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql).ToList();
        }

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        SqlConnection OpenConnection()
        {
            var con = new SqlConnection(m_ConnectionString);
            con.Open();
            return con;
        }
    }
}

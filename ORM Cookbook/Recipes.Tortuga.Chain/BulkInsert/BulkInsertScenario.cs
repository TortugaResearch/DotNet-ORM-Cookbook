using Recipes.BulkInsert;
using Recipes.Chain.Models;
using System.Collections.Generic;
using System.Data;
using Tortuga.Chain;

namespace Recipes.Chain.BulkInsert
{
    public class BulkInsertScenario : IBulkInsertScenario<EmployeeSimple>
    {
        const string EmployeeTableName = "HR.Employee";
        readonly SqlServerDataSource m_DataSource;

        public BulkInsertScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public void BulkInsert(IList<EmployeeSimple> employees)
        {
            m_DataSource.InsertBulk(employees).Execute();
        }

        public void BulkInsert(DataTable employees)
        {
            m_DataSource.InsertBulk(EmployeeTableName, employees).Execute();
        }

        public int CountByLastName(string lastName)
        {
            return (int)m_DataSource.From<EmployeeSimple>(new { lastName }).AsCount().Execute();
        }
    }
}

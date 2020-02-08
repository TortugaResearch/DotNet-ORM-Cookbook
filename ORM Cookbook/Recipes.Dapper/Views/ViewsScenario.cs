using Dapper;
using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;
using Recipes.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Dapper.Views
{
    public class ViewsScenario : ScenarioBase, IViewsScenario<EmployeeDetail, EmployeeSimple>
    {
        public ViewsScenario(string connectionString) : base(connectionString)
        {
        }

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var con = OpenConnection())
                return (int)con.Insert(employee);
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            const string sql = "SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.EmployeeClassificationKey = @EmployeeClassificationKey";

            using (var con = OpenConnection())
                return con.Query<EmployeeDetail>(sql, new { employeeClassificationKey }).ToList();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            const string sql = "SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.LastName = @LastName";

            using (var con = OpenConnection())
                return con.Query<EmployeeDetail>(sql, new { lastName }).ToList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            const string sql = "SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.EmployeeKey = @EmployeeKey";

            using (var con = OpenConnection())
                return con.QuerySingleOrDefault<EmployeeDetail>(sql, new { employeeKey });
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            const string sql = "SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE EmployeeClassificationKey = @EmployeeClassificationKey";

            using (var con = OpenConnection())
                return con.QuerySingleOrDefault<EmployeeClassification>(sql, new { employeeClassificationKey });
        }
    }
}

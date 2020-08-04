using Recipes.Xpo.Entities;
using Recipes.RowCount;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;

namespace Recipes.Xpo.RowCount
{
    public class RowCountScenario : IRowCountScenario<Employee>
    {
        public int EmployeeCount(string lastName)
        {
            using (var uow = new UnitOfWork())
                // This approach works slower, because it loads matching objects from a data source:
                //return uow.Query<Employee>().Where(e => e.LastName == lastName).Count();

                // Get row count without loading data items from the server.
                return (int)uow.Evaluate(typeof(Employee), CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("[LastName] = ?", lastName));
        }

        public int EmployeeCount()
        {
            using (var uow = new UnitOfWork())
                // This approach works slower, because it loads all the objects from a data source:
                // return uow.Query<Employee>().Count();

                // Get row count without loading data items from the server.
                return (int)uow.Evaluate(typeof(Employee), CriteriaOperator.Parse("Count()"), null);
        }

        public void InsertBatch(IList<Employee> employees)
        {
            Session.DefaultSession.Save(employees);
        }
    }
}

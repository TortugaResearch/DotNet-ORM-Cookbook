using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.Linq;
using LLBLGenPro.OrmCookbook.TypedListClasses;
using Recipes.Joins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LLBLGenPro.Joins
{
    public class JoinsScenarioTypedList : IJoinsScenario<EmployeeJoinedRow, EmployeeEntity>
    {
        public int Create(EmployeeEntity employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                adapter.SaveEntity(employee);
                return employee.EmployeeKey;
            }
        }

        public IList<EmployeeJoinedRow> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                var q = metaData.GetEmployeeJoinedTypedList()
                                .Where(ec => ec.EmployeeClassificationKey == employeeClassificationKey);
                return q.ToList();
            }
        }

        public IList<EmployeeJoinedRow> FindByLastName(string lastName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                var q = metaData.GetEmployeeJoinedTypedList()
                                .Where(ec => ec.LastName == lastName);
                return q.ToList();
            }
        }

        public EmployeeJoinedRow? GetByEmployeeKey(int employeeKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).GetEmployeeJoinedTypedList().SingleOrDefault(e => e.EmployeeKey == employeeKey);
            }
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).EmployeeClassification.FirstOrDefault(ec => ec.EmployeeClassificationKey == employeeClassificationKey);
            }
        }
    }
}

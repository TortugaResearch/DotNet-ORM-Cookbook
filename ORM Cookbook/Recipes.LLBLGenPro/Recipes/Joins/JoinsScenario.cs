using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.Joins;
using SD.LLBLGen.Pro.QuerySpec;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LLBLGenPro.Joins
{
    public class JoinsScenario : IJoinsScenario<EmployeeDetailEntity, EmployeeEntity>
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

        public IList<EmployeeDetailEntity> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                var q = from e in metaData.Employee
                        join ec in metaData.EmployeeClassification on e.EmployeeClassificationKey equals ec.EmployeeClassificationKey
                        where ec.EmployeeClassificationKey == employeeClassificationKey
                        select new EmployeeDetailEntity()
                        {
                            EmployeeKey = e.EmployeeKey,
                            FirstName = e.FirstName,
                            MiddleName = e.MiddleName,
                            LastName = e.LastName,
                            CellPhone = e.CellPhone,
                            OfficePhone = e.OfficePhone,
                            Title = e.Title,
                            EmployeeClassificationKey = ec.EmployeeClassificationKey,
                            EmployeeClassificationName = ec.EmployeeClassificationName,
                            IsEmployee = ec.IsEmployee,
                            IsExempt = ec.IsExempt,
                        };
                return q.ToList();
            }
        }

        public IList<EmployeeDetailEntity> FindByLastName(string lastName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                var q = from e in metaData.Employee
                        join ec in metaData.EmployeeClassification on e.EmployeeClassificationKey equals ec.EmployeeClassificationKey
                        where e.LastName == lastName
                        select new EmployeeDetailEntity()
                        {
                            EmployeeKey = e.EmployeeKey,
                            FirstName = e.FirstName,
                            MiddleName = e.MiddleName,
                            LastName = e.LastName,
                            CellPhone = e.CellPhone,
                            OfficePhone = e.OfficePhone,
                            Title = e.Title,
                            EmployeeClassificationKey = ec.EmployeeClassificationKey,
                            EmployeeClassificationName = ec.EmployeeClassificationName,
                            IsEmployee = ec.IsEmployee,
                            IsExempt = ec.IsExempt,
                        };
                return q.ToList();
            }
        }

        public EmployeeDetailEntity? GetByEmployeeKey(int employeeKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                var q = from e in metaData.Employee
                        join ec in metaData.EmployeeClassification on e.EmployeeClassificationKey equals ec.EmployeeClassificationKey
                        where e.EmployeeKey == employeeKey
                        select new EmployeeDetailEntity()
                        {
                            EmployeeKey = e.EmployeeKey,
                            FirstName = e.FirstName,
                            MiddleName = e.MiddleName,
                            LastName = e.LastName,
                            CellPhone = e.CellPhone,
                            OfficePhone = e.OfficePhone,
                            Title = e.Title,
                            EmployeeClassificationKey = ec.EmployeeClassificationKey,
                            EmployeeClassificationName = ec.EmployeeClassificationName,
                            IsEmployee = ec.IsEmployee,
                            IsExempt = ec.IsExempt,
                        };
                return q.SingleOrDefault();
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

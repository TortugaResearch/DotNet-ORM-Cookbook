using LinqToDB;
using Recipes.Joins;
using Recipes.LinqToDB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipes.LinqToDB.Joins
{
    public class JoinsScenario : IJoinsScenario<EmployeeDetail, Employee>
    {
        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var db = new OrmCookbook())
            {
                return db.InsertWithInt32Identity(employee);
            }
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
                return db.Employee
                    .Join(db.EmployeeClassification,
                        e => e.EmployeeClassificationKey,
                        ec => ec.EmployeeClassificationKey,
                        (e, ec) => new EmployeeDetail()
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
                        })
                    .Where(ed => ed.EmployeeClassificationKey == employeeClassificationKey)
                    .ToList();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.Employee
                    .Join(db.EmployeeClassification,
                        e => e.EmployeeClassificationKey,
                        ec => ec.EmployeeClassificationKey,
                        (e, ec) => new EmployeeDetail()
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
                        })
                    .Where(ed => ed.LastName == lastName)
                    .ToList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            using (var db = new OrmCookbook())
                return db.Employee
                    .Join(db.EmployeeClassification,
                        e => e.EmployeeClassificationKey,
                        ec => ec.EmployeeClassificationKey,
                        (e, ec) => new EmployeeDetail()
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
                        })
                    .Where(x => x.EmployeeKey == employeeKey).SingleOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
                return db.EmployeeClassification.Where(x => x.EmployeeClassificationKey == employeeClassificationKey).SingleOrDefault();
        }
    }
}

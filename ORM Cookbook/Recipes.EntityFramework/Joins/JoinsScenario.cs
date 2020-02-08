using Recipes.EntityFramework.Entities;
using Recipes.Joins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipes.EntityFramework.Joins
{
    public class JoinsScenario : IJoinsScenario<EmployeeDetail, Employee>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public JoinsScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var context = CreateDbContext())
            {
                context.Employee.Add(employee);
                context.SaveChanges();
                return employee.EmployeeKey;
            }
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
                return context.Employee
                    .Join(context.EmployeeClassification,
                        e => e.EmployeeClassificationKey,
                        ec => ec.EmployeeClassificationKey,
                        (e, ec) => new { e, ec })
                        .Where(ed => ed.ec.EmployeeClassificationKey == employeeClassificationKey)
                        .ToList() //everything below this line is client-side
                        .Select(ed => new EmployeeDetail()
                        {
                            EmployeeKey = ed.e.EmployeeKey,
                            FirstName = ed.e.FirstName,
                            MiddleName = ed.e.MiddleName,
                            LastName = ed.e.LastName,
                            CellPhone = ed.e.CellPhone,
                            OfficePhone = ed.e.OfficePhone,
                            Title = ed.e.Title,
                            EmployeeClassificationKey = ed.ec.EmployeeClassificationKey,
                            EmployeeClassificationName = ed.ec.EmployeeClassificationName,
                            IsEmployee = ed.ec.IsEmployee,
                            IsExempt = ed.ec.IsExempt,
                        })
                        .ToList();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var context = CreateDbContext())
                return context.Employee
                    .Join(context.EmployeeClassification,
                        e => e.EmployeeClassificationKey,
                        ec => ec.EmployeeClassificationKey,
                        (e, ec) => new { e, ec })
                    .Where(ed => ed.e.LastName == lastName)
                    .ToList() //everything below this line is client-side
                    .Select(ed => new EmployeeDetail()
                    {
                        EmployeeKey = ed.e.EmployeeKey,
                        FirstName = ed.e.FirstName,
                        MiddleName = ed.e.MiddleName,
                        LastName = ed.e.LastName,
                        CellPhone = ed.e.CellPhone,
                        OfficePhone = ed.e.OfficePhone,
                        Title = ed.e.Title,
                        EmployeeClassificationKey = ed.ec.EmployeeClassificationKey,
                        EmployeeClassificationName = ed.ec.EmployeeClassificationName,
                        IsEmployee = ed.ec.IsEmployee,
                        IsExempt = ed.ec.IsExempt,
                    })
                    .ToList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            using (var context = CreateDbContext())
                return context.Employee
                    .Join(context.EmployeeClassification,
                        e => e.EmployeeClassificationKey,
                        ec => ec.EmployeeClassificationKey,
                        (e, ec) => new { e, ec })
                    .Where(ed => ed.e.EmployeeKey == employeeKey)
                    .ToList() //everything below this line is client-side
                    .Select(ed => new EmployeeDetail()
                    {
                        EmployeeKey = ed.e.EmployeeKey,
                        FirstName = ed.e.FirstName,
                        MiddleName = ed.e.MiddleName,
                        LastName = ed.e.LastName,
                        CellPhone = ed.e.CellPhone,
                        OfficePhone = ed.e.OfficePhone,
                        Title = ed.e.Title,
                        EmployeeClassificationKey = ed.ec.EmployeeClassificationKey,
                        EmployeeClassificationName = ed.ec.EmployeeClassificationName,
                        IsEmployee = ed.ec.IsEmployee,
                        IsExempt = ed.ec.IsExempt,
                    })
                    .SingleOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
                return context.EmployeeClassification.Find(employeeClassificationKey);
        }
    }
}

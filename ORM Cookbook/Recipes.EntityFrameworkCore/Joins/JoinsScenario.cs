using Recipes.EntityFrameworkCore.Entities;
using Recipes.Joins;
using System.Data;

namespace Recipes.EntityFrameworkCore.Joins;

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
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee.EmployeeKey;
        }
    }

    public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
    {
        using (var context = CreateDbContext())
            return context.Employees
                .Join(context.EmployeeClassifications,
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
                        IsEmployee = ec.IsEmployee ?? true,
                        IsExempt = ec.IsExempt,
                    })
                .Where(ed => ed.EmployeeClassificationKey == employeeClassificationKey)
                .ToList();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        using (var context = CreateDbContext())
            return context.Employees
                .Join(context.EmployeeClassifications,
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
                        IsEmployee = ec.IsEmployee ?? true,
                        IsExempt = ec.IsExempt,
                    })
                .Where(ed => ed.LastName == lastName)
                .ToList();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        using (var context = CreateDbContext())
            return context.Employees
                .Join(context.EmployeeClassifications,
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
                        IsEmployee = ec.IsEmployee ?? true,
                        IsExempt = ec.IsExempt,
                    })
                .Where(x => x.EmployeeKey == employeeKey).SingleOrDefault();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        using (var context = CreateDbContext())
            return context.EmployeeClassifications.Find(employeeClassificationKey);
    }
}
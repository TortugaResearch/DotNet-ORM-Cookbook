using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.ModelWithLookup;

namespace Recipes.EntityFrameworkCore.ModelWithLookup;

public class ModelWithLookupSimpleScenario : IModelWithLookupSimpleScenario<Employee>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public ModelWithLookupSimpleScenario(Func<OrmCookbookContext> dBContextFactory)
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

    public void Delete(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using (var context = CreateDbContext())
        {
            context.Entry(employee).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public void DeleteByKey(int employeeKey)
    {
        using (var context = CreateDbContext())
        {
            //Find the row you wish to delete
            var temp = context.Employees.Find(employeeKey);
            if (temp != null)
            {
                context.Employees.Remove(temp);
                context.SaveChanges();
            }
        }
    }

    public IList<Employee> FindByLastName(string lastName)
    {
        using (var context = CreateDbContext())
            return context.Employees.Where(ec => ec.LastName == lastName).ToList();
    }

    public IList<Employee> GetAll()
    {
        using (var context = CreateDbContext())
            return context.Employees.ToList();
    }

    public Employee? GetByKey(int employeeKey)
    {
        using (var context = CreateDbContext())
            return context.Employees.Find(employeeKey);
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        using (var context = CreateDbContext())
            return context.EmployeeClassifications.Find(employeeClassificationKey);
    }

    /// <summary>
    /// Updates the specified employee.
    /// </summary>
    /// <param name="employee">The employee.</param>
    /// <exception cref="ArgumentNullException">employee</exception>
    public void Update(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using (var context = CreateDbContext())
        {
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
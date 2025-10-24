using Recipes.EntityFramework.Entities;
using Recipes.Views;
using System.Data;

namespace Recipes.EntityFramework.Views;

public class ViewsScenario : IViewsScenario<EmployeeDetail, Employee>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public ViewsScenario(Func<OrmCookbookContext> dBContextFactory)
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
            return context.EmployeeDetail.Where(x => x.EmployeeClassificationKey == employeeClassificationKey).ToList();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        using (var context = CreateDbContext())
            return context.EmployeeDetail.Where(x => x.LastName == lastName).ToList();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        using (var context = CreateDbContext())
            return context.EmployeeDetail.Where(x => x.EmployeeKey == employeeKey).SingleOrDefault();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        using (var context = CreateDbContext())
            return context.EmployeeClassification.Find(employeeClassificationKey);
    }
}
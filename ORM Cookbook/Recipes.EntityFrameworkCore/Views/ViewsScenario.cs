using Recipes.EntityFrameworkCore.Entities;
using Recipes.Views;
using System.Data;

namespace Recipes.EntityFrameworkCore.Views
{
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
                context.Employees.Add(employee);
                context.SaveChanges();
                return employee.EmployeeKey;
            }
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
                return context.EmployeeDetails.Where(x => x.EmployeeClassificationKey == employeeClassificationKey).ToList();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var context = CreateDbContext())
                return context.EmployeeDetails.Where(x => x.LastName == lastName).ToList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            using (var context = CreateDbContext())
                return context.EmployeeDetails.Where(x => x.EmployeeKey == employeeKey).SingleOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
                return context.EmployeeClassifications.Find(employeeClassificationKey);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Recipes.BasicStoredProc;
using Recipes.EntityFrameworkCore.Entities;

namespace Recipes.EntityFrameworkCore.BasicStoredProc;

public class BasicStoredProcScenario :
    IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
{
    private Func<OrmCookbookContext> CreateDbContext;

    public BasicStoredProcScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
    {
        using (var context = CreateDbContext())
            return context.EmployeeClassificationWithCount
                .FromSqlRaw("EXEC HR.CountEmployeesByClassification;").ToList();
    }

    public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
    {
        if (employeeClassification == null)
            throw new ArgumentNullException(nameof(employeeClassification),
                $"{nameof(employeeClassification)} is null.");

        //Notes:
        //EF Core cannot return scalar values from stored procedures. A holder class is needed to receive the
        //results.
        //Named parameters are not supported, so parameter order is important.
        using (var context = CreateDbContext())
        {
            var temp = context.EmployeeClassificationKeyHolder
                  .FromSqlRaw("EXEC HR.CreateEmployeeClassification {0}, {1}, {2};",
                      employeeClassification.EmployeeClassificationName,
                      employeeClassification.IsExempt,
                      employeeClassification.IsEmployee
                  ).ToList();

            //Single isn't allowed for stored procedures. Thus ToList must be called first.
            return temp.Single().EmployeeClassificationKey;
        }
    }

    public IList<EmployeeClassification> GetEmployeeClassifications()
    {
        using (var context = CreateDbContext())
            return context.EmployeeClassifications.FromSqlRaw("EXEC HR.GetEmployeeClassifications;").ToList();
    }

    public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
    {
        using (var context = CreateDbContext())
        {
            var temp = context.EmployeeClassifications.FromSqlRaw("EXEC HR.GetEmployeeClassifications {0};",
                employeeClassificationKey).ToList();
            //Note that SingleOrDefault isn't allowed for stored procedures. Thus ToList must be called first.
            return temp.SingleOrDefault();
        }
    }
}
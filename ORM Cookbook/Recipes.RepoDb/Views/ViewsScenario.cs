using Microsoft.Data.SqlClient;
using Recipes.RepoDB.Models;
using Recipes.Views;
using RepoDb;
using RepoDb.Extensions;

using RDB = RepoDb;

namespace Recipes.RepoDB.Views;

public class ViewsScenario : DbRepository<SqlConnection>,
    IViewsScenario<EmployeeDetail, EmployeeSimple>
{
    public ViewsScenario(string connectionString)
        : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
    { }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        return Insert<EmployeeSimple, int>(employee);
    }

    public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
    {
        return Query<EmployeeDetail>(e => e.EmployeeClassificationKey == employeeClassificationKey).AsList();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        return Query<EmployeeDetail>(e => e.LastName == lastName).AsList();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        return Query<EmployeeDetail>(e => e.EmployeeKey == employeeKey).FirstOrDefault();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        return Query<EmployeeClassification>(employeeClassificationKey).FirstOrDefault();
    }
}
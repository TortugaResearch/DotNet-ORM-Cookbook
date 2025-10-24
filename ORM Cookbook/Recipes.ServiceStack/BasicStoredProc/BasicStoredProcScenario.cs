using Recipes.BasicStoredProc;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.BasicStoredProc;

public class BasicStoredProcScenario : IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public BasicStoredProcScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            using (var cmd = db.SqlProc("HR.CountEmployeesByClassification"))
            {
                return cmd.ConvertToList<EmployeeClassificationWithCount>();
            }
        }
    }

    public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
    {
        if (employeeClassification == null)
            throw new ArgumentNullException(nameof(employeeClassification), $"{nameof(employeeClassification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            using (var cmd = db.SqlProc("HR.CreateEmployeeClassification", new { employeeClassification.EmployeeClassificationName, employeeClassification.IsEmployee, employeeClassification.IsExempt }))
            {
                return (int)cmd.Scalar();
            }
        }
    }

    public IList<EmployeeClassification> GetEmployeeClassifications()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            using (var cmd = db.SqlProc("HR.GetEmployeeClassifications"))
            {
                return cmd.ConvertToList<EmployeeClassification>();
            }
        }
    }

    public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            using (var cmd = db.SqlProc("HR.GetEmployeeClassifications", new { EmployeeClassificationKey = employeeClassificationKey }))
            {
                return cmd.ConvertTo<EmployeeClassification>();
            }
        }
    }
}
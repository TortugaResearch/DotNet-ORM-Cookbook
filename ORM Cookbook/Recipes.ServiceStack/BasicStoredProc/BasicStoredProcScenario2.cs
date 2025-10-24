using Recipes.BasicStoredProc;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.BasicStoredProc;

public class BasicStoredProcScenario2 : IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public BasicStoredProcScenario2(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.SqlList<EmployeeClassificationWithCount>("EXEC HR.CountEmployeesByClassification");
    }

    public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
    {
        if (employeeClassification == null)
            throw new ArgumentNullException(nameof(employeeClassification), $"{nameof(employeeClassification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.SqlScalar<int>("EXEC HR.CreateEmployeeClassification @EmployeeClassificationName, @IsExempt, @IsEmployee", new { employeeClassification.EmployeeClassificationName, employeeClassification.IsExempt, employeeClassification.IsEmployee });
    }

    public IList<EmployeeClassification> GetEmployeeClassifications()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.SqlList<EmployeeClassification>("EXEC HR.GetEmployeeClassifications");
    }

    public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.SqlList<EmployeeClassification>("HR.GetEmployeeClassifications @EmployeeClassificationKey", new { employeeClassificationKey }).SingleOrDefault();
    }
}
using Recipes.ScalarValue;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.ScalarValue;

public class ScalarValueScenario : IScalarValueScenario
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ScalarValueScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public int? GetDivisionKey(string divisionName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, int?>(d => d.Id, d => d.DivisionName == divisionName);
    }

    public string GetDivisionName(int divisionKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, string>(d => d.DivisionName, d => d.Id == divisionKey);
    }

    public string? GetDivisionNameOrNull(int divisionKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, string>(d => d.DivisionName, d => d.Id == divisionKey);
    }

    public DateTimeOffset? GetLastReviewCycle(int divisionKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, DateTimeOffset?>(d => d.LastReviewCycle, d => d.Id == divisionKey);
    }

    public int? GetMaxEmployees(int divisionKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, int?>(d => d.MaxEmployees, d => d.Id == divisionKey);
    }

    public DateTime GetModifiedDate(int divisionKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, DateTime>(d => d.ModifiedDate, d => d.Id == divisionKey);
    }

    public decimal? GetSalaryBudget(int divisionKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, decimal?>(d => d.SalaryBudget, d => d.Id == divisionKey);
    }

    public TimeSpan? GetStartTime(int divisionKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Scalar<Division, TimeSpan?>(d => d.StartTime, d => d.Id == divisionKey);
    }
}
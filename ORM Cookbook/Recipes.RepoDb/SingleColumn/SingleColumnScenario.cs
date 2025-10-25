using Recipes.RepoDB.Models;
using Recipes.SingleColumn;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.SingleColumn;

public class SingleColumnScenario : ISingleColumnScenario
{
    readonly string m_ConnectionString;

    public SingleColumnScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public List<int> GetDivisionKeys(int maxDivisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.DivisionKey).ToList();
    }

    public List<string> GetDivisionNames(int maxDivisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.DivisionName!).ToList();
    }

    public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.LastReviewCycle).ToList();
    }

    public List<int?> GetMaxEmployees(int maxDivisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.MaxEmployees).ToList();
    }

    public List<DateTime> GetModifiedDates(int maxDivisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.ModifiedDate).ToList();
    }

    public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.SalaryBudget).ToList();
    }

    public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey <= maxDivisionKey).Select(d => d.StartTime).ToList();
    }
}
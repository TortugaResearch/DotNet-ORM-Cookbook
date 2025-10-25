using Recipes.RepoDB.Models;
using Recipes.Upsert;
using RepoDb;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.Upsert;

public class UpsertScenario : IUpsertScenario<Division>
{
    readonly string m_ConnectionString;

    public UpsertScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public Division? GetByKey(int divisionKey)
    {
        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.DivisionKey == divisionKey).FirstOrDefault();
    }

    public int UpsertByName(Division division)
    {
        if (division == null)
            throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Merge<int>(division, qualifiers: Field.From("DivisionName"));
    }

    public int UpsertByPrimaryKey(Division division)
    {
        if (division == null)
            throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

        using (var repository = new DivisionRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Merge<int>(division, qualifiers: Field.From("DivisionKey"));
    }
}
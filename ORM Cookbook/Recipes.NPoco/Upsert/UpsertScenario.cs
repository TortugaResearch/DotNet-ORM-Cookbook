using Recipes.NPoco.Models;
using Recipes.Upsert;

namespace Recipes.NPoco.Upsert;

public class UpsertScenario : ScenarioBase, IUpsertScenario<Division>
{
    public UpsertScenario(string connectionString) : base(connectionString)
    { }

    public Division GetByKey(int divisionKey)
    {
        throw new NotImplementedException();
    }

    public int UpsertByName(Division division)
    {
        if (division == null)
            throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

        throw new NotImplementedException();
    }

    public int UpsertByPrimaryKey(Division division)
    {
        if (division == null)
            throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

        throw new NotImplementedException();
    }
}
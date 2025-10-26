using Recipes.PopulateDataTable;
using System.Data;

namespace Recipes.PetaPoco.PopulateDataTable;

public class PopulateDataTableScenario : ScenarioBase, IPopulateDataTableScenario
{
    public PopulateDataTableScenario(string connectionString) : base(connectionString)
    {
    }

    public DataTable FindByFlags(bool isExempt, bool isEmployee)
    {
        throw new NotImplementedException();
    }

    public DataTable GetAll()
    {
        throw new NotImplementedException();
    }
}
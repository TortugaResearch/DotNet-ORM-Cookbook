using System.Data;

namespace Recipes.PopulateDataTable;

public interface IPopulateDataTableScenario

{
    /// <summary>
    /// Gets a filtered list of EmployeeClassification rows.
    /// </summary>
    DataTable FindByFlags(bool isExempt, bool isEmployee);

    /// <summary>
    /// Gets all EmployeeClassification rows.
    /// </summary>
    DataTable GetAll();
}

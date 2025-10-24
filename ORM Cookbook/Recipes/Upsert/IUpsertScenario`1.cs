namespace Recipes.Upsert;

public interface IUpsertScenario<TDivision>
   where TDivision : class, IDivision, new()
{
    /// <summary>
    /// Gets an Division row by its primary key.
    /// </summary>
    TDivision? GetByKey(int divisionKey);

    /// <summary>
    /// Performs an upsert where it looks for a matching row by DivisionName instead of the primary key.
    /// DivisionKey may be 0.
    /// </summary>
    /// <returns>The DivisionKey of the inserted or updated row</returns>
    int UpsertByName(TDivision division);

    /// <summary>
    /// Performs an upsert where a 0 for DivisionKey means an insert.
    /// </summary>
    /// <returns>The DivisionKey of the inserted or updated row</returns>
    int UpsertByPrimaryKey(TDivision division);
}

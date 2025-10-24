namespace Recipes.RowCount;

public interface IRowCountScenario<TEmployeeSimple>
   where TEmployeeSimple : class, IEmployeeSimple, new()
{
    /// <summary>
    /// Count of the employees, filtered by last name.
    /// </summary>
    /// <param name="lastName">The last name.</param>
    int EmployeeCount(string lastName);

    /// <summary>
    /// Count of the employees, filtered by last name.
    /// </summary>
    int EmployeeCount();

    /// <summary>
    /// Insert a collection of Employee rows.
    /// </summary>
    void InsertBatch(IList<TEmployeeSimple> employees);
}
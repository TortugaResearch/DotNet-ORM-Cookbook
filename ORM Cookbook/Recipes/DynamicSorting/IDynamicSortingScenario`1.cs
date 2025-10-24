namespace Recipes.DynamicSorting;

public interface IDynamicSortingScenario<TEmployeeSimple>
   where TEmployeeSimple : class, IEmployeeSimple, new()
{
    /// <summary>
    /// Insert a collection of Employee rows.
    /// </summary>
    void InsertBatch(IList<TEmployeeSimple> employees);

    /// <summary>
    /// Sorts by a single column
    /// </summary>
    /// <param name="lastName">The last name filter.</param>
    IList<TEmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending);

    /// <summary>
    /// Sorts by a multiple columns
    /// </summary>
    /// <param name="lastName">The last name filter.</param>
    IList<TEmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
        string sortByColumnB, bool isDescendingB);
}
namespace Recipes.Pagination;

public interface IPaginationScenario<TEmployeeSimple>
   where TEmployeeSimple : class, IEmployeeSimple, new()
{
    /// <summary>
    /// Insert a collection of Employee rows.
    /// </summary>
    void InsertBatch(IList<TEmployeeSimple> employees);

    /// <summary>
    /// Finds employees with a given name, paging the results.
    /// </summary>
    /// <param name="lastName">The last name.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="page">The page, numbered from zero.</param>
    /// <remarks>Sort by FirstName, EmployeeKey</remarks>
    IList<TEmployeeSimple> PaginateWithPageSize(string lastName, int page, int pageSize);

    /// <summary>
    /// Finds employees with a given name, paging the results.
    /// This version uses "keyset pagination". See https://use-the-index-luke.com/no-offset for details
    /// </summary>
    /// <param name="lastName">The last name.</param>
    /// <param name="skipPast">The last record in the previous set.</param>
    /// <param name="take">The number of rows to take.</param>
    /// <remarks>Sort by FirstName, EmployeeKey</remarks>
    IList<TEmployeeSimple> PaginateWithSkipPast(string lastName, TEmployeeSimple? skipPast, int take);

    /// <summary>
    /// Finds employees with a given name, paging the results.
    /// </summary>
    /// <param name="lastName">The last name.</param>
    /// <param name="skip">The number of rows to skip.</param>
    /// <param name="take">The number of rows to take.</param>
    /// <remarks>Sort by FirstName, EmployeeKey</remarks>
    IList<TEmployeeSimple> PaginateWithSkipTake(string lastName, int skip, int take);
}
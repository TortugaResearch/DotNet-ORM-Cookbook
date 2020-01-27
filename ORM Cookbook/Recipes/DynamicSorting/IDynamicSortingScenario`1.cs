using System.Collections.Generic;

namespace Recipes.DynamicSorting
{
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
        IList<TEmployeeSimple> SortBy(string lastName, string column, bool isDescending);

        /// <summary>
        /// Sorts by a multiple columns
        /// </summary>
        IList<TEmployeeSimple> SortBy(string lastName, string columnA, bool isDescendingA, string columnB, bool isDescendingB);
    }
}
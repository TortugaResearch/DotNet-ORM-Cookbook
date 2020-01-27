using System.Collections.Generic;

namespace Recipes.Sorting
{
    public interface ISortingScenario<TEmployeeSimple>
       where TEmployeeSimple : class, IEmployeeSimple, new()
    {
        /// <summary>
        /// Insert a collection of Employee rows.
        /// </summary>
        void InsertBatch(IList<TEmployeeSimple> employees);

        /// <summary>
        /// Sorts by the first name
        /// </summary>
        IList<TEmployeeSimple> SortByFirstName(string lastName);

        /// <summary>
        /// Sorts by the middle name in reverse order, then the first name.
        /// </summary>
        IList<TEmployeeSimple> SortByMiddleNameDescFirstName(string lastName);

        /// <summary>
        /// Sorts by the middle name, then the first name.
        /// </summary>
        IList<TEmployeeSimple> SortByMiddleNameFirstName(string lastName);
    }
}
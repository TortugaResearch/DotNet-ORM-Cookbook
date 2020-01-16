using System.Collections.Generic;

namespace Recipes.Sorting
{
    public interface ISortingScenario<TEmployee>
       where TEmployee : class, IEmployeeSimple, new()
    {
        /// <summary>
        /// Create a new Employee row, returning the new primary key.
        /// </summary>
        int Create(TEmployee employee);

        /// <summary>
        /// Sorts by the last name
        /// </summary>
        IList<TEmployee> SortByLastName();

        /// <summary>
        /// Sorts by the last name, then the first name.
        /// </summary>
        IList<TEmployee> SortByLastNameFirstName();

        /// <summary>
        /// Sorts by the last name in reverse order, then the first name.
        /// </summary>
        IList<TEmployee> SortByLastNameDescFirstName();
    }
}

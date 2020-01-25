using System.Collections.Generic;

namespace Recipes.LargeBatch
{
    public interface ILargeBatchScenario<TEmployeeSimple>
       where TEmployeeSimple : class, IEmployeeSimple, new()
    {
        /// <summary>
        /// Gets a collection of Employee rows by their name. Assume the name is not unique.
        /// </summary>
        int CountByLastName(string lastName);

        /// <summary>
        /// Insert a large collection of Employee rows.
        /// </summary>
        void InsertLargeBatch(IList<TEmployeeSimple> employees);
    }
}
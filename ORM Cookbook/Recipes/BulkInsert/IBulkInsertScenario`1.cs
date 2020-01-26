using System.Collections.Generic;
using System.Data;

namespace Recipes.BulkInsert
{
    public interface IBulkInsertScenario<TEmployeeSimple>
       where TEmployeeSimple : class, IEmployeeSimple, new()
    {
        /// <summary>
        /// Gets a collection of Employee rows by their name. Assume the name is not unique.
        /// </summary>
        int CountByLastName(string lastName);

        /// <summary>
        /// Insert a large collection of Employee rows.
        /// </summary>
        void BulkInsert(IList<TEmployeeSimple> employees);

        /// <summary>
        /// Insert a large collection of Employee rows using a DataTable.
        /// </summary>
        /// <param name="employees"></param>
        void BulkInsert(DataTable employees);
    }
}
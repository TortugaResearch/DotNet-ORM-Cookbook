using System.Collections.Generic;

namespace Recipes.MultipleCrud
{
    public interface IMultipleCrudScenario<TEmployeeSimple>
       where TEmployeeSimple : class, IEmployeeSimple, new()
    {
        /// <summary>
        /// Delete a collection of Employee rows.
        /// </summary>
        void DeleteBatch(IList<TEmployeeSimple> employees);

        /// <summary>
        /// Delete a collection of Employee rows by key.
        /// </summary>
        void DeleteBatchByKey(IList<int> employeeKeys);

        /// <summary>
        /// Gets a collection of Employee rows by their name. Assume the name is not unique.
        /// </summary>
        IList<TEmployeeSimple> FindByLastName(string lastName);

        /// <summary>
        /// Insert a collection of Employee rows.
        /// </summary>
        void InsertBatch(IList<TEmployeeSimple> employees);

        /// <summary>
        /// Insert a collection of Employee rows, returning the newly created keys.
        /// </summary>
        IList<int> InsertBatchReturnKeys(IList<TEmployeeSimple> employees);

        /// <summary>
        /// Insert a collection of Employee rows, returning the newly created rows.
        /// </summary>
        /// <remarks>This MAY return the original objects or new objects.</remarks>
        IList<TEmployeeSimple> InsertBatchReturnRows(IList<TEmployeeSimple> employees);

        /// <summary>
        /// Insert a collection of Employee rows and update the original objects with the new keys.
        /// </summary>
        void InsertBatchWithRefresh(IList<TEmployeeSimple> employees);

        /// <summary>
        /// Update a collection of Employee rows.
        /// </summary>
        void UpdateBatch(IList<TEmployeeSimple> employees);
    }
}

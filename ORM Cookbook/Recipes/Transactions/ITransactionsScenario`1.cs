using System.Data;

namespace Recipes.Transactions;

public interface ITransactionsScenario<TEmployeeClassification>
   where TEmployeeClassification : class, IEmployeeClassification, new()
{
    /// <summary>
    /// Create a new EmployeeClassification row, returning the new primary key.
    /// </summary>
    /// <param name="classification">The classification.</param>
    /// <param name="shouldRollBack">If True, the pending transaction should be rolled back.</param>
    /// <param name="isolationLevel">The isolation level.</param>
    /// <returns>System.Int32.</returns>
    int Create(TEmployeeClassification classification, bool shouldRollBack);

    /// <summary>
    /// Create a new EmployeeClassification row, returning the new primary key.
    /// </summary>
    /// <param name="classification">The classification.</param>
    /// <param name="shouldRollBack">If True, the pending transaction should be rolled back.</param>
    /// <param name="isolationLevel">The isolation level.</param>
    /// <returns>System.Int32.</returns>
    int CreateWithIsolationLevel(TEmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel);

    /// <summary>
    /// Gets an EmployeeClassification row by its primary key. If no row is found, a null is returned.
    /// </summary>
    TEmployeeClassification? GetByKey(int employeeClassificationKey);
}

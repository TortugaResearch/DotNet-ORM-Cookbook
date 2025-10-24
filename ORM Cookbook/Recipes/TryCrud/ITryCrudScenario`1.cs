namespace Recipes.TryCrud;

public interface ITryCrudScenario<TEmployeeClassification>
   where TEmployeeClassification : class, IEmployeeClassification, new()
{
    /// <summary>
    /// Create a new EmployeeClassification row, returning the new primary key.
    /// </summary>
    int Create(TEmployeeClassification classification);

    /// <summary>
    /// Delete a EmployeeClassification row using its primary key. If no matching row is found, an exception is thrown.
    /// </summary>
    /// <remarks>The specific exception thrown is not defined.</remarks>
    void DeleteByKeyOrException(int employeeClassificationKey);

    /// <summary>
    /// Delete a EmployeeClassification row using its primary key. Returns true if the row was updated, false if no matching row was found.
    /// </summary>
    bool DeleteByKeyWithStatus(int employeeClassificationKey);

    /// <summary>
    /// Delete a EmployeeClassification row using an object. If no matching row is found, an exception is thrown.
    /// </summary>
    /// <remarks>The specific exception thrown is not defined.</remarks>
    void DeleteOrException(TEmployeeClassification classification);

    /// <summary>
    /// Delete a EmployeeClassification row using an object. Returns true if the row was updated, false if no matching row was found.
    /// </summary>
    bool DeleteWithStatus(TEmployeeClassification classification);

    /// <summary>
    /// Gets an EmployeeClassification row by its name. If no row is found, an exception is thrown.
    /// </summary>
    /// <remarks>The specific exception thrown is not defined.</remarks>
    TEmployeeClassification FindByNameOrException(string employeeClassificationName);

    /// <summary>
    /// Gets an EmployeeClassification row by its name. Assume the name is unique. If no row is found, a null is returned.
    /// </summary>
    TEmployeeClassification? FindByNameOrNull(string employeeClassificationName);

    /// <summary>
    /// Gets an EmployeeClassification row by its primary key. If no row is found, an exception is thrown.
    /// </summary>
    /// <remarks>The specific exception thrown is not defined.</remarks>
    TEmployeeClassification GetByKeyOrException(int employeeClassificationKey);

    /// <summary>
    /// Gets an EmployeeClassification row by its primary key. If no row is found, a null is returned.
    /// </summary>
    TEmployeeClassification? GetByKeyOrNull(int employeeClassificationKey);

    /// <summary>
    /// Update a EmployeeClassification row. If no matching row is found, an exception is thrown.
    /// </summary>
    /// <remarks>The specific exception thrown is not defined.</remarks>
    void UpdateOrException(TEmployeeClassification classification);

    /// <summary>
    /// Update a EmployeeClassification row. Returns true if the row was updated, false if no matching row was found.
    /// </summary>
    bool UpdateWithStatus(TEmployeeClassification classification);
}

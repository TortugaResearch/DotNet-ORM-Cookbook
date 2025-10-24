namespace Recipes.SingleModelCrud;

public interface ISingleModelCrudScenario<TEmployeeClassification>
   where TEmployeeClassification : class, IEmployeeClassification, new()
{
    /// <summary>
    /// Create a new EmployeeClassification row, returning the new primary key.
    /// </summary>
    int Create(TEmployeeClassification classification);

    /// <summary>
    /// Delete a EmployeeClassification row using an object.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    void Delete(TEmployeeClassification classification);

    /// <summary>
    /// Delete a EmployeeClassification row using its primary key.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    void DeleteByKey(int employeeClassificationKey);

    /// <summary>
    /// Gets an EmployeeClassification row by its name. Assume the name is unique.
    /// </summary>
    TEmployeeClassification? FindByName(string employeeClassificationName);

    /// <summary>
    /// Gets all EmployeeClassification rows.
    /// </summary>
    IList<TEmployeeClassification> GetAll();

    /// <summary>
    /// Gets an EmployeeClassification row by its primary key.
    /// </summary>
    TEmployeeClassification? GetByKey(int employeeClassificationKey);

    /// <summary>
    /// Update a EmployeeClassification row.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    void Update(TEmployeeClassification classification);
}
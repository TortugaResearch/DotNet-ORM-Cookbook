namespace Recipes.Immutable;

public interface IImmutableScenario<TReadOnlyModel>
   where TReadOnlyModel : class, IReadOnlyEmployeeClassification
{
    /// <summary>
    /// Create a new EmployeeClassification row, returning the new primary key.
    /// </summary>
    int Create(TReadOnlyModel classification);

    /// <summary>
    /// Delete a EmployeeClassification row using an object.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    void Delete(TReadOnlyModel classification);

    /// <summary>
    /// Gets an EmployeeClassification row by its name. Assume the name is unique.
    /// </summary>
    /// <remarks>Must return a null if when row doesn't exist.</remarks>
    TReadOnlyModel? FindByName(string employeeClassificationName);

    /// <summary>
    /// Gets all EmployeeClassification rows.
    /// </summary>
    IReadOnlyList<TReadOnlyModel> GetAll();

    /// <summary>
    /// Gets an EmployeeClassification row by its primary key.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    TReadOnlyModel? GetByKey(int employeeClassificationKey);

    /// <summary>
    /// Update a EmployeeClassification row.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    void Update(TReadOnlyModel classification);
}
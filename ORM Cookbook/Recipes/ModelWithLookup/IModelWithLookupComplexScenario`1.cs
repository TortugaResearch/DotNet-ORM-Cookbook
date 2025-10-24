namespace Recipes.ModelWithLookup;

public interface IModelWithLookupComplexScenario<TEmployee>
   where TEmployee : class, IEmployeeComplex, new()
{
    /// <summary>
    /// Create a new Employee row, returning the new primary key.
    /// </summary>
    /// <remarks>This may NOT modify the EmployeeClassification record.</remarks>
    int Create(TEmployee employee);

    /// <summary>
    /// Delete a Employee row using an object.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. This may NOT modify or delete the EmployeeClassification record.</remarks>
    void Delete(TEmployee employee);

    /// <summary>
    /// Delete a Employee row using its primary key.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined.</remarks>
    void DeleteByKey(int employeeKey);

    /// <summary>
    /// Gets an Employee row by its name.
    /// </summary>
    IList<TEmployee> FindByLastName(string lastName);

    /// <summary>
    /// Gets all Employee rows.
    /// </summary>
    IList<TEmployee> GetAll();

    /// <summary>
    /// Gets an Employee row by its primary key.
    /// </summary>
    TEmployee? GetByKey(int employeeKey);

    /// <summary>
    /// Get an employee classification by key.
    /// </summary>
    /// <param name="employeeClassificationKey">The employee classification key.</param>
    IEmployeeClassification? GetClassification(int employeeClassificationKey);

    /// <summary>
    /// Update a Employee row.
    /// </summary>
    /// <remarks>Behavior when row doesn't exist is not defined. This may NOT modify the EmployeeClassification record.</remarks>
    void Update(TEmployee employee);
}
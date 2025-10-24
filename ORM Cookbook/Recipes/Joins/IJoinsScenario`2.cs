namespace Recipes.Joins;

public interface IJoinsScenario<TEmployeeDetail, TEmployeeSimple>
   where TEmployeeDetail : class, IEmployeeDetail
   where TEmployeeSimple : class, IEmployeeSimple, new()
{
    /// <summary>
    /// Create a new Employee row, returning the new primary key.
    /// </summary>
    int Create(TEmployeeSimple employee);

    /// <summary>
    /// Gets an EmployeeDetail row by its primary key.
    /// </summary>
    IList<TEmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey);

    /// <summary>
    /// Gets an EmployeeDetail row by its name. Assume the name is not unique.
    /// </summary>
    IList<TEmployeeDetail> FindByLastName(string lastName);

    /// <summary>
    /// Gets an EmployeeDetail row by its primary key.
    /// </summary>
    TEmployeeDetail? GetByEmployeeKey(int employeeKey);

    /// <summary>
    /// Get an EmployeeClassification by key.
    /// </summary>
    /// <param name="employeeClassificationKey">The employee classification key.</param>
    IEmployeeClassification? GetClassification(int employeeClassificationKey);
}
namespace Recipes.BasicStoredProc;

public interface IBasicStoredProcScenario<TEmployeeClassification, TEmployeeClassificationWithCount>
   where TEmployeeClassification : class, IEmployeeClassification, new()
   where TEmployeeClassificationWithCount : class, IEmployeeClassificationWithCount
{
    /// <summary>
    /// Execute a stored procedure that returns a collection.
    /// </summary>
    IList<TEmployeeClassificationWithCount> CountEmployeesByClassification();

    /// <summary>
    /// Execute a stored procedure that takes a parameter object and returns a scalar value.
    /// </summary>
    /// <param name="employeeClassification">The employee classification.</param>
    /// <returns>The employee classification key.</returns>
    int CreateEmployeeClassification(TEmployeeClassification employeeClassification);

    /// <summary>
    /// Execute a stored procedure that returns a collection, omitting the optional parameter.
    /// </summary>
    IList<TEmployeeClassification> GetEmployeeClassifications();

    /// <summary>
    /// Execute a stored procedure that returns a collection, providing an optional parameter.
    /// </summary>
    /// <param name="employeesClassificationKey">The employee classification key.</param>
    TEmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey);
}
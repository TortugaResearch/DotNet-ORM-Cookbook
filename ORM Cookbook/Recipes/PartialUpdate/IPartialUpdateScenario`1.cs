namespace Recipes.PartialUpdate;

public interface IPartialUpdateScenario<TEmployeeClassification>
   where TEmployeeClassification : class, IEmployeeClassification, new()
{
    /// <summary>
    /// Create a new EmployeeClassification row, returning the new primary key.
    /// </summary>
    int Create(TEmployeeClassification classification);

    /// <summary>
    /// Gets an EmployeeClassification row by its primary key.
    /// </summary>
    TEmployeeClassification? GetByKey(int employeeClassificationKey);

    void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage);

    void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage);

    void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee);
}

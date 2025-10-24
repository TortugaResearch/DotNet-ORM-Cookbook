using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.Immutable;

public class ReadOnlyEmployeeClassification : IReadOnlyEmployeeClassification
{
    public ReadOnlyEmployeeClassification(EmployeeClassification entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), $"{nameof(entity)} is null.");
        if (entity.EmployeeClassificationName == null)
            throw new ArgumentNullException(nameof(entity), $"{nameof(entity.EmployeeClassificationName)} is null.");

        EmployeeClassificationKey = entity.Id;
        EmployeeClassificationName = entity.EmployeeClassificationName;
        IsExempt = entity.IsExempt;
        IsEmployee = entity.IsEmployee;
    }

    public ReadOnlyEmployeeClassification(int employeeClassificationKey, string employeeClassificationName, bool isExempt, bool isEmployee)
    {
        EmployeeClassificationKey = employeeClassificationKey;
        EmployeeClassificationName = employeeClassificationName;
        IsExempt = isExempt;
        IsEmployee = isEmployee;
    }

    public int Id => EmployeeClassificationKey;
    public int EmployeeClassificationKey { get; }
    public string EmployeeClassificationName { get; }
    public bool IsExempt { get; }
    public bool IsEmployee { get; }
}
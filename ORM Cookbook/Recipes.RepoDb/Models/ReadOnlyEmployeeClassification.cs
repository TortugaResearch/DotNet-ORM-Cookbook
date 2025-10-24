using RepoDb.Attributes;

namespace Recipes.RepoDB.Models;

[Map("[HR].[EmployeeClassification]")]
public class ReadOnlyEmployeeClassification : IReadOnlyEmployeeClassification
{
    public ReadOnlyEmployeeClassification(EmployeeClassification classification)
    {
        if (classification?.EmployeeClassificationName == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification.EmployeeClassificationName)} is null.");

        EmployeeClassificationKey = classification.EmployeeClassificationKey;
        EmployeeClassificationName = classification.EmployeeClassificationName;
        IsExempt = classification.IsExempt;
        IsEmployee = classification.IsEmployee;
    }

    public ReadOnlyEmployeeClassification(int employeeClassificationKey,
        string employeeClassificationName,
        bool isExempt,
        bool isEmployee)
    {
        EmployeeClassificationKey = employeeClassificationKey;
        EmployeeClassificationName = employeeClassificationName;
        IsExempt = isExempt;
        IsEmployee = isEmployee;
    }

    public int EmployeeClassificationKey { get; }

    public string EmployeeClassificationName { get; }
    public bool IsEmployee { get; }
    public bool IsExempt { get; }
}
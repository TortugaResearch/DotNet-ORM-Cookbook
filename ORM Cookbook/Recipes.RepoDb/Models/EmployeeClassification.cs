using RepoDb.Attributes;

namespace Recipes.RepoDB.Models;

[Map("[HR].[EmployeeClassification]")]
public class EmployeeClassification : IEmployeeClassification
{
    public EmployeeClassification()
    {
    }

    public EmployeeClassification(IReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        EmployeeClassificationKey = classification.EmployeeClassificationKey;
        EmployeeClassificationName = classification.EmployeeClassificationName;
        IsExempt = classification.IsExempt;
        IsEmployee = classification.IsEmployee;
    }

    public int EmployeeClassificationKey { get; set; }

    public string? EmployeeClassificationName { get; set; }

    public bool IsEmployee { get; set; }

    public bool IsExempt { get; set; }

    internal ReadOnlyEmployeeClassification ToImmutable()
    {
        return new ReadOnlyEmployeeClassification(this);
    }
}
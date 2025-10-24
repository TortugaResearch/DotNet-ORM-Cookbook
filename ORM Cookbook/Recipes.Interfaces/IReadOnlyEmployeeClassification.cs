namespace Recipes;

public interface IReadOnlyEmployeeClassification
{
    int EmployeeClassificationKey { get; }
    string? EmployeeClassificationName { get; }
    bool IsEmployee { get; }
    bool IsExempt { get; }
}
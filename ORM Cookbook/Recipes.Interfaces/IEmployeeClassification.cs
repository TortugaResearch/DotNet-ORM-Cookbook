namespace Recipes;

public interface IEmployeeClassification : IReadOnlyEmployeeClassification
{
    new int EmployeeClassificationKey { get; set; }
    new string? EmployeeClassificationName { get; set; }
    new bool IsEmployee { get; set; }
    new bool IsExempt { get; set; }
}
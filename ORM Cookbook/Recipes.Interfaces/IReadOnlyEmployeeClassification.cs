namespace Recipes
{
    public interface IReadOnlyEmployeeClassification
    {
        int EmployeeClassificationKey { get; }
        string? EmployeeClassificationName { get; }
        bool IsExempt { get; }
        bool IsEmployee { get; }
    }
}

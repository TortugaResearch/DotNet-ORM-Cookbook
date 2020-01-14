namespace Recipes.Joins
{
    public interface IEmployeeClassification
    {
        int EmployeeClassificationKey { get; }
        string? EmployeeClassificationName { get; }
        bool IsExempt { get; }
        bool IsEmployee { get; }
    }
}
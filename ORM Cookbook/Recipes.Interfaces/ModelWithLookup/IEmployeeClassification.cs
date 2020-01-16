namespace Recipes.ModelWithLookup
{
    public interface IEmployeeClassification
    {
        int EmployeeClassificationKey { get; }
        string? EmployeeClassificationName { get; set; }
        bool IsExempt { get; }
        bool IsEmployee { get; }
    }
}

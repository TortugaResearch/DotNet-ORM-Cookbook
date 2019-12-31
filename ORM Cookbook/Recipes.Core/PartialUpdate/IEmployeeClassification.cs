namespace Recipes.PartialUpdate
{
    public interface IEmployeeClassification
    {
        int EmployeeClassificationKey { get; set; }
        string? EmployeeClassificationName { get; set; }
        bool IsExempt { get; set; }
        bool IsEmployee { get; set; }
    }
}

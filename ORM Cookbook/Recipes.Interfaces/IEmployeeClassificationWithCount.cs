namespace Recipes;

public interface IEmployeeClassificationWithCount
{
    int EmployeeClassificationKey { get; set; }
    string? EmployeeClassificationName { get; set; }
    int EmployeeCount { get; set; }
}
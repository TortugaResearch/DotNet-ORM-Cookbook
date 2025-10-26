namespace Recipes.PetaPoco.Models;

public class EmployeeClassification : IEmployeeClassification
{
    public int EmployeeClassificationKey { get; set; }

    public string? EmployeeClassificationName { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsExempt { get; set; }
}
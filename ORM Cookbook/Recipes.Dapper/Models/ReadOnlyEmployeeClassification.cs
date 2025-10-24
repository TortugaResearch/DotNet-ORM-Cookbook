namespace Recipes.Dapper.Models;

public class ReadOnlyEmployeeClassification : IReadOnlyEmployeeClassification
{
    public ReadOnlyEmployeeClassification(int employeeClassificationKey, string employeeClassificationName, bool isExempt, bool isEmployee)
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
namespace Recipes;

public interface IEmployeeDetail
{
    string? CellPhone { get; set; }
    int EmployeeClassificationKey { get; set; }
    string? EmployeeClassificationName { get; set; }
    int EmployeeKey { get; set; }
    string? FirstName { get; set; }
    bool IsEmployee { get; set; }
    bool IsExempt { get; set; }
    string? LastName { get; set; }
    string? MiddleName { get; set; }
    string? OfficePhone { get; set; }
    string? Title { get; set; }
}
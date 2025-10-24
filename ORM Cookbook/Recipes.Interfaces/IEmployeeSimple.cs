namespace Recipes;

public interface IEmployeeSimple
{
    string? CellPhone { get; set; }
    int EmployeeClassificationKey { get; set; }
    int EmployeeKey { get; set; }
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? MiddleName { get; set; }
    string? OfficePhone { get; set; }
    string? Title { get; set; }
}
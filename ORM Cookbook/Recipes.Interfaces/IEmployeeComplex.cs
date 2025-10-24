namespace Recipes;

public interface IEmployeeComplex
{
    string? CellPhone { get; set; }
    IReadOnlyEmployeeClassification? EmployeeClassification { get; set; }
    int EmployeeKey { get; set; }
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? MiddleName { get; set; }
    string? OfficePhone { get; set; }
    string? Title { get; set; }
}
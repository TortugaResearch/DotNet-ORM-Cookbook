namespace Recipes.Views
{
    public interface IEmployeeDetail
    {
        int EmployeeKey { get; set; }
        string? FirstName { get; set; }
        string? MiddleName { get; set; }
        string? LastName { get; set; }
        string? Title { get; set; }
        string? OfficePhone { get; set; }
        string? CellPhone { get; set; }
        int EmployeeClassificationKey { get; set; }
        string? EmployeeClassificationName { get; set; }
        bool IsExempt { get; set; }
        bool IsEmployee { get; set; }
    }
}

namespace Recipes.ModelWithLookup
{
    public interface IEmployeeComplex
    {
        int EmployeeKey { get; set; }
        string? FirstName { get; set; }
        string? MiddleName { get; set; }
        string? LastName { get; set; }
        string? Title { get; set; }
        string? OfficePhone { get; set; }
        string? CellPhone { get; set; }
        IEmployeeClassification? EmployeeClassification { get; set; }
    }
}

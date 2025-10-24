using Recipes.RepoDB.Models;
using RepoDb.Attributes;

namespace Recipes.RepoDb.Models;

[Map("[HR].[Employee]")]
public partial class EmployeeComplex : IEmployeeComplex
{
    public string? CellPhone { get; set; }

    public EmployeeClassification? EmployeeClassification { get; set; }

    public int EmployeeClassificationKey { get; set; }

    public int EmployeeKey { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? OfficePhone { get; set; }
    public string? Title { get; set; }
}

//Used for linking the entity to the test framework. Not part of the recipe.
partial class EmployeeComplex : IEmployeeComplex
{
    IReadOnlyEmployeeClassification? IEmployeeComplex.EmployeeClassification
    {
        get => EmployeeClassification;
        set
        {
            EmployeeClassification = (EmployeeClassification?)value;
            EmployeeClassificationKey = (value?.EmployeeClassificationKey).GetValueOrDefault();
        }
    }
}
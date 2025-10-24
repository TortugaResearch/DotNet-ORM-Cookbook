using System.ComponentModel.DataAnnotations.Schema;
using Tortuga.Anchor.Modeling;

namespace Recipes.Chain.Models;

[Table("HR.Employee")]
[View("HR.EmployeeDetail")]
public partial class EmployeeComplex
{
    public string? CellPhone { get; set; }

    [Decompose] //Used for Read operations
    public EmployeeClassification? EmployeeClassification { get; set; }

    //Used for Insert/Update operations
    public int EmployeeClassificationKey => EmployeeClassification?.EmployeeClassificationKey ?? 0;

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
        set => EmployeeClassification = (EmployeeClassification?)value;
    }
}
namespace Recipes.EntityFramework.Entities;

//Used for linking the entity to the test framework. Not part of the recipe.
partial class Employee : IEmployeeComplex
{
    IReadOnlyEmployeeClassification? IEmployeeComplex.EmployeeClassification
    {
        get => EmployeeClassification;
        set => EmployeeClassification = (EmployeeClassification?)value;
    }
}
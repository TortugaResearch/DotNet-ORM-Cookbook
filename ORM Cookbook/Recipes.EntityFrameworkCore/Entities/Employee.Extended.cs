namespace Recipes.EntityFrameworkCore.Entities;

//Used for linking the entity to the test framework. Not part of the recipe.
partial class Employee : IEmployeeSimple
{
    int IEmployeeSimple.EmployeeClassificationKey
    {
        get => EmployeeClassificationKey;
        set => EmployeeClassificationKey = value;
    }
}

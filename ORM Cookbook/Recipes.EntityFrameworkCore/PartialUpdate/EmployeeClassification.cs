using Recipes.PartialUpdate;

namespace Recipes.EntityFrameworkCore.Entities
{
    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class EmployeeClassification : IEmployeeClassification
    {
        //Work-around for the generated nullable type
        bool IEmployeeClassification.IsEmployee { get => IsEmployee ?? true; set => IsEmployee = value; }
    }
}

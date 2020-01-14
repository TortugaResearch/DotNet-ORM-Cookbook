using Recipes.Sorting;

namespace Recipes.ServiceStack.Entities
{
    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class Employee : IEmployeeSimple
    {
        int IEmployeeSimple.EmployeeKey { get => Id; set => Id = value; }
        int IEmployeeSimple.EmployeeClassificationKey { get => EmployeeClassificationId ?? 0; set => EmployeeClassificationId = value; }
    }
}

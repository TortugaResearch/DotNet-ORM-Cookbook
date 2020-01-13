using Recipes.Views;

namespace Recipes.ServiceStack.Entities
{
    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class EmployeeDetail : IEmployeeDetail
    {
        public int EmployeeKey { get => Id; set => Id = value; }
        public int EmployeeClassificationKey { get => EmployeeClassificationId ?? 0; set => EmployeeClassificationId = value; }
    }
}

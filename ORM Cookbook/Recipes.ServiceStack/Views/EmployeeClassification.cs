using Recipes.Views;

namespace Recipes.ServiceStack.Entities
{
    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey => Id;
    }
}

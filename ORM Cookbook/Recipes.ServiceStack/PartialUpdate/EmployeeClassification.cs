using Recipes.PartialUpdate;
using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities
{
    //Used for linking the entity to the test framework. Not part of the recipe.
    partial class EmployeeClassificationPartial : IEmployeeClassification
    {
        [Ignore]
        int IEmployeeClassification.EmployeeClassificationKey
        {
            get => Id;
            set => Id = value;
        }
    }
}

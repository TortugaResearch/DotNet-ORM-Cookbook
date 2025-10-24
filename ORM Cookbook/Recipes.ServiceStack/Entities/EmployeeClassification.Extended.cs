using ServiceStack.DataAnnotations;
using Ignore = ServiceStack.DataAnnotations.IgnoreAttribute;

namespace Recipes.ServiceStack.Entities;

//Used for linking the entity to the test framework. Not part of the recipe.
partial class EmployeeClassification : IEmployeeClassification
{
    [Ignore]
    int IEmployeeClassification.EmployeeClassificationKey { get => Id; set => Id = value; }

    [Ignore]
    int IReadOnlyEmployeeClassification.EmployeeClassificationKey { get => Id; }
}
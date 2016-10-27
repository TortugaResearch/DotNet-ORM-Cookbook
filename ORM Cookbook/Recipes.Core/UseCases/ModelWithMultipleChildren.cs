using Recipes.Models;

namespace Recipes.UseCases
{
    public abstract class ModelWithMultipleChildren<TModel, TDepartment>
        where TModel : IDivision<IDepartment>, new()
        where TDepartment : IDepartment, new()

    {

    }
}

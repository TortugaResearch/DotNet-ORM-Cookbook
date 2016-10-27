using Recipes.Models;

namespace Recipes.UseCases
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelWithSingleChild<TModel, TDivision>
        where TModel : IDepartment<TDivision>, new()
        where TDivision : IDivision, new()

    {

    }
}

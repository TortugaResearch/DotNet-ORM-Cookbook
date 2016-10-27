using Recipes.Models;

namespace Recipes.UseCases
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelWithForeignKey<TModel>
        where TModel : IDepartment, new()
    {

    }
}

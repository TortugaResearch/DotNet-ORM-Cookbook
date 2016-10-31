using Recipes.EF.Models;
using Recipes.UseCases;

namespace Recipes.EF
{
    public class ModelWithSingleChild : ModelWithSingleChild<Department, Division>
    {

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new Recipes.EF.Repositories.DepartmentWithChildRepository());
        }

    }
}

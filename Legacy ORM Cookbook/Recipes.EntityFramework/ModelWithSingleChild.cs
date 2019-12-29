using Recipes.EF.Models;
using Recipes.UseCases;
using Recipes.EF.Repositories;

namespace Recipes.EF
{
    public class ModelWithSingleChild : ModelWithSingleChild<Department, Division>
    {

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new DepartmentWithChildRepository());
        }

    }
}

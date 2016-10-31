using Recipes.NHibernate.Models;
using Recipes.NHibernate.Repositories;
using Recipes.UseCases;

namespace Recipes.NHibernate
{
    public class ModelWithSingleChild : ModelWithSingleChild<Department, Division>
    {
        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new DepartmentWithChildRepository());
        }


    }


}

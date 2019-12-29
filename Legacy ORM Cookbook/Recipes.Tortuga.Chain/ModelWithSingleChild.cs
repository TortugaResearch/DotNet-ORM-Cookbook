using Recipes.Chain.Models;
using Recipes.UseCases;
using Tortuga.Chain;

namespace Recipes.Chain
{
    public class ModelWithSingleChild : ModelWithSingleChild<Department, Division>
    {

        static SqlServerDataSource s_DataSource = SqlServerDataSource.CreateFromConfig("OrmCookbook");

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new DepartmentWithChildRepository(s_DataSource));
        }

    }
}

using Recipes.Chain.Models;
using Recipes.UseCases;
using Tortuga.Chain;

namespace Recipes.Chain
{
    public class ModelWithForeignKey : ModelWithForeignKey<SimpleDepartment>
    {

        static SqlServerDataSource s_DataSource = SqlServerDataSource.CreateFromConfig("OrmCookbook");

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new SimpleDepartmentRepository(s_DataSource));
        }

    }
}

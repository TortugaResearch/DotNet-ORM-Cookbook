using Recipes.Dapper.Models;
using Recipes.UseCases;
using System.Configuration;

namespace Recipes.Dapper
{
    public class ModelWithSingleChild : ModelWithSingleChild<Department, Division>
    {

        string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["OrmCookbook"].ConnectionString; }
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new Recipes.Dapper.Repositories.DepartmentWithChildRepository(ConnectionString));
        }

    }
}

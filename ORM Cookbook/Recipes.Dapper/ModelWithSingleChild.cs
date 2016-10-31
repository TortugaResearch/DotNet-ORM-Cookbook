using Recipes.Dapper.Models;
using Recipes.Dapper.Repositories;
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
            CreateAndUpdate(new DepartmentWithChildRepository(ConnectionString));
        }

    }
}

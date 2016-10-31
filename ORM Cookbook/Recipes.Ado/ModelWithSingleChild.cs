using Recipes.Ado.Models;
using Recipes.UseCases;
using System.Configuration;

namespace Recipes.Ado
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

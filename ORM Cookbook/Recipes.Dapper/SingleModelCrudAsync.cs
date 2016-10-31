using Recipes.Dapper.Models;
using Recipes.Dapper.Repositories;
using Recipes.UseCases;
using System.Configuration;
using System.Threading.Tasks;

namespace Recipes.Dapper
{
    public class SingleModelCrudAsync : SingleModelCrudAsync<EmployeeClassification>
    {

        string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["OrmCookbook"].ConnectionString; }
        }

        public override Task CreateAndReadBack()
        {
            return CreateAndReadBack(new EmployeeClassificationAsynchronousRepository(ConnectionString));
        }

        public override Task CreateAndDelete()
        {
            return CreateAndDelete(new EmployeeClassificationAsynchronousRepository(ConnectionString));
        }

        public override Task GetAll()
        {
            return GetAll(new EmployeeClassificationAsynchronousRepository(ConnectionString));
        }

        public override Task GetByKey()
        {
            return GetByKey(new EmployeeClassificationAsynchronousRepository(ConnectionString));
        }

        public override Task CreateAndUpdate()
        {
            return CreateAndUpdate(new EmployeeClassificationAsynchronousRepository(ConnectionString));

        }
    }
}

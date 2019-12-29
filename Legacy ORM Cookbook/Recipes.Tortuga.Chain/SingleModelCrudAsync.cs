using Recipes.Chain.Models;
using Recipes.Chain.Repositories;
using Recipes.UseCases;
using System.Threading.Tasks;
using Tortuga.Chain;

namespace Recipes.Chain
{
    public class SingleModelCrudAsync : SingleModelCrudAsync<EmployeeClassification>
    {

        static SqlServerDataSource s_DataSource = SqlServerDataSource.CreateFromConfig("OrmCookbook");

        public override Task CreateAndReadBack()
        {
            return CreateAndReadBack(new EmployeeClassificationAsynchronousRepository(s_DataSource));
        }

        public override Task CreateAndDelete()
        {
            return CreateAndDelete(new EmployeeClassificationAsynchronousRepository(s_DataSource));
        }

        public override Task GetAll()
        {
            return GetAll(new EmployeeClassificationAsynchronousRepository(s_DataSource));
        }

        public override Task GetByKey()
        {
            return GetByKey(new EmployeeClassificationAsynchronousRepository(s_DataSource));
        }
        public override Task CreateAndUpdate()
        {
            return CreateAndUpdate(new EmployeeClassificationAsynchronousRepository(s_DataSource));

        }
    }
}

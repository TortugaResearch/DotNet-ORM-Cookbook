using Recipes.Dapper.Repositories;
using Recipes.EF.Models;
using Recipes.UseCases;
using System.Threading.Tasks;

namespace Recipes.EF
{
    public class SingleModelCrudAsync : SingleModelCrudAsync<EmployeeClassification>
    {
        public override Task CreateAndReadBack()
        {
            return CreateAndReadBack(new EmployeeClassificationAsynchronousRepository());
        }

        public override Task CreateAndDelete()
        {
            return CreateAndDelete(new EmployeeClassificationAsynchronousRepository());
        }

        public override Task GetAll()
        {
            return GetAll(new EmployeeClassificationAsynchronousRepository());
        }

        public override Task GetByKey()
        {
            return GetByKey(new EmployeeClassificationAsynchronousRepository());
        }
        public override Task CreateAndUpdate()
        {
            return CreateAndUpdate(new EmployeeClassificationAsynchronousRepository());
        }
    }
}

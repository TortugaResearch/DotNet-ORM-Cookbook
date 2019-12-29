using System;
using Recipes.UseCases;
using System.Threading.Tasks;
using LLBLGenPro.OrmCookbook.EntityClasses;
using Recipes.LLBLGenPro.Repositories;

namespace Recipes.LLBLGenPro
{
    public class SingleModelCrudAsyncQuerySpec : SingleModelCrudAsync<EmployeeClassificationEntity>
    {
        public override Task CreateAndReadBack()
        {
            return CreateAndReadBack(new EmployeeClassificationAsynchronousRepositoryQuerySpec());
        }

        public override Task CreateAndDelete()
        {
            return CreateAndDelete(new EmployeeClassificationAsynchronousRepositoryQuerySpec());
        }

        public override Task GetAll()
        {
            return GetAll(new EmployeeClassificationAsynchronousRepositoryQuerySpec());
        }

        public override Task GetByKey()
        {
            return GetByKey(new EmployeeClassificationAsynchronousRepositoryQuerySpec());
        }

        public override Task CreateAndUpdate()
        {
            return CreateAndUpdate(new EmployeeClassificationAsynchronousRepositoryQuerySpec());
        }
    }
}

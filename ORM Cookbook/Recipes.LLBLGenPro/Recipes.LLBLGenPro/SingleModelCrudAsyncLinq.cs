using System;
using Recipes.UseCases;
using System.Threading.Tasks;
using LLBLGenPro.OrmCookbook.EntityClasses;
using Recipes.LLBLGenPro.Repositories;

namespace Recipes.Dapper
{
    public class SingleModelCrudAsyncLinq : SingleModelCrudAsync<EmployeeClassificationEntity>
    {
        public override Task CreateAndReadBack()
        {
            return CreateAndReadBack(new EmployeeClassificationAsynchronousRepositoryLinq());
        }

        public override Task CreateAndDelete()
        {
            return CreateAndDelete(new EmployeeClassificationAsynchronousRepositoryLinq());
        }

        public override Task GetAll()
        {
            return GetAll(new EmployeeClassificationAsynchronousRepositoryLinq());
        }

        public override Task GetByKey()
        {
            return GetByKey(new EmployeeClassificationAsynchronousRepositoryLinq());
        }

        public override Task CreateAndUpdate()
        {
            return CreateAndUpdate(new EmployeeClassificationAsynchronousRepositoryLinq());
        }
    }
}

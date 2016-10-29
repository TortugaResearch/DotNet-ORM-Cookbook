using Recipes.Dapper.Repositories;
using Recipes.EF.Models;
using Recipes.UseCases;

namespace Recipes.EF
{
    public class SingleModelCrud_Novice : SingleModelCrud<EmployeeClassification>
    {

        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepository());
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepository());
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepository());
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepository());
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepository());
        }
    }
}

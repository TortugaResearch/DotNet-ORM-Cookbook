using System;
using Recipes.Dapper.Repositories;
using Recipes.EF.Models;
using Recipes.UseCases;

namespace Recipes.EF
{
    public class SingleModelCrud_Novice : SingleModelCrud<EmployeeClassification>
    {

        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepository_Novice());
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepository_Novice());
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepository_Novice());
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepository_Novice());
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepository_Novice());
        }
    }

    public class SingleModelCrud_Intermediate : SingleModelCrud<EmployeeClassification>
    {

        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepository_Intermediate());
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepository_Intermediate());
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepository_Intermediate());
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepository_Intermediate());
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepository_Novice());
        }
    }
}

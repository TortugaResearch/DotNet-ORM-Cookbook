using Recipes.Dapper.Models;
using Recipes.Dapper.Repositories;
using Recipes.UseCases;
using System.Configuration;
using System;

namespace Recipes.Dapper
{
    public class SingleModelCrud : SingleModelCrud<EmployeeClassification>
    {
        string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["OrmCookbook"].ConnectionString; }
        }

        public override void CreateAndReadBack()
        {
            CreateAndReadBack(new EmployeeClassificationRepository(ConnectionString));
        }

        public override void CreateAndDelete()
        {
            CreateAndDelete(new EmployeeClassificationRepository(ConnectionString));
        }

        public override void GetAll()
        {
            GetAll(new EmployeeClassificationRepository(ConnectionString));
        }

        public override void GetByKey()
        {
            GetByKey(new EmployeeClassificationRepository(ConnectionString));
        }

        public override void CreateAndUpdate()
        {
            CreateAndUpdate(new EmployeeClassificationRepository(ConnectionString));
        }
    }
}

using Dapper;
using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Dapper.SingleModelCrud
{
    public class SingleModelCrudScenarioContrib : SingleModelCrudScenario
    {
        public SingleModelCrudScenarioContrib(string connectionString) : base(connectionString)
        {
        }

        override public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = OpenConnection())
                return (int)con.Insert(classification);
        }

        override public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = OpenConnection())
                con.Delete(classification);
        }

        override public IList<EmployeeClassification> GetAll()
        {
            using (var con = OpenConnection())
                return con.GetAll<EmployeeClassification>().ToList();
        }

        override public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var con = OpenConnection())
                return con.Get<EmployeeClassification>(employeeClassificationKey);
        }

        override public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = OpenConnection())
                con.Update(classification);
        }
    }
}
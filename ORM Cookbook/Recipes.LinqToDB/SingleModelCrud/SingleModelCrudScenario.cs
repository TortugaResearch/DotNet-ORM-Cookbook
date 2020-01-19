using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LinqToDB.SingleModelCrud
{
    public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassification>
    {
        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                return db.InsertWithInt32Identity(classification);
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                db.EmployeeClassification
                    .Where(d => d.EmployeeClassificationKey == classification.EmployeeClassificationKey)
                    .Delete();
            }
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                db.EmployeeClassification
                    .Where(d => d.EmployeeClassificationKey == employeeClassificationKey)
                    .Delete();
            }
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            using (var db = new OrmCookbook())
            {
                var query = from ec in db.EmployeeClassification
                            where ec.EmployeeClassificationName == employeeClassificationName
                            select ec;
                return query.Single();
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.ToList();
            }
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == employeeClassificationKey).Single();
            }
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                db.Update(classification);
            }
        }
    }
}

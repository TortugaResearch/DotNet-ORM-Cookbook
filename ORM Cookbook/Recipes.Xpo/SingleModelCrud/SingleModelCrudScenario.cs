using Recipes.Xpo.Entities;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.SingleModelCrud
{
    public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassification>
    {

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            classification.Save();
            return classification.EmployeeClassificationKey;
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            classification.Delete();
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var uow = new UnitOfWork())
            {
                uow.GetObjectByKey<EmployeeClassification>(employeeClassificationKey).Delete();
                uow.CommitChanges();
            }
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            return Session.DefaultSession.Query<EmployeeClassification>().Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
        }

        public IList<EmployeeClassification> GetAll()
        {
            return Session.DefaultSession.Query<EmployeeClassification>().ToList();
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");
            classification.Save();
        }
    }
}

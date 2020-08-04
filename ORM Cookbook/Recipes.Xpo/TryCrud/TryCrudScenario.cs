using Recipes.Xpo.Entities;
using Recipes.TryCrud;
using System;
using System.Data;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.TryCrud
{
    public class TryCrudScenario : ITryCrudScenario<EmployeeClassification>
    {
        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            classification.Save();
            return classification.EmployeeClassificationKey;
        }

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
            if (temp != null)
            {
                temp.Delete();
            } else
                throw new DataException($"No row was found for key {employeeClassificationKey}.");
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
            if (temp != null)
            {
                temp.Delete();
                return true;
            } else
                return false;
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(classification.EmployeeClassificationKey);
            if (temp != null)
            {
                temp.Delete();
            } else
                throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(classification.EmployeeClassificationKey);
            if (temp != null)
            {
                temp.Delete();
                return true;
            } else
                return false;
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            return Session.DefaultSession.Query<EmployeeClassification>().Where(ec => ec.EmployeeClassificationName == employeeClassificationName).Single();
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            return Session.DefaultSession.Query<EmployeeClassification>().Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey) ?? throw new DataException($"No row was found for key {employeeClassificationKey}.");
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var uow = new UnitOfWork())
            {
                var temp = uow.GetObjectByKey<EmployeeClassification>(classification.EmployeeClassificationKey);
                if (temp != null)
                {
                    //Copy the changed fields
                    temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                    uow.Save(temp);
                } else
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var uow = new UnitOfWork())
            {
                var temp = uow.GetObjectByKey<EmployeeClassification>(classification.EmployeeClassificationKey);
                if (temp != null)
                {
                    //Copy the changed fields
                    temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                    uow.Save(temp);
                    return true;
                } else
                    return false;
            }
        }
    }
}

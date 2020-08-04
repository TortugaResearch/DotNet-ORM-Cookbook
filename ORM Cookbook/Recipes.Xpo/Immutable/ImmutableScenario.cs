using Recipes.Xpo.Models;
using Recipes.Immutable;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using DevExpress.Xpo;
using Recipes.Xpo.Entities;

namespace Recipes.Xpo.Immutable
{
    public class ImmutableScenario : IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var temp = classification.ToEntity();
            temp.Save();
            return temp.EmployeeClassificationKey;
        }

        public virtual void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var uow = new UnitOfWork())
            {
                uow.Delete(uow.GetObjectByKey<EmployeeClassification>(classification.EmployeeClassificationKey));
                uow.CommitChanges();
            }
        }

        public virtual void DeleteByKey(int employeeClassificationKey)
        {
            using (var uow = new UnitOfWork())
            {
                uow.Delete(uow.GetObjectByKey<EmployeeClassification>(employeeClassificationKey));
                uow.CommitChanges();
            }
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return Session.DefaultSession.Query<EmployeeClassification>()
                .Where(ec => ec.EmployeeClassificationName == employeeClassificationName)
                .Select(x => new ReadOnlyEmployeeClassification(x)).SingleOrDefault();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.Query<EmployeeClassification>().Select(x => new ReadOnlyEmployeeClassification(x)).ToImmutableArray();
            }
        }

        public ReadOnlyEmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var uow = new UnitOfWork())
            {
                var temp = uow.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
                if (temp == null)
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
                return new ReadOnlyEmployeeClassification(temp);
            }
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(classification.EmployeeClassificationKey);
            if (temp != null)
            {
                //Copy the changed fields
                temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                temp.IsEmployee = classification.IsEmployee;
                temp.IsExempt = classification.IsExempt;
                temp.Save();
            }
        }
    }
}

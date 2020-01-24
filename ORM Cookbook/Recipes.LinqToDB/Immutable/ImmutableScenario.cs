using LinqToDB;
using Recipes.Immutable;
using Recipes.LinqToDB.Entities;
using Recipes.LinqToDB.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;

namespace Recipes.LinqToDB.Immutable
{
    public class ImmutableScenario : IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                return db.InsertWithInt32Identity(classification.ToEntity());
            }
        }

        public virtual void Delete(ReadOnlyEmployeeClassification classification)
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

        public virtual void DeleteByKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                db.EmployeeClassification
                    .Where(d => d.EmployeeClassificationKey == employeeClassificationKey)
                    .Delete();
            }
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            using (var db = new OrmCookbook())
            {
                var query = from ec in db.EmployeeClassification
                            where ec.EmployeeClassificationName == employeeClassificationName
                            select ec;
                return query.Select(x => new ReadOnlyEmployeeClassification(x)).SingleOrDefault();
            }
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification
                    .Select(x => new ReadOnlyEmployeeClassification(x)).ToImmutableArray();
            }
        }

        public ReadOnlyEmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == employeeClassificationKey)
                    .Select(x => new ReadOnlyEmployeeClassification(x)).Single();
            }
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                db.Update(classification.ToEntity());
            }
        }
    }
}

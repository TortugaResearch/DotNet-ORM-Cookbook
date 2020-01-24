using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.TryCrud;
using System;
using System.Data;
using System.Linq;

namespace Recipes.LinqToDB.TryCrud
{
    public class TryCrudScenario : ITryCrudScenario<EmployeeClassification>
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

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                var rowCount = db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == employeeClassificationKey).Delete();
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
            }
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                return 1 == db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == employeeClassificationKey).Delete();
            }
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                var rowCount = db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == classification.EmployeeClassificationKey).Delete();
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                return 1 == db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == classification.EmployeeClassificationKey).Delete();
            }
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).Single();
            }
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
            }
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(ec => ec.EmployeeClassificationKey == employeeClassificationKey).Single();
            }
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(ec => ec.EmployeeClassificationKey == employeeClassificationKey).SingleOrDefault();
            }
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                var rowCount = db.Update(classification);
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                return 1 == db.Update(classification);
            }
        }
    }
}

using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.PartialUpdate;
using System;
using System.Linq;

namespace Recipes.LinqToDB.PartialUpdate
{
    public class PartialUpdateScenario : IPartialUpdateScenario<EmployeeClassification>
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

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == employeeClassificationKey).Single();
            }
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var db = new OrmCookbook())
            {
                db.EmployeeClassification
                    .Where(ec => ec.EmployeeClassificationKey == updateMessage.EmployeeClassificationKey)
                    .Set(ec => ec.EmployeeClassificationName, updateMessage.EmployeeClassificationName)
                    .Update();
            }
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var db = new OrmCookbook())
            {
                db.EmployeeClassification
                    .Where(ec => ec.EmployeeClassificationKey == updateMessage.EmployeeClassificationKey)
                    .Set(ec => ec.IsExempt, updateMessage.IsExempt)
                    .Set(ec => ec.IsEmployee, updateMessage.IsEmployee)
                    .Update();
            }
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            using (var db = new OrmCookbook())
            {
                db.EmployeeClassification
                    .Where(ec => ec.EmployeeClassificationKey == employeeClassificationKey)
                    .Set(ec => ec.IsExempt, isExempt)
                    .Set(ec => ec.IsEmployee, isEmployee)
                    .Update();
            }
        }
    }
}

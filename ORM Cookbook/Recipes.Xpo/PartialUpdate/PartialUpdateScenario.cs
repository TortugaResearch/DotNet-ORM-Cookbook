using Recipes.Xpo.Entities;
using Recipes.PartialUpdate;
using System;
using DevExpress.Xpo;

namespace Recipes.Xpo.PartialUpdate
{
    public class PartialUpdateScenario : IPartialUpdateScenario<EmployeeClassification>
    {

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");
            classification.Save();
            return classification.EmployeeClassificationKey;
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            //Get a fresh copy of the row from the database
            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(updateMessage.EmployeeClassificationKey);
            if (temp != null)
            {
                //Copy the changed fields
                temp.EmployeeClassificationName = updateMessage.EmployeeClassificationName;
                temp.Save();
            }
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            //Get a fresh copy of the row from the database
            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(updateMessage.EmployeeClassificationKey);
            if (temp != null)
            {
                //Copy the changed fields
                temp.IsExempt = updateMessage.IsExempt;
                temp.IsEmployee = updateMessage.IsEmployee;
                temp.Save();
            }

        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            //Get a fresh copy of the row from the database
            var temp = Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
            if (temp != null)
            {
                //Copy the changed fields
                temp.IsExempt = isExempt;
                temp.IsEmployee = isEmployee;
                temp.Save();
            }
        }
    }
}

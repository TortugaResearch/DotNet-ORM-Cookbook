using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;

namespace Recipes.RepoDb.PartialUpdate
{
    public class PartialUpdateRepository : IPartialUpdateRepository<EmployeeClassification>
    {
        public int Create(EmployeeClassification classification)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            throw new AssertInconclusiveException("TODO");
        }
    }
}

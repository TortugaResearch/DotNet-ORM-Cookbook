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

        public void Update(EmployeeClassificationNameUpdater updateMessage)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void Update(EmployeeClassificationFlagsUpdater updateMessage)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void UpdateFlags(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            throw new AssertInconclusiveException("TODO");
        }
    }
}

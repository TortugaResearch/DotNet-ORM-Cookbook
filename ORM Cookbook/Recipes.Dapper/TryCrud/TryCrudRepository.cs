using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.TryCrud;

namespace Recipes.Dapper.TryCrud
{
    public class TryCrudRepository : ITryCrudRepository<EmployeeClassification>
    {
        public int Create(EmployeeClassification classification)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            throw new AssertInconclusiveException("TODO");
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            throw new AssertInconclusiveException("TODO");
        }
    }
}

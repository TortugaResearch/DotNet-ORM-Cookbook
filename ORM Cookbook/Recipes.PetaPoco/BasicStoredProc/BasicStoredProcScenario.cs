using Recipes.BasicStoredProc;
using Recipes.PetaPoco.Models;

namespace Recipes.PetaPoco.BasicStoredProc
{
    public class BasicStoredProcScenario : ScenarioBase,
        IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
    {
        public BasicStoredProcScenario(string connectionString) : base(connectionString)
        { }

        public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
        {
            throw new NotImplementedException();
        }

        public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
        {
            throw new NotImplementedException();
        }

        public IList<EmployeeClassification> GetEmployeeClassifications()
        {
            throw new NotImplementedException();
        }

        public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
        {
            throw new NotImplementedException();
        }
    }
}
using Recipes.BasicStoredProc;
using Recipes.DbConnector.Models;
using System.Data;

namespace Recipes.DbConnector.BasicStoredProc;

public class BasicStoredProcScenario : ScenarioBase,
    IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
{
    public BasicStoredProcScenario(string connectionString) : base(connectionString)
    { }

    public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
    {
        return DbConnector.ReadToList<EmployeeClassificationWithCount>("HR.CountEmployeesByClassification",
            commandType: CommandType.StoredProcedure).Execute();
    }

    public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
    {
        if (employeeClassification == null)
            throw new ArgumentNullException(nameof(employeeClassification),
                $"{nameof(employeeClassification)} is null.");

        //Need to project the parameters so we can exclude the unused EmployeeClassificationKey
        return DbConnector.Scalar<int>("HR.CreateEmployeeClassification",
            new
            {
                employeeClassification.EmployeeClassificationName,
                employeeClassification.IsEmployee,
                employeeClassification.IsExempt
            }, commandType: CommandType.StoredProcedure).Execute();
    }

    public IList<EmployeeClassification> GetEmployeeClassifications()
    {
        return DbConnector.ReadToList<EmployeeClassification>("HR.GetEmployeeClassifications",
            commandType: CommandType.StoredProcedure).Execute();
    }

    public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
    {
        return DbConnector.ReadSingleOrDefault<EmployeeClassification>("HR.GetEmployeeClassifications",
            new { employeeClassificationKey }, commandType: CommandType.StoredProcedure).Execute();
    }
}
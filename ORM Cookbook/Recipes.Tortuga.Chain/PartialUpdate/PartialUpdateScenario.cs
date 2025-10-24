using Recipes.Chain.Models;
using Recipes.PartialUpdate;
using Tortuga.Chain;

namespace Recipes.Chain.PartialUpdate;

public class PartialUpdateScenario : IPartialUpdateScenario<EmployeeClassification>
{
    const string TableName = "HR.EmployeeClassification";
    readonly SqlServerDataSource m_DataSource;

    public PartialUpdateScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        return m_DataSource.Insert(classification).ToInt32().Execute();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        return m_DataSource.GetByKey<EmployeeClassification>(employeeClassificationKey).ToObject().Execute();
    }

    public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        m_DataSource.Update(updateMessage).Execute();
    }

    public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        m_DataSource.Update(updateMessage).Execute();
    }

    public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
    {
        m_DataSource.Update(TableName, new { employeeClassificationKey, isExempt, isEmployee }).Execute();
    }
}
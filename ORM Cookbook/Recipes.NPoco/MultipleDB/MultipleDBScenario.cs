using Recipes.MultipleDB;
using Recipes.NPoco.Models;

namespace Recipes.NPoco.MultipleDB;

public class MultipleDBScenario : IMultipleDBScenario<EmployeeClassification>
{
    readonly string m_ConnectionString;
    readonly DatabaseType m_DatabaseType;

    public MultipleDBScenario(string connectionString, DatabaseType databaseType)
    {
        m_ConnectionString = connectionString;
        m_DatabaseType = databaseType;
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeClassification> GetAll()
    {
        throw new NotImplementedException();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public void Update(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }
}
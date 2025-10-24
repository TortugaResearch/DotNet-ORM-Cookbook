using Recipes.DbConnector.Models;
using Recipes.SingleModelCrud;

namespace Recipes.DbConnector.SingleModelCrud;

public class SingleModelCrudScenario : ScenarioBase, ISingleModelCrudScenario<EmployeeClassification>
{
    public SingleModelCrudScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

        return DbConnector.Scalar<int>(sql, classification).Execute();
    }

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, classification).Execute();
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        const string sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        DbConnector.NonQuery(sql, new { employeeClassificationKey }).Execute();
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @employeeClassificationName;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationName }).Execute();
    }

    public IList<EmployeeClassification> GetAll()
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

        return DbConnector.ReadToList<EmployeeClassification>(sql).Execute();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
    }

    public void Update(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, classification).Execute();
    }
}
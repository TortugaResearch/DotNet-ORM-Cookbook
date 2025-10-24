using Recipes.DbConnector.Models;
using Recipes.Views;

namespace Recipes.DbConnector.Views;

public class ViewsScenario : ScenarioBase, IViewsScenario<EmployeeDetail, EmployeeSimple>
{
    public ViewsScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        return DbConnector.Scalar<int>(
            @$"INSERT INTO {EmployeeSimple.TableName}
                    (
                        CellPhone,
                        EmployeeClassificationKey,
                        FirstName,
                        LastName,
                        MiddleName,
                        OfficePhone,
                        Title
                    )
                    OUTPUT Inserted.EmployeeKey
                    VALUES (
                        @{nameof(EmployeeSimple.CellPhone)},
                        @{nameof(EmployeeSimple.EmployeeClassificationKey)},
                        @{nameof(EmployeeSimple.FirstName)},
                        @{nameof(EmployeeSimple.LastName)},
                        @{nameof(EmployeeSimple.MiddleName)},
                        @{nameof(EmployeeSimple.OfficePhone)},
                        @{nameof(EmployeeSimple.Title)}
                    )"
            , employee)
            .Execute();
    }

    public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT
                    ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee
                    FROM HR.EmployeeDetail ed WHERE ed.EmployeeClassificationKey = @employeeClassificationKey";

        return DbConnector.ReadToList<EmployeeDetail>(sql, new { employeeClassificationKey }).Execute();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        const string sql = @"SELECT
            ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee
            FROM HR.EmployeeDetail ed WHERE ed.LastName = @lastName";

        return DbConnector.ReadToList<EmployeeDetail>(sql, new { lastName }).Execute();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        const string sql = @"SELECT
            ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee
            FROM HR.EmployeeDetail ed WHERE ed.EmployeeKey = @employeeKey";

        return DbConnector.ReadSingleOrDefault<EmployeeDetail>(sql, new { employeeKey }).Execute();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        const string sql = @"SELECT
            ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
            FROM HR.EmployeeClassification ec WHERE EmployeeClassificationKey = @employeeClassificationKey";

        return DbConnector.ReadSingleOrDefault<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
    }
}
using DbConnector.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DbConnector.Models;

[Table("HR.Employee")]
public class EmployeeSimple : IEmployeeSimple
{
    public readonly static string TableName = typeof(EmployeeSimple).GetAttributeValue((TableAttribute ta) => ta?.Name) ?? typeof(EmployeeSimple).Name;

    public string? CellPhone { get; set; }
    public int EmployeeClassificationKey { get; set; }

    public int EmployeeKey { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? OfficePhone { get; set; }
    public string? Title { get; set; }

    public void Refresh(EmployeeSimple copyFrom)
    {
        if (copyFrom == null)
            throw new ArgumentNullException(nameof(copyFrom), $"{nameof(copyFrom)} is null.");

        CellPhone = copyFrom.CellPhone;
        EmployeeClassificationKey = copyFrom.EmployeeClassificationKey;
        EmployeeKey = copyFrom.EmployeeKey;
        FirstName = copyFrom.FirstName;
        LastName = copyFrom.LastName;
        MiddleName = copyFrom.MiddleName;
        OfficePhone = copyFrom.OfficePhone;
        Title = copyFrom.Title;
    }
}
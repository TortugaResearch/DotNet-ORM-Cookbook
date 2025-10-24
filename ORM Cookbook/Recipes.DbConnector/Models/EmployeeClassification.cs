using DbConnector.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DbConnector.Models;

[Table("HR.EmployeeClassification")]
public class EmployeeClassification : IEmployeeClassification
{
    public readonly static string TableName = typeof(EmployeeClassification).GetAttributeValue((TableAttribute ta) => ta?.Name) ?? typeof(EmployeeClassification).Name;

    public int EmployeeClassificationKey { get; set; }

    public string? EmployeeClassificationName { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsExempt { get; set; }
}

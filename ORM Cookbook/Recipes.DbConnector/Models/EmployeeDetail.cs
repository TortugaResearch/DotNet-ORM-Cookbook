using DbConnector.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DbConnector.Models;

[Table("EmployeeDetail")]
public class EmployeeDetail : IEmployeeDetail
{
    public readonly static string TableName = typeof(EmployeeDetail).GetAttributeValue((TableAttribute ta) => ta?.Name) ?? typeof(EmployeeDetail).Name;

    public string? CellPhone { get; set; }
    public int EmployeeClassificationKey { get; set; }
    public string? EmployeeClassificationName { get; set; }
    public int EmployeeKey { get; set; }
    public string? FirstName { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsExempt { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? OfficePhone { get; set; }
    public string? Title { get; set; }
}

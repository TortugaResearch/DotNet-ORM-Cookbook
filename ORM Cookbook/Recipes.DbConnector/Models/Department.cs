using DbConnector.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.DbConnector.Models;

[Table("HR.Department")]
public class Department : IDepartment
{
    public readonly static string TableName = typeof(Department).GetAttributeValue((TableAttribute ta) => ta?.Name) ?? typeof(Department).Name;

    public int DepartmentKey { get; set; }
    public string? DepartmentName { get; set; }
    public int DivisionKey { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? CreatedByEmployeeKey { get; set; }
    public int? ModifiedByEmployeeKey { get; set; }
    public bool IsDeleted { get; set; }
}
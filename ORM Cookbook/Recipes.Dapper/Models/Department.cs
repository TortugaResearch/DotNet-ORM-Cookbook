namespace Recipes.Dapper.Models;

public class Department : IDepartment
{
    public int DepartmentKey { get; set; }
    public string? DepartmentName { get; set; }
    public int DivisionKey { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? CreatedByEmployeeKey { get; set; }
    public int? ModifiedByEmployeeKey { get; set; }
    public bool IsDeleted { get; set; }
}
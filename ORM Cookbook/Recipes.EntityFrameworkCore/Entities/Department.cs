using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.EntityFrameworkCore.Entities;

[Table("Department", Schema = "HR")]
[Index(nameof(DepartmentName), Name = "UX_Department_DepartmentName", IsUnique = true)]
public partial class Department
{
    [Key]
    public int DepartmentKey { get; set; }

    [Required]
    [StringLength(30)]
    public string DepartmentName { get; set; }

    public int DivisionKey { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? CreatedByEmployeeKey { get; set; }
    public int? ModifiedByEmployeeKey { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(CreatedByEmployeeKey))]
    [InverseProperty(nameof(Employee.DepartmentCreatedByEmployeeKeyNavigations))]
    public virtual Employee CreatedByEmployeeKeyNavigation { get; set; }

    [ForeignKey(nameof(DivisionKey))]
    [InverseProperty(nameof(Division.Departments))]
    public virtual Division DivisionKeyNavigation { get; set; }

    [ForeignKey(nameof(ModifiedByEmployeeKey))]
    [InverseProperty(nameof(Employee.DepartmentModifiedByEmployeeKeyNavigations))]
    public virtual Employee ModifiedByEmployeeKeyNavigation { get; set; }
}
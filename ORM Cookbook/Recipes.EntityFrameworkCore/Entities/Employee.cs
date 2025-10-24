using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.EntityFrameworkCore.Entities;

[Table("Employee", Schema = "HR")]
[Index(nameof(LastName), Name = "IX_Employee_LastName")]
public partial class Employee
{
    public Employee()
    {
        DepartmentCreatedByEmployeeKeyNavigations = new HashSet<Department>();
        DepartmentModifiedByEmployeeKeyNavigations = new HashSet<Department>();
        DivisionCreatedByEmployeeKeyNavigations = new HashSet<Division>();
        DivisionModifiedByEmployeeKeyNavigations = new HashSet<Division>();
    }

    [Key]
    public int EmployeeKey { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string MiddleName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [StringLength(100)]
    public string Title { get; set; }

    [StringLength(15)]
    public string OfficePhone { get; set; }

    [StringLength(15)]
    public string CellPhone { get; set; }

    public int EmployeeClassificationKey { get; set; }

    [ForeignKey(nameof(EmployeeClassificationKey))]
    [InverseProperty(nameof(EmployeeClassification.Employees))]
    public virtual EmployeeClassification EmployeeClassificationKeyNavigation { get; set; }

    [InverseProperty(nameof(Department.CreatedByEmployeeKeyNavigation))]
    public virtual ICollection<Department> DepartmentCreatedByEmployeeKeyNavigations { get; set; }

    [InverseProperty(nameof(Department.ModifiedByEmployeeKeyNavigation))]
    public virtual ICollection<Department> DepartmentModifiedByEmployeeKeyNavigations { get; set; }

    [InverseProperty(nameof(Division.CreatedByEmployeeKeyNavigation))]
    public virtual ICollection<Division> DivisionCreatedByEmployeeKeyNavigations { get; set; }

    [InverseProperty(nameof(Division.ModifiedByEmployeeKeyNavigation))]
    public virtual ICollection<Division> DivisionModifiedByEmployeeKeyNavigations { get; set; }
}
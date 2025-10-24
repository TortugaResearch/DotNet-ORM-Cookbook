using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Recipes.EntityFrameworkCore.Entities;

[Keyless]
public partial class EmployeeDetail
{
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

    [Required]
    [StringLength(30)]
    public string EmployeeClassificationName { get; set; }

    public bool IsExempt { get; set; }
    public bool IsEmployee { get; set; }
}
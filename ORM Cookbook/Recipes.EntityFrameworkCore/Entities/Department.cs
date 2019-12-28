using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFrameworkCore.Entities
{
    [Table("Department", Schema = "HR")]
    public partial class Department
    {
        [Key]
        public int DepartmentKey { get; set; }
        [Required]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public int DivisionKey { get; set; }

        [ForeignKey(nameof(DivisionKey))]
        [InverseProperty(nameof(Division.Department))]
        public virtual Division DivisionKeyNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFrameworkCore.Entities
{
    [Table("Employee", Schema = "HR")]
    public partial class Employee
    {
        [Key]
        public int EmployeeKey { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(15)]
        public string? OfficePhone { get; set; }

        [StringLength(15)]
        public string? CellPhone { get; set; }

        public int? EmployeeClassificationKey { get; set; }

        [ForeignKey(nameof(EmployeeClassificationKey))]
        [InverseProperty(nameof(EmployeeClassification.Employee))]
        public virtual EmployeeClassification? EmployeeClassificationKeyNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFrameworkCore.Entities
{
    [Table("Division", Schema = "HR")]
    public partial class Division
    {
        public Division()
        {
            Department = new HashSet<Department>();
        }

        [Key]
        public int DivisionKey { get; set; }
        [Required]
        [StringLength(30)]
        public string DivisionName { get; set; }

        [InverseProperty("DivisionKeyNavigation")]
        public virtual ICollection<Department> Department { get; set; }
    }
}

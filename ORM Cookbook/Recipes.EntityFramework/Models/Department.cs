namespace Recipes.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.Department")]
    public partial class Department
    {
        [Key]
        public int DepartmentKey { get; set; }

        [Required]
        [StringLength(30)]
        public string DepartmentName { get; set; }

        public int DivisionKey { get; set; }

        public virtual Recipes.EF.Models.Division Division { get; set; }
    }
}

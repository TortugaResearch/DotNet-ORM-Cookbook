using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFramework.Entities
{
    [Table("HR.Department")]
    public partial class Department
    {
        [Key]
        public int DepartmentKey { get; set; }

        [Required]
        [StringLength(30)]
        public string? DepartmentName { get; set; }

        public int DivisionKey { get; set; }

        public virtual Division? Division { get; set; }
    }
}

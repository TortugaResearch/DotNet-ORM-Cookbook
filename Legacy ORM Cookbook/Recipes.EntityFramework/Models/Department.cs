namespace Recipes.EF.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HR.Department")]
    public partial class Department
    {
        [Key]
        public int DepartmentKey { get; set; }

        [Required]
        [StringLength(30)]
        public string DepartmentName { get; set; }

        public int DivisionKey { get; set; }

        public Division Division { get; set; }
    }
}

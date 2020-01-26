using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFramework.Entities
{
    [Table("HR.DepartmentDetail")]
    public partial class DepartmentDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentKey { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string? DepartmentName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DivisionKey { get; set; }

        [StringLength(30)]
        public string? DivisionName { get; set; }
    }
}

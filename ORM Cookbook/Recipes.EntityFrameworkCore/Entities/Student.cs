using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFrameworkCore.Entities
{
    [Table("Student", Schema = "School")]
    public partial class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }
        
        public int SchoolId { get; set; }

        public Student()
        {
            Name = string.Empty;
            Subject = string.Empty;
        }
    }
}

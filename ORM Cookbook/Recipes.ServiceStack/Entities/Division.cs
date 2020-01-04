using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace Recipes.ServiceStack.Entities
{
    [Alias("Division")]
    [Schema("HR")]
    public class Division
    {
        [PrimaryKey, AutoIncrement] [Alias("DivisionKey")] 
        public int Id { get; set; }

        [Required] [StringLength(30)] 
        public string? DivisionName { get; set; }

        [Reference] 
        public virtual List<Department> Departments { get; } = new List<Department>();
    }
}
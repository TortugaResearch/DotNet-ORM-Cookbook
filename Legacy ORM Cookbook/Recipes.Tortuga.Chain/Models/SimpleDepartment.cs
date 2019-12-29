using Recipes.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.Models
{
    [Table("HR.Department")]
    public class SimpleDepartment : IDepartment
    {
        public int DepartmentKey { get; set; }

        public string DepartmentName { get; set; }

        public int DivisionKey { get; set; }
    }
}

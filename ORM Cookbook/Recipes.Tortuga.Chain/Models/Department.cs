using Recipes.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Tortuga.Anchor.Modeling;

namespace Recipes.Chain.Models
{
    [Table("HR.Department")]
    public class Department : IDepartment<Division>
    {
        public int DepartmentKey { get; set; }

        public string DepartmentName { get; set; }


        public int? DivisionKey
        {
            get { return Division?.DivisionKey; }
        }

        [Decompose]
        public Division Division { get; set; }
    }
}


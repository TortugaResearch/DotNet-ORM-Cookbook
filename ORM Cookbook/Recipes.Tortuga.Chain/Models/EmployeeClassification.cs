using Recipes.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.Models
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : Recipes.Models.IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        public string EmployeeClassificationName { get; set; }
    }
}

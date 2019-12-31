using Recipes.TryCrud;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Chain.TryCrud
{
    [Table("HR.EmployeeClassification")]
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}

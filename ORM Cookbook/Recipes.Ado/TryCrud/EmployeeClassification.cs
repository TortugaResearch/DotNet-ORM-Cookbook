using Recipes.TryCrud;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Ado.TryCrud
{
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}

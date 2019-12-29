using Recipes.SingleModelCrudAsync;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Dapper.SingleModelCrudAsync
{
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        /// <exclude />
        public string? EmployeeClassificationName { get; set; }
    }
}

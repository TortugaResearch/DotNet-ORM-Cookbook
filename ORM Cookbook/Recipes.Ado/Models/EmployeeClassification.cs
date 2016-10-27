using Recipes.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Ado.Models
{
    public class EmployeeClassification : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }

        public string EmployeeClassificationName { get; set; }
    }
}

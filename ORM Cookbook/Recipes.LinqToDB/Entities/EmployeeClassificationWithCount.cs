using LinqToDB.Mapping;

namespace Recipes.LinqToDB.Entities
{
    public class EmployeeClassificationWithCount : IEmployeeClassificationWithCount
    {
        [Column]
        public int EmployeeClassificationKey { get; set; }

        [Column]
        public string? EmployeeClassificationName { get; set; }

        [Column]
        public int EmployeeCount { get; set; }
    }
}

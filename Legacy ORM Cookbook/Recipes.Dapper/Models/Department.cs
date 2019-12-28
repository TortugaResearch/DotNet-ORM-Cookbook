using Recipes.Models;

namespace Recipes.Dapper.Models
{
    public class Department : IDepartment<Division>
    {
        public int DepartmentKey { get; set; }

        public string DepartmentName { get; set; }

        public Division Division { get; set; }
    }
}


using Recipes.Models;

namespace Recipes.EF.Models
{
    partial class EmployeeClassification : IEmployeeClassification
    {
    }

    partial class Department : IDepartment, IDepartment<Division>
    {

    }

    partial class Division : IDivision, IDivision<Department>
    {

    }
}

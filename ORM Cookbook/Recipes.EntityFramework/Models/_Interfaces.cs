using Recipes.Models;

namespace Recipes.EF.Models
{
    partial class Department : IDepartment
    {

    }

    partial class Department : IDepartment<Division>
    {

    }

    partial class Division : IDivision
    {

    }

    partial class Division : IDivision<Department>
    {

    }

    partial class EmployeeClassification : IEmployeeClassification
    {
    }
}

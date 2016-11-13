using System.Collections.Generic;

namespace Recipes.Models
{
    public interface IDivision<TDepartment>
            where TDepartment : IDepartment
    {
        int DivisionKey { get; set; }
        string DivisionName { get; set; }

        ICollection<TDepartment> Departments { get; }
    }
}

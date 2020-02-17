using System;

namespace Recipes
{
    public interface IDepartment
    {
        int DepartmentKey { get; set; }
        string? DepartmentName { get; set; }
        int DivisionKey { get; set; }

        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? CreatedByEmployeeKey { get; set; }
        int? ModifiedByEmployeeKey { get; set; }
        bool IsDeleted { get; set; }
    }
}

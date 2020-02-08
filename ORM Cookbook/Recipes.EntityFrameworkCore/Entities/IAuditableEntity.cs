using System;

namespace Recipes.EntityFrameworkCore.Entities
{
    public interface IAuditableEntity
    {
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? CreatedByEmployeeKey { get; set; }
        int? ModifiedByEmployeeKey { get; set; }
    }
}

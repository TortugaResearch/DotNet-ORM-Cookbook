namespace Recipes.EntityFramework.Entities;

public interface IAuditableEntity
{
    DateTime? CreatedDate { get; set; }
    DateTime? ModifiedDate { get; set; }
    int? CreatedByEmployeeKey { get; set; }
    int? ModifiedByEmployeeKey { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.PartialUpdate;

/// <summary>
/// This class is used to hold the fields used for a partial update.
/// </summary>
[Table("HR.EmployeeClassification")]
public class EmployeeClassificationNameUpdater
{
    public int EmployeeClassificationKey { get; set; }
    public string? EmployeeClassificationName { get; set; }
}
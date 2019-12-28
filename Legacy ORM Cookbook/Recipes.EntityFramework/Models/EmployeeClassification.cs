namespace Recipes.EF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

[Table("HR.EmployeeClassification")]
public partial class EmployeeClassification
{

    [Key]
    public int EmployeeClassificationKey { get; set; }

    [StringLength(30)]
    public string EmployeeClassificationName { get; set; }

}
}

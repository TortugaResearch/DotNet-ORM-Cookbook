using DevExpress.Xpo;
using System;
namespace Recipes.Xpo.Entities
{

    [NonPersistent]
    public partial class GetEmployeeClassificationsResult : IEmployeeClassification
    {
        public int EmployeeClassificationKey { get; set; }
        public string? EmployeeClassificationName { get; set; }
        public bool IsExempt { get; set; }
        public bool IsEmployee { get; set; }
    }

}

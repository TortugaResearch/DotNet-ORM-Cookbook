using System;
using DevExpress.Xpo;

namespace Recipes.Xpo.Entities
{

    [NonPersistent]
    public partial class CountEmployeesByClassificationResult : IEmployeeClassificationWithCount
    {
        public int EmployeeCount { get; set; }
        public int EmployeeClassificationKey { get; set; }
        public string? EmployeeClassificationName { get; set; }
    }

}

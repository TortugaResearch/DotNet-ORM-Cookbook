using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.ServiceStack.Entities
{
    public class EmployeeClassificationWithCount : IEmployeeClassificationWithCount
    {
        public int EmployeeClassificationKey { get; set; }
        public string? EmployeeClassificationName { get; set; }
        public int EmployeeCount { get; set; }
    }
}

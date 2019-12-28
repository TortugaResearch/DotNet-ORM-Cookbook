using System;
using System.Collections.Generic;

namespace Recipes.EntityFrameworkCore.Entities
{
    public partial class EmployeeClassification
    {
        public EmployeeClassification()
        {
            Employee = new HashSet<Employee>();
        }

        public int EmployeeClassificationKey { get; set; }
        public string EmployeeClassificationName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}

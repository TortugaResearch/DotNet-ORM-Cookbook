using System;
using System.Collections.Generic;

namespace Recipes.EntityFrameworkCore.Entities
{
    public partial class Division
    {
        public Division()
        {
            Department = new HashSet<Department>();
        }

        public int DivisionKey { get; set; }
        public string DivisionName { get; set; }

        public virtual ICollection<Department> Department { get; set; }
    }
}

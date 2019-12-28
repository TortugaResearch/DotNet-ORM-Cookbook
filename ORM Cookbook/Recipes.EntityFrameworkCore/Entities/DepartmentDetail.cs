using System;
using System.Collections.Generic;

namespace Recipes.EntityFrameworkCore.Entities
{
    public partial class DepartmentDetail
    {
        public int DepartmentKey { get; set; }
        public string DepartmentName { get; set; }
        public int DivisionKey { get; set; }
        public string DivisionName { get; set; }
    }
}

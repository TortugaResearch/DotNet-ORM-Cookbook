using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.EntityFrameworkCore.Entities
{
    public partial class DepartmentDetail
    {
        public int DepartmentKey { get; set; }
        [Required]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public int DivisionKey { get; set; }
        [StringLength(30)]
        public string DivisionName { get; set; }
    }
}

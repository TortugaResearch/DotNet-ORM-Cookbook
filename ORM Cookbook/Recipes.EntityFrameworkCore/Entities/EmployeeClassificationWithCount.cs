using Microsoft.Data.SqlClient;
using System;

namespace Recipes.EntityFrameworkCore.Entities
{
    public class EmployeeClassificationWithCount : IEmployeeClassificationWithCount
    {
        public int EmployeeClassificationKey { get; set; }
        public string? EmployeeClassificationName { get; set; }
        public int EmployeeCount { get; set; }
    }
}

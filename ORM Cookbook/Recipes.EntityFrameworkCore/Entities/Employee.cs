using System;
using System.Collections.Generic;

namespace Recipes.EntityFrameworkCore.Entities
{
    public partial class Employee
    {
        public int EmployeeKey { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string OfficePhone { get; set; }
        public string CellPhone { get; set; }
        public int? EmployeeClassificationKey { get; set; }

        public virtual EmployeeClassification EmployeeClassificationKeyNavigation { get; set; }
    }
}

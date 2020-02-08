using System;
using Dapper.Contrib.Extensions;

namespace Recipes.Dapper.Models
{
    [Table("HR.Employee")]
    public class EmployeeSimple : IEmployeeSimple
    {
        //Table and Key attributes are only used by Dapper.Contrib.
        //They are not needed in the Dapper-only examples.

        public string? CellPhone { get; set; }
        public int EmployeeClassificationKey { get; set; }

        [Key]
        public int EmployeeKey { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? OfficePhone { get; set; }
        public string? Title { get; set; }

        public void Refresh(EmployeeSimple copyFrom)
        {
            if (copyFrom == null)
                throw new ArgumentNullException(nameof(copyFrom), $"{nameof(copyFrom)} is null.");

            CellPhone = copyFrom.CellPhone;
            EmployeeClassificationKey = copyFrom.EmployeeClassificationKey;
            EmployeeKey = copyFrom.EmployeeKey;
            FirstName = copyFrom.FirstName;
            LastName = copyFrom.LastName;
            MiddleName = copyFrom.MiddleName;
            OfficePhone = copyFrom.OfficePhone;
            Title = copyFrom.Title;
        }
    }
}

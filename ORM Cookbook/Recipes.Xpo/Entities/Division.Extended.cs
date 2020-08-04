using DevExpress.Xpo;
using System;

namespace Recipes.Xpo.Entities
{
    public partial class Division : IDivision
    {

        public Division() : base() { }

        int IDivision.CreatedByEmployeeKey
        {
            get => CreatedByEmployee.EmployeeKey;
            set => CreatedByEmployee = Session.GetObjectByKey<Employee>(value);
        }
        int IDivision.ModifiedByEmployeeKey
        {
            get => ModifiedByEmployee.EmployeeKey;
            set => ModifiedByEmployee = Session.GetObjectByKey<Employee>(value);
        }
    }
}

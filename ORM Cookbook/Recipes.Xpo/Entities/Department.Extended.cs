using DevExpress.Xpo;
using System;

namespace Recipes.Xpo.Entities
{
    public partial class Department : IDepartment
    {
        public Department() : base() { }

        static User? GetCurrentUser()
        {
            return SecuritySystem.CurrentUser ?? null;
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            CreatedDate = DateTime.Now;
            CreatedByEmployeeKey = GetCurrentUser()?.UserKey;
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            ModifiedDate = DateTime.Now;
            ModifiedByEmployeeKey = GetCurrentUser()?.UserKey;
        }

        [NonPersistent]
        public int DivisionKey
        {
            get => Division.DivisionKey;
            set => Division = Session.GetObjectByKey<Division>(value);
        }
        [NonPersistent]
        public int? CreatedByEmployeeKey
        {
            get => CreatedByEmployee?.EmployeeKey ?? 0;
            set => CreatedByEmployee = Session.GetObjectByKey<Employee>(value);
        }
        [NonPersistent]
        public int? ModifiedByEmployeeKey
        {
            get => ModifiedByEmployee?.EmployeeKey ?? 0;
            set => ModifiedByEmployee = Session.GetObjectByKey<Employee>(value);
        }
        [NonPersistent]
        bool IDepartment.IsDeleted
        {
            get => IsDeleted1;
            set => IsDeleted1 = value;
        }
    }
}

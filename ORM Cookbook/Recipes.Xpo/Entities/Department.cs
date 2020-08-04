using System;
using DevExpress.Xpo;

namespace Recipes.Xpo.Entities
{

    [Persistent(@"HR.Department")]
    public partial class Department : XPLiteObject
    {
        int fDepartmentKey;
        [Key(true)]
        public int DepartmentKey
        {
            get { return fDepartmentKey; }
            set { SetPropertyValue<int>(nameof(DepartmentKey), ref fDepartmentKey, value); }
        }
        string? fDepartmentName;
        [Indexed(Name = @"UX_Department_DepartmentName", Unique = true)]
        [Size(30)]
        public string? DepartmentName
        {
            get { return fDepartmentName; }
            set { SetPropertyValue<string?>(nameof(DepartmentName), ref fDepartmentName, value); }
        }
        Division fDivision;
        [Association(@"DepartmentReferencesDivision")]
        [Persistent(@"DivisionKey")]
        public Division Division
        {
            get { return fDivision; }
            set { SetPropertyValue<Division>(nameof(Division), ref fDivision, value); }
        }
        DateTime? fCreatedDate;
        public DateTime? CreatedDate
        {
            get { return fCreatedDate; }
            set { SetPropertyValue<DateTime?>(nameof(CreatedDate), ref fCreatedDate, value); }
        }
        DateTime? fModifiedDate;
        public DateTime? ModifiedDate
        {
            get { return fModifiedDate; }
            set { SetPropertyValue<DateTime?>(nameof(ModifiedDate), ref fModifiedDate, value); }
        }
        Employee? fCreatedByEmployee;
        [Association(@"DepartmentReferencesEmployee")]
        [Persistent("CreatedByEmployeeKey")]
        public Employee? CreatedByEmployee
        {
            get { return fCreatedByEmployee; }
            set { SetPropertyValue<Employee?>(nameof(CreatedByEmployee), ref fCreatedByEmployee, value); }
        }
        Employee? fModifiedByEmployee;
        [Association(@"DepartmentReferencesEmployee1")]
        [Persistent("ModifiedByEmployeeKey")]
        public Employee? ModifiedByEmployee
        {
            get { return fModifiedByEmployee; }
            set { SetPropertyValue<Employee?>(nameof(ModifiedByEmployee), ref fModifiedByEmployee, value); }
        }
        bool fIsDeleted1;
        [Persistent(@"IsDeleted")]
        [ColumnDbDefaultValue("((0))")]
        public bool IsDeleted1
        {
            get { return fIsDeleted1; }
            set { SetPropertyValue<bool>(nameof(IsDeleted1), ref fIsDeleted1, value); }
        }
        public Department(Session session) : base(session) { }
    }

}

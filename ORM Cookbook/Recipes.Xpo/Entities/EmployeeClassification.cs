using System;
using DevExpress.Xpo;

namespace Recipes.Xpo.Entities
{

    [Persistent(@"HR.EmployeeClassification")]
    public partial class EmployeeClassification : XPLiteObject
    {
        int fEmployeeClassificationKey;
        [Key(true)]
        public int EmployeeClassificationKey
        {
            get { return fEmployeeClassificationKey; }
            set { SetPropertyValue<int>(nameof(EmployeeClassificationKey), ref fEmployeeClassificationKey, value); }
        }
        string? fEmployeeClassificationName;
        [Indexed(Name = @"UX_EmployeeClassification_EmployeeClassificationName", Unique = true)]
        [Size(30)]
        public string? EmployeeClassificationName
        {
            get { return fEmployeeClassificationName; }
            set { SetPropertyValue<string?>(nameof(EmployeeClassificationName), ref fEmployeeClassificationName, value); }
        }
        bool fIsExempt;
        [ColumnDbDefaultValue("((0))")]
        public bool IsExempt
        {
            get { return fIsExempt; }
            set { SetPropertyValue<bool>(nameof(IsExempt), ref fIsExempt, value); }
        }
        bool fIsEmployee;
        [ColumnDbDefaultValue("((1))")]
        public bool IsEmployee
        {
            get { return fIsEmployee; }
            set { SetPropertyValue<bool>(nameof(IsEmployee), ref fIsEmployee, value); }
        }
        [Association(@"EmployeeReferencesEmployeeClassification")]
        public XPCollection<Employee> Employees { get { return GetCollection<Employee>(nameof(Employees)); } }
        public EmployeeClassification(Session session) : base(session) { }
    }

}

using DevExpress.Xpo;
using System;
namespace Recipes.Xpo.Entities
{

    [Persistent(@"HR.Employee")]
    public partial class Employee : XPLiteObject
    {
        int fEmployeeKey;
        [Key(true)]
        public int EmployeeKey
        {
            get { return fEmployeeKey; }
            set { SetPropertyValue<int>(nameof(EmployeeKey), ref fEmployeeKey, value); }
        }
        string? fFirstName;
        [Size(50)]
        public string? FirstName
        {
            get { return fFirstName; }
            set { SetPropertyValue<string?>(nameof(FirstName), ref fFirstName, value); }
        }
        string? fMiddleName;
        [Size(50)]
        public string? MiddleName
        {
            get { return fMiddleName; }
            set { SetPropertyValue<string?>(nameof(MiddleName), ref fMiddleName, value); }
        }
        string? fLastName;
        [Indexed(Name = @"IX_Employee_LastName")]
        [Size(50)]
        public string? LastName
        {
            get { return fLastName; }
            set { SetPropertyValue<string?>(nameof(LastName), ref fLastName, value); }
        }
        string? fTitle;
        public string? Title
        {
            get { return fTitle; }
            set { SetPropertyValue<string?>(nameof(Title), ref fTitle, value); }
        }
        string? fOfficePhone;
        [Size(15)]
        public string? OfficePhone
        {
            get { return fOfficePhone; }
            set { SetPropertyValue<string?>(nameof(OfficePhone), ref fOfficePhone, value); }
        }
        string? fCellPhone;
        [Size(15)]
        public string? CellPhone
        {
            get { return fCellPhone; }
            set { SetPropertyValue<string?>(nameof(CellPhone), ref fCellPhone, value); }
        }
        EmployeeClassification fEmployeeClassification;
        [Association(@"EmployeeReferencesEmployeeClassification")]
        [Persistent("EmployeeClassificationKey")]
        public EmployeeClassification EmployeeClassification
        {
            get { return fEmployeeClassification; }
            set { SetPropertyValue<EmployeeClassification>(nameof(EmployeeClassification), ref fEmployeeClassification, value); }
        }
        [Association(@"DepartmentReferencesEmployee")]
        public XPCollection<Department> Departments { get { return GetCollection<Department>(nameof(Departments)); } }
        [Association(@"DepartmentReferencesEmployee1")]
        public XPCollection<Department> Departments1 { get { return GetCollection<Department>(nameof(Departments1)); } }
        [Association(@"DivisionReferencesEmployee")]
        public XPCollection<Division> Divisions { get { return GetCollection<Division>(nameof(Divisions)); } }
        [Association(@"DivisionReferencesEmployee1")]
        public XPCollection<Division> Divisions1 { get { return GetCollection<Division>(nameof(Divisions1)); } }

        public Employee(Session session) : base(session) { }
    }

}

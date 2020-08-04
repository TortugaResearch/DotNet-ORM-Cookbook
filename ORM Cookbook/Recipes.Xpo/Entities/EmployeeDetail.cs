using DevExpress.Xpo;

namespace Recipes.Xpo.Entities
{

    [Persistent("HR.EmployeeDetail")]
    public partial class EmployeeDetail : XPLiteObject
    {
        int fEmployeeKey;
        [Key]
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
        int fEmployeeClassificationKey;
        public int EmployeeClassificationKey
        {
            get { return fEmployeeClassificationKey; }
            set { SetPropertyValue<int>(nameof(EmployeeClassificationKey), ref fEmployeeClassificationKey, value); }
        }
        string? fEmployeeClassificationName;
        [Size(30)]
        public string? EmployeeClassificationName
        {
            get { return fEmployeeClassificationName; }
            set { SetPropertyValue<string?>(nameof(EmployeeClassificationName), ref fEmployeeClassificationName, value); }
        }
        bool fIsExempt;
        public bool IsExempt
        {
            get { return fIsExempt; }
            set { SetPropertyValue<bool>(nameof(IsExempt), ref fIsExempt, value); }
        }
        bool fIsEmployee;
        public bool IsEmployee
        {
            get { return fIsEmployee; }
            set { SetPropertyValue<bool>(nameof(IsEmployee), ref fIsEmployee, value); }
        }
        public EmployeeDetail(Session session) : base(session) { }
    }

}


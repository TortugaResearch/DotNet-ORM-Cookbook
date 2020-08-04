using System;
using DevExpress.Xpo;

namespace Recipes.Xpo.Entities
{

    [Persistent]
    public partial class DepartmentDetail : XPLiteObject
    {
        int fDepartmentKey;
        public int DepartmentKey
        {
            get { return fDepartmentKey; }
            set { SetPropertyValue<int>(nameof(DepartmentKey), ref fDepartmentKey, value); }
        }
        string fDepartmentName;
        [Size(30)]
        public string DepartmentName
        {
            get { return fDepartmentName; }
            set { SetPropertyValue<string>(nameof(DepartmentName), ref fDepartmentName, value); }
        }
        int fDivisionKey;
        public int DivisionKey
        {
            get { return fDivisionKey; }
            set { SetPropertyValue<int>(nameof(DivisionKey), ref fDivisionKey, value); }
        }
        string fDivisionName;
        [Size(30)]
        public string DivisionName
        {
            get { return fDivisionName; }
            set { SetPropertyValue<string>(nameof(DivisionName), ref fDivisionName, value); }
        }
        public DepartmentDetail(Session session) : base(session) { }
    }

}

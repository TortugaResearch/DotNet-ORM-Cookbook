using DevExpress.Xpo;


namespace Recipes.Xpo.Entities
{
    public partial class Employee : IEmployeeSimple
    {
        public Employee() : base()
        {

        }

        [PersistentAlias("EmployeeClassification.EmployeeClassificationKey")]
        public int EmployeeClassificationKey
        {
            get => EmployeeClassification?.EmployeeClassificationKey ?? 0;
            set => EmployeeClassification = Session.GetObjectByKey<EmployeeClassification>(value);
        }
    }

    partial class Employee : IEmployeeComplex
    {
        IReadOnlyEmployeeClassification? IEmployeeComplex.EmployeeClassification
        {
            get => EmployeeClassification;
            set => EmployeeClassification = Session.GetObjectByKey<EmployeeClassification>(value?.EmployeeClassificationKey);
        }
    }
}

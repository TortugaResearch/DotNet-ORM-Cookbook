using LinqToDB;
using LinqToDB.Data;

namespace Recipes.LinqToDB.Entities
{
    public class OrmCookbook : DataConnection
    {
        public OrmCookbook() : base("OrmCookbook")
        {
        }

        public ITable<Department> Department => this.GetTable<Department>();
        public ITable<DepartmentDetail> DepartmentDetail => this.GetTable<DepartmentDetail>();
        public ITable<Division> Division => this.GetTable<Division>();
        public ITable<Product> DivisionClassification => this.GetTable<Product>();
        public ITable<Employee> Employee => this.GetTable<Employee>();
        public ITable<EmployeeClassification> EmployeeClassification => this.GetTable<EmployeeClassification>();
        public ITable<EmployeeDetail> EmployeeDetail => this.GetTable<EmployeeDetail>();
        public ITable<Product> Product => this.GetTable<Product>();
        public ITable<ProductLine> ProductLine => this.GetTable<ProductLine>();
    }
}

using LinqToDB;
using LinqToDB.Data;

namespace Recipes.LinqToDB.Entities
{
    public class OrmCookbook : DataConnection
    {
        public OrmCookbook() : base("OrmCookbook")
        {
        }

        public ITable<Department> Department => GetTable<Department>();
        public ITable<DepartmentDetail> DepartmentDetail => GetTable<DepartmentDetail>();
        public ITable<Division> Division => GetTable<Division>();
        public ITable<Product> DivisionClassification => GetTable<Product>();
        public ITable<Employee> Employee => GetTable<Employee>();
        public ITable<EmployeeClassification> EmployeeClassification => GetTable<EmployeeClassification>();
        public ITable<EmployeeDetail> EmployeeDetail => GetTable<EmployeeDetail>();
        public ITable<Product> Product => GetTable<Product>();
        public ITable<ProductLine> ProductLine => GetTable<ProductLine>();
    }
}

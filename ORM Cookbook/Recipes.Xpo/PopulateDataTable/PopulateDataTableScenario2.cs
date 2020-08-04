using Recipes.Xpo.Entities;
using Recipes.PopulateDataTable;
using System.Data;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Recipes.Xpo.PopulateDataTable {
    public class PopulateDataTableScenario2 : IPopulateDataTableScenario {

        public DataTable FindByFlags(bool isExempt, bool isEmployee) {
            var classInfo = Session.DefaultSession.GetClassInfo<EmployeeClassification>();

            var dt = BuildGenericDataTable(classInfo);
            using(var uow = new UnitOfWork()) {
                var buffer = new object[classInfo.Table.Columns.Count];
                foreach(var row in uow.Query<EmployeeClassification>().Where(x => x.IsExempt == isExempt && x.IsEmployee == isEmployee)) {
                    for(var i = 0; i < classInfo.Table.Columns.Count; i++)
                        buffer[i] = row.GetMemberValue(classInfo.Table.Columns[i].Name);

                    dt.Rows.Add(buffer);
                }
            }
            return dt;
        }

        public DataTable GetAll() {
            var classInfo = Session.DefaultSession.GetClassInfo<EmployeeClassification>();

            var dt = BuildGenericDataTable(classInfo);

            using(var uow = new UnitOfWork()) {
                var buffer = new object[classInfo.Table.Columns.Count];
                foreach(var row in uow.Query<EmployeeClassification>()) {
                    for(var i = 0; i < classInfo.Table.Columns.Count; i++)
                        buffer[i] = row.GetMemberValue(classInfo.Table.Columns[i].Name);

                    dt.Rows.Add(buffer);
                }
            }
            return dt;
        }

        static DataTable BuildGenericDataTable(XPClassInfo classInfo) {
            var dt = new DataTable();
            for(int i = 0; i < classInfo.Table.Columns.Count; i++) {
                var dbColumn = classInfo.Table.Columns[i];
                var memberInfo = classInfo.GetPersistentMember(dbColumn.Name); 
                var col = dt.Columns.Add(dbColumn.Name, memberInfo.MemberType);
                col.AllowDBNull = dbColumn.IsNullable;
            }
            return dt;
        }
    }
}

using Recipes.DiscoverTablesAndColumns;
using Recipes.LinqToDB.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LinqToDB.DiscoverTablesAndColumns
{
    public class DiscoverTablesAndColumnsScenario : IDiscoverTablesAndColumnsScenario
    {
        public IList<string> ListColumnsInTable(string schemaName, string tableName)
        {
            using (var db = new OrmCookbook())
            {
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db);
                var table = dbSchema.Tables.Single(t => t.SchemaName == schemaName && t.TableName == tableName);
                return table.Columns.Select(c => c.ColumnName).ToList();
            }
        }

        public IList<string> ListColumnsInView(string schemaName, string viewName)
        {
            using (var db = new OrmCookbook())
            {
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db);
                var view = dbSchema.Tables.Single(t => t.SchemaName == schemaName && t.TableName == viewName);
                return view.Columns.Select(c => c.ColumnName).ToList();
            }
        }

        public IList<string> ListTables()
        {
            using (var db = new OrmCookbook())
            {
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db);
                return dbSchema.Tables.Where(t => !t.IsView).Select(t => t.SchemaName + "." + t.TableName).ToList();
            }
        }

        public IList<string> ListViews()
        {
            using (var db = new OrmCookbook())
            {
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db);
                return dbSchema.Tables.Where(t => t.IsView).Select(t => t.SchemaName + "." + t.TableName).ToList();
            }
        }
    }
}

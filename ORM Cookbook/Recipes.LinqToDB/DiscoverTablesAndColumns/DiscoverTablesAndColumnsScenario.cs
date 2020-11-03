using LinqToDB.SchemaProvider;
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
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db,
                    new GetSchemaOptions()
                    {
                        IncludedSchemas = new[] { schemaName },
                        GetForeignKeys = false,
                        GetProcedures = false,
                        GetTables = true,
                        LoadTable = (t) => t.Schema == schemaName && t.Name == tableName
                    });
                return dbSchema.Tables.Single().Columns.Select(c => c.ColumnName).ToList();
            }
        }

        public IList<string> ListColumnsInView(string schemaName, string viewName)
        {
            using (var db = new OrmCookbook())
            {
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db,
                    new GetSchemaOptions()
                    {
                        IncludedSchemas = new[] { schemaName },
                        GetForeignKeys = false,
                        GetProcedures = false,
                        GetTables = true,
                        LoadTable = (t) => t.Schema == schemaName && t.Name == viewName
                    });
                return dbSchema.Tables.Single().Columns.Select(c => c.ColumnName).ToList();
            }
        }

        public IList<string> ListTables()
        {
            using (var db = new OrmCookbook())
            {
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db,
                    new GetSchemaOptions()
                    {
                        GetForeignKeys = false,
                        GetProcedures = false,
                        GetTables = true,
                        LoadTable = (t) => !t.IsView
                    });
                return dbSchema.Tables.Select(t => t.SchemaName + "." + t.TableName).ToList();
            }
        }

        public IList<string> ListViews()
        {
            using (var db = new OrmCookbook())
            {
                var dbSchema = db.DataProvider.GetSchemaProvider().GetSchema(db,
                    new GetSchemaOptions()
                    {
                        GetForeignKeys = false,
                        GetProcedures = false,
                        GetTables = true,
                        LoadTable = (t) => t.IsView
                    });
                return dbSchema.Tables.Select(t => t.SchemaName + "." + t.TableName).ToList();
            }
        }
    }
}

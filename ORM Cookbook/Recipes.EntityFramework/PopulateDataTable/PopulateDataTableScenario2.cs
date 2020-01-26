using Recipes.EntityFramework.Entities;
using Recipes.PopulateDataTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tortuga.Anchor.Metadata;

namespace Recipes.EntityFramework.PopulateDataTable
{
    public class PopulateDataTableScenario2 : IPopulateDataTableScenario
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public PopulateDataTableScenario2(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public DataTable FindByFlags(bool isExempt, bool isEmployee)
        {
            var propertyList = MetadataCache.GetMetadata<EmployeeClassification>().Properties.Where(p => p.CanRead).ToList();

            var dt = BuildGenericDataTable(propertyList);

            using (var context = CreateDbContext())
            {
                var buffer = new object[propertyList.Count];
                foreach (var row in context.EmployeeClassification.Where(x => x.IsExempt == isExempt && x.IsEmployee == isEmployee))
                {
                    for (var i = 0; i < propertyList.Count; i++)
                        buffer[i] = propertyList[i].InvokeGet(row) ?? DBNull.Value;

                    dt.Rows.Add(buffer);
                }
            }
            return dt;
        }

        public DataTable GetAll()
        {
            var propertyList = MetadataCache.GetMetadata<EmployeeClassification>().Properties.Where(p => p.CanRead).ToList();

            var dt = BuildGenericDataTable(propertyList);

            using (var context = CreateDbContext())
            {
                var buffer = new object[propertyList.Count];
                foreach (var row in context.EmployeeClassification)
                {
                    for (var i = 0; i < propertyList.Count; i++)
                        buffer[i] = propertyList[i].InvokeGet(row) ?? DBNull.Value;

                    dt.Rows.Add(buffer);
                }
            }
            return dt;
        }

        static DataTable BuildGenericDataTable(List<PropertyMetadata> propertyList)
        {
            var dt = new DataTable();
            foreach (var property in propertyList)
            {
                var propertyType = MetadataCache.GetMetadata(property.PropertyType);
                if (propertyType.IsNullable && propertyType.TypeInfo.IsValueType) //Special handling for Nullable<T>
                {
                    var underlyingType = propertyType.TypeInfo.GenericTypeArguments[0];
                    var col = dt.Columns.Add(property.Name, underlyingType);
                    col.AllowDBNull = true;
                }
                else
                {
                    var col = dt.Columns.Add(property.Name, property.PropertyType);
                    col.AllowDBNull = property.IsReferenceNullable ?? propertyType.IsNullable;
                }
            }

            return dt;
        }
    }
}

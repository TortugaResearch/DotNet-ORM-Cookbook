using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.NHibernate
{
    [SuppressMessage("Design", "CA1001")]
    public class DataTableResultTransformer : IResultTransformer
    {
        readonly DataTable m_DataTable = new DataTable();
        readonly Type?[] m_DataTypeOverrides = Array.Empty<Type?>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableResultTransformer"/> class.
        ///
        /// Only use this constructor if none of the columns are nullable.
        /// </summary>
        /// <remarks>Warning: If a field is NULL in the first row, that entire column will be cast as a String.</remarks>
        public DataTableResultTransformer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableResultTransformer"/> class.
        ///
        /// 1. If dataTypeOverrides for a given column is not null, it is used.
        /// 2. If the field is not null for the first row, then that field's data type if used.
        /// 3. If both the dataTypeOverride and the field in the first row are null, the column's data type is String.
        /// </summary>
        /// <param name="dataTypeOverrides">The expected data types.</param>
        public DataTableResultTransformer(params Type?[] dataTypeOverrides)
        {
            m_DataTypeOverrides = dataTypeOverrides;
        }

        public IList TransformList(IList collection)
        {
            return new List<DataTable> { m_DataTable };
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
            if (tuple == null || tuple.Length == 0)
                throw new ArgumentException($"{nameof(tuple)} is null or empty.", nameof(tuple));

            if (aliases == null || aliases.Length == 0)
                throw new ArgumentException($"{nameof(aliases)} is null or empty.", nameof(aliases));

            if (m_DataTable.Columns.Count == 0)
            {
                //Create the DataTable if this is the first row
                for (var i = 0; i < aliases.Length; i++)
                {
                    var col = m_DataTable.Columns.Add(aliases[i]);
                    if (i < m_DataTypeOverrides.Length && m_DataTypeOverrides[i] != null)
                        col.DataType = m_DataTypeOverrides[i]!;
                    else if (tuple[i] != null && tuple[i] != DBNull.Value)
                        col.DataType = tuple[i].GetType();
                }
            }

            return m_DataTable.Rows.Add(tuple);
        }
    }
}

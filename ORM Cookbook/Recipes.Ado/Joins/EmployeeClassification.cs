using Recipes.Joins;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Recipes.Ado.Joins
{
    public class EmployeeClassification : IEmployeeClassification
    {
        public EmployeeClassification(IDataReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader), $"{nameof(reader)} is null.");

            EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey"));
            EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"));
            IsExempt = reader.GetBoolean(reader.GetOrdinal("IsExempt"));
            IsEmployee = reader.GetBoolean(reader.GetOrdinal("IsEmployee"));
        }

        public int EmployeeClassificationKey { get; set; }
        public string? EmployeeClassificationName { get; set; }
        public bool IsExempt { get; set; }
        public bool IsEmployee { get; set; }
    }
}

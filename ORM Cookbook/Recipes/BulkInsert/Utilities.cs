using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.BulkInsert;

public static class Utilities
{
    [SuppressMessage("Design", "CA1000")]
    public static DataTable CopyToDataTable(IEnumerable<IEmployeeSimple> employees)
    {
        if (employees == null || !employees.Any())
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        var result = new DataTable();
        result.Columns.Add("CellPhone", typeof(string));
        result.Columns.Add("EmployeeClassificationKey", typeof(int));
        result.Columns.Add("FirstName", typeof(string));
        result.Columns.Add("MiddleName", typeof(string));
        result.Columns.Add("LastName", typeof(string));
        result.Columns.Add("OfficePhone", typeof(string));
        result.Columns.Add("Title", typeof(string));

        foreach (var employee in employees)
        {
            var row = result.NewRow();
            row["CellPhone"] = employee.CellPhone;
            row["EmployeeClassificationKey"] = employee.EmployeeClassificationKey;
            row["FirstName"] = employee.FirstName;
            row["MiddleName"] = employee.MiddleName;
            row["LastName"] = employee.LastName;
            row["OfficePhone"] = employee.OfficePhone;
            row["Title"] = employee.Title;

            result.Rows.Add(row);
        }

        return result;
    }
}
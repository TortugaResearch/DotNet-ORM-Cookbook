using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Recipes.EntityFrameworkCore.Entities.Conventions;

/// <summary>
/// CaseConventionConverter allows one DBContext to connect to multiple databases that using
/// differ only in naming conventions.
/// </summary>
public abstract class CaseConventionConverter : IDatabaseConventionConverter
{
    public void SetConvention(ModelBuilder builder)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder), $"{nameof(builder)} is null.");

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Replace table names
            entity.SetTableName(ConvertName(entity.GetTableName()));
            entity.SetSchema(ConvertName(entity.GetSchema()));

            var soi = StoreObjectIdentifier.Table(entity.GetTableName(), entity.GetSchema());
            System.Diagnostics.Debug.WriteLine($"Remapping table {entity.GetSchema()}.{entity.GetTableName()}");
            System.Diagnostics.Debug.IndentLevel += 1;

            // Replace column names
            foreach (var property in entity.GetProperties())
                property.SetColumnName(ConvertName(property.GetColumnName(soi)), soi);

            foreach (var key in entity.GetKeys())
                key.SetName(ConvertName(key.GetName()));

            foreach (var key in entity.GetForeignKeys())
                key.SetConstraintName(ConvertName(key.GetConstraintName()));

            foreach (var key in entity.GetIndexes())
                key.SetDatabaseName(ConvertName(key.GetDatabaseName()));
        }
    }

    protected abstract string? ConvertName(string? input);
}
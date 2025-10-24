using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Recipes.EntityFrameworkCore.Entities.Conventions;

/// <summary>
/// SnakeCaseConverter is used in database where table/columns use the "table_name" convention.
/// </summary>
public sealed class SnakeCaseConverter : CaseConventionConverter
{
    //Based on: https://github.com/avi1989/DbContextForMultipleDatabases, Used with permission.
    //Reference: https://andrewlock.net/customising-asp-net-core-identity-ef-core-naming-conventions-for-postgresql/

    [SuppressMessage("Globalization", "CA1308")]
    [return: NotNullIfNotNull("input")]
    protected override string? ConvertName(string? input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var startUnderscores = Regex.Match(input, @"^_+");
        return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLowerInvariant();
    }
}
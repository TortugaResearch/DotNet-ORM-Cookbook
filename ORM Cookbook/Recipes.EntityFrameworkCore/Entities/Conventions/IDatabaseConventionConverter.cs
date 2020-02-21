using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Recipes.EntityFrameworkCore.Entities.Conventions
{
    public interface IDatabaseConventionConverter

    {
        void SetConvention(ModelBuilder modelBuilder);
    }
}

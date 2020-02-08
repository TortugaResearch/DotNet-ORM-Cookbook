using System;

namespace Recipes.EntityFrameworkCore.Entities
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}

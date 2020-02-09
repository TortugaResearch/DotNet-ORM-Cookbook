using System;

namespace Recipes.EntityFramework.Entities
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}

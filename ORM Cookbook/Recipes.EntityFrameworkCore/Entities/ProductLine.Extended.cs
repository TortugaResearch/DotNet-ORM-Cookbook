namespace Recipes.EntityFrameworkCore.Entities;

//Used for linking the entity to the test framework. Not part of the recipe.
partial class ProductLine : IProductLine<Product>
{
    ICollection<Product> IProductLine<Product>.Products => Products;
}
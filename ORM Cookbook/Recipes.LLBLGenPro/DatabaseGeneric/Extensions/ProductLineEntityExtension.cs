using Recipes;
using System.Collections.Generic;

namespace LLBLGenPro.OrmCookbook.EntityClasses
{
	public partial class ProductLineEntity
	{
		ICollection<ProductEntity> IProductLine<ProductEntity>.Products
		{
			get { return this.Products; }
		}
	}
}
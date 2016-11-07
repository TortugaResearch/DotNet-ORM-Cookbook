using System;
using LLBLGenPro.OrmCookbook.EntityClasses;
using Recipes.LLBLGenPro.Repositories;
using Recipes.UseCases;

namespace Recipes.LLBLGenPro
{
	public class ModelWithSingleChildLinq : ModelWithSingleChild<DepartmentEntity, DivisionEntity>
	{
		public override void CreateAndUpdate()
		{
			CreateAndUpdate(new DepartmentWithChildRepositoryLinq());
		}

	}
}

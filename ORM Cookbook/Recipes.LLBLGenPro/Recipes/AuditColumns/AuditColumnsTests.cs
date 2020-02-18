using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.AuditColumns;

namespace Recipes.LLBLGenPro.AuditColumns
{
	[TestClass]
	public class AuditColumnsTests : AuditColumnsTests<DepartmentEntity>
	{
		protected override IAuditColumnsScenario<DepartmentEntity> GetScenario()
		{
			return new AuditColumnsScenario();
		}
	}
}
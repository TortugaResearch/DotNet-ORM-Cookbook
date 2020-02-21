using Recipes.AuditColumns;
using System;
using Injectables;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Recipes.LLBLGenPro.AuditColumns
{
	public class AuditColumnsScenario : IAuditColumnsScenario<DepartmentEntity>
	{
		public int CreateDepartment(DepartmentEntity department, User user)
		{
			if(department == null) 
				throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
			if(user == null) 
				throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

			using(var adapter = new DataAccessAdapter())
			{
				ConfigureAuditor(department, user);
				adapter.SaveEntity(department);
				return department.DepartmentKey;
			}
		}


		public DepartmentEntity GetDepartment(int departmentKey, User user)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return adapter.FetchNewEntity<DepartmentEntity>(
									new RelationPredicateBucket(DepartmentFields.DepartmentKey
																				.Equal(departmentKey)));
			}
		}


		public void UpdateDepartment(DepartmentEntity department, User user)
		{
			if(department == null) 
				throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
			if(user == null) 
				throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

			using(var adapter = new DataAccessAdapter())
			{
				ConfigureAuditor(department, user);
				adapter.SaveEntity(department);
			}
		}


		private void ConfigureAuditor(DepartmentEntity department, User user)
		{
			((DepartmentAuditor)department.AuditorToUse).ActiveEmployee = user.UserKey;
		}
	}
}
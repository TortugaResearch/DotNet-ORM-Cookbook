using Recipes.Repositories;
using System.Collections.Generic;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Recipes.LLBLGenPro.Repositories
{
	/// <summary>
	/// Base class for the repositories. Shared for linq & queryspec
	/// </summary>
	/// <seealso cref="Recipes.Repositories.IDepartmentWithChildRepository{LLBLGenPro.OrmCookbook.EntityClasses.DepartmentEntity, LLBLGenPro.OrmCookbook.EntityClasses.DivisionEntity}" />
	internal abstract class DepartmentWithChildRepositoryBase: IDepartmentWithChildRepository<DepartmentEntity, DivisionEntity>
    {
        public int Create(DepartmentEntity department)
        {
            using(var adapter = new DataAccessAdapter())
            {
				// Simply save the graph. Refetches entity as it's used after this call.
				adapter.SaveEntity(department, refetchAfterSave:true);
                return department.DepartmentKey;
            }
        }

        public void Delete(int departmentKey)
        {
			using(var adapter = new DataAccessAdapter())
			{
				// delete directly on the DB, no fetch
				adapter.DeleteEntitiesDirectly(typeof(DepartmentEntity), new RelationPredicateBucket(DepartmentFields.DepartmentKey==departmentKey));
            }
        }

        public void Delete(DepartmentEntity department)
        {
			using(var adapter = new DataAccessAdapter())
			{
				adapter.DeleteEntity(department);
            }
        }

        public void Update(DepartmentEntity department)
        {
			using(var adapter = new DataAccessAdapter())
			{
				// fk's are synced automatically, simply save the graph. Refetches entity as it's used after this call.
				adapter.SaveEntity(department, refetchAfterSave:true);
            }
        }

		public abstract IList<DepartmentEntity> GetAll();
		public abstract IList<DivisionEntity> GetAllDivisions();
		public abstract DepartmentEntity GetByKey(int departmentKey);
	}
}


using Recipes.Repositories;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Recipes.LLBLGenPro.Repositories
{
	internal class DepartmentWithChildRepository : IDepartmentWithChildRepository<DepartmentEntity, DivisionEntity>
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
				adapter.DeleteEntitiesDirectly(typeof(DepartmentEntity), new RelationPredicateBucket(DepartmentFields.DepartmentKey.Equal(departmentKey)));
            }
        }

        public void Delete(DepartmentEntity department)
        {
			using(var adapter = new DataAccessAdapter())
			{
				adapter.DeleteEntity(department);
            }
        }

        public IList<DepartmentEntity> GetAll()
        {
			using(var adapter = new DataAccessAdapter())
			{
				var metaData = new LinqMetaData(adapter);
				return metaData.Department.WithPath(a=>a.Prefetch(d=>d.Division)).ToList();
            }
        }

        public IList<DivisionEntity> GetAllDivisions()
        {
			using(var adapter = new DataAccessAdapter())
			{
				var metaData = new LinqMetaData(adapter);
				return metaData.Division.ToList();
            }
        }

        public DepartmentEntity GetByKey(int departmentKey)
        {
			using(var adapter = new DataAccessAdapter())
			{
				var metaData = new LinqMetaData(adapter);
				return metaData.Department.Where(d=>d.DepartmentKey==departmentKey).WithPath(a => a.Prefetch(d => d.Division)).SingleOrDefault();
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
    }
}


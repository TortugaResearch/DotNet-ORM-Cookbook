using Recipes.ModelWithLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Recipes.LLBLGenPro.ModelWithLookup
{
	public class ModelWithLookupComplexScenario : IModelWithLookupComplexScenario<EmployeeEntity>
	{
		public int Create(EmployeeEntity employee)
		{
			if (employee == null)
				throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
			if (employee.EmployeeClassification == null)
				throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

			using (var adapter = new DataAccessAdapter())
			{
				// the test FoulLookup will alter the associated lookup entity and if we persist things recursively we'll save this record too, so we don't use any
				// recursive persistence here. 
				adapter.SaveEntity(employee, true, recurse:false);
				return employee.EmployeeKey;
			}
		}

		public void Delete(EmployeeEntity employee)
		{
			if (employee == null)
				throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

			using (var adapter = new DataAccessAdapter())
			{
				employee.IsNew = false;
				adapter.DeleteEntity(employee);
			}
		}

		public void DeleteByKey(int employeeKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				adapter.DeleteEntitiesDirectly(typeof(EmployeeEntity), new RelationPredicateBucket(EmployeeFields.EmployeeKey.Equal(employeeKey)));
			}
		}

		public IList<EmployeeEntity> FindByLastName(string lastName)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee
												.Where(ec => ec.LastName == lastName)
												.WithPath(p => p.Prefetch(e => e.EmployeeClassification))
												.ToList();
			}
		}

		public IList<EmployeeEntity> GetAll()
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee
												.WithPath(p=>p.Prefetch(e=>e.EmployeeClassification))
												.ToList();
			}
		}

		public EmployeeEntity? GetByKey(int employeeKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee
												.WithPath(p => p.Prefetch(e => e.EmployeeClassification))
												.SingleOrDefault(e => e.EmployeeKey == employeeKey);
			}
		}

		public IEmployeeClassification? GetClassification(int employeeClassificationKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeClassification.FirstOrDefault(ec=>ec.EmployeeClassificationKey==employeeClassificationKey);
			}
		}

		/// <summary>
		/// Updates the specified employee.
		/// </summary>
		/// <param name="employee">The employee.</param>
		/// <exception cref="ArgumentNullException">employee</exception>
		public void Update(EmployeeEntity employee)
		{
			if (employee == null)
				throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
			if (employee.EmployeeClassification == null)
				throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

			using (var adapter = new DataAccessAdapter())
			{
				EmployeeEntity toPersist = employee;
				if(toPersist.IsNew)
				{
					toPersist = new EmployeeEntity(employee.EmployeeKey);
					adapter.FetchEntity(toPersist);
					//Copy the changed fields
					toPersist.FirstName = employee.FirstName;
					toPersist.MiddleName = employee.MiddleName;
					toPersist.LastName = employee.LastName;
					toPersist.CellPhone = employee.CellPhone;
					toPersist.OfficePhone = employee.OfficePhone;
					toPersist.Title = employee.Title;
					toPersist.EmployeeClassificationKey = employee.EmployeeClassificationKey;
				}
				if(!toPersist.IsNew)
				{
					// By default the whole graph is persisted in-order, FKs are synced etc. but there's a test in this system
					// which makes it fail if we do so, so we have to disable the recursive saves. 
					adapter.SaveEntity(toPersist, refetchAfterSave:false, recurse:false);
				}
			}
		}
	}
}

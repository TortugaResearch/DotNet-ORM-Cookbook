using Recipes.ModelWithLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace Recipes.LLBLGenPro.ModelWithLookup
{
	public class ModelWithLookupSimpleRepository : IModelWithLookupSimpleRepository<EmployeeEntity>
	{
		public int Create(EmployeeEntity employee)
		{
			if (employee == null)
				throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

			using (var adapter = new DataAccessAdapter())
			{
				adapter.SaveEntity(employee);
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
				return new LinqMetaData(adapter).Employee.Where(ec => ec.LastName == lastName).ToList();
			}
		}

		public IList<EmployeeEntity> GetAll()
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.ToList();
			}
		}

		public EmployeeEntity? GetByKey(int employeeKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Employee.FirstOrDefault(e=>e.EmployeeKey==employeeKey);
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

			using (var adapter = new DataAccessAdapter())
			{
				var temp = new EmployeeEntity(employee.EmployeeKey);
				adapter.FetchEntity(temp);
				if (!temp.IsNew)
				{
					//Copy the changed fields
					temp.FirstName = employee.FirstName;
					temp.MiddleName = employee.MiddleName;
					temp.LastName = employee.LastName;
					temp.CellPhone = employee.CellPhone;
					temp.OfficePhone = employee.OfficePhone;
					temp.Title = employee.Title;
					temp.EmployeeClassificationKey = employee.EmployeeClassificationKey;
					adapter.SaveEntity(temp);
				}
			}
		}
	}
}

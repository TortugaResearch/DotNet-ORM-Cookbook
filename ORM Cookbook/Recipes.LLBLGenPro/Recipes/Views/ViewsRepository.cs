using Recipes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.Linq;

namespace Recipes.LLBLGenPro.Views
{
	public class ViewsRepository : IViewsRepository<EmployeeDetailEntity, EmployeeEntity>
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

		public IList<EmployeeDetailEntity> FindByEmployeeClassificationKey(int employeeClassificationKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeDetail.Where(x => x.EmployeeClassificationKey == employeeClassificationKey).ToList();
			}
		}

		public IList<EmployeeDetailEntity> FindByLastName(string lastName)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeDetail.Where(x => x.LastName == lastName).ToList();
			}
		}

		public IList<EmployeeDetailEntity> GetAll()
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeDetail.ToList();
			}
		}

		public EmployeeDetailEntity? GetByEmployeeKey(int employeeKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeDetail.SingleOrDefault(x => x.EmployeeKey == employeeKey);
			}
		}

		public IEmployeeClassification? GetClassification(int employeeClassificationKey)
		{
			using (var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).EmployeeClassification.FirstOrDefault(ec=>ec.EmployeeClassificationKey == employeeClassificationKey);
			}
		}
	}
}

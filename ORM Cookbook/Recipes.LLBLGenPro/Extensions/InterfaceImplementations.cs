using System;
using System.Collections.Generic;
using System.Linq;
using Recipes.Models;

namespace LLBLGenPro.OrmCookbook.EntityClasses
{
	public partial class DepartmentEntity : IDepartment<DivisionEntity>
	{
	}

	public partial class DivisionEntity : IDivision<DepartmentEntity>
	{
		ICollection<DepartmentEntity> IDivision<DepartmentEntity>.Departments
		{
			get { return (ICollection<DepartmentEntity>)this.Departments; }
		}
	}
}

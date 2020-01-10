using System;
using System.Collections.Generic;
using System.Text;
using Recipes.ModelWithLookup;

namespace LLBLGenPro.OrmCookbook.EntityClasses
{
	public partial class EmployeeEntity
	{
		IEmployeeClassification IEmployeeComplex.EmployeeClassification
		{
			get { return _employeeClassification; }
			set { SetSingleRelatedEntityNavigator(value as EmployeeClassificationEntity, "EmployeeClassification"); }
		}
	}
}

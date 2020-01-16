using Recipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLBLGenPro.OrmCookbook.EntityClasses
{
	public partial class EmployeeEntity
	{
		IReadOnlyEmployeeClassification IEmployeeComplex.EmployeeClassification
		{
			get { return _employeeClassification; }
			set { SetSingleRelatedEntityNavigator(value as EmployeeClassificationEntity, "EmployeeClassification"); }
		}
	}
}

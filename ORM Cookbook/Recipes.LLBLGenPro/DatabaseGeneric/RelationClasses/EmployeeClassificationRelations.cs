///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using LLBLGenPro.OrmCookbook;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGenPro.OrmCookbook.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: EmployeeClassification. </summary>
	public partial class EmployeeClassificationRelations
	{
		/// <summary>CTor</summary>
		public EmployeeClassificationRelations()
		{
		}

		/// <summary>Gets all relations of the EmployeeClassificationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EmployeeEntityUsingEmployeeClassificationKey);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EmployeeClassificationEntity and EmployeeEntity over the 1:n relation they have, using the relation between the fields:
		/// EmployeeClassification.EmployeeClassificationKey - Employee.EmployeeClassificationKey
		/// </summary>
		public virtual IEntityRelation EmployeeEntityUsingEmployeeClassificationKey
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Employees" , true);
				relation.AddEntityFieldPair(EmployeeClassificationFields.EmployeeClassificationKey, EmployeeFields.EmployeeClassificationKey);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeeClassificationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmployeeEntity", false);
				return relation;
			}
		}


		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticEmployeeClassificationRelations
	{
		internal static readonly IEntityRelation EmployeeEntityUsingEmployeeClassificationKeyStatic = new EmployeeClassificationRelations().EmployeeEntityUsingEmployeeClassificationKey;

		/// <summary>CTor</summary>
		static StaticEmployeeClassificationRelations()
		{
		}
	}
}

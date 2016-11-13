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
	/// <summary>Implements the relations factory for the entity: Division. </summary>
	public partial class DivisionRelations
	{
		/// <summary>CTor</summary>
		public DivisionRelations()
		{
		}

		/// <summary>Gets all relations of the DivisionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.DepartmentEntityUsingDivisionKey);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between DivisionEntity and DepartmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Division.DivisionKey - Department.DivisionKey
		/// </summary>
		public virtual IEntityRelation DepartmentEntityUsingDivisionKey
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Departments" , true);
				relation.AddEntityFieldPair(DivisionFields.DivisionKey, DepartmentFields.DivisionKey);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DivisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DepartmentEntity", false);
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
	internal static class StaticDivisionRelations
	{
		internal static readonly IEntityRelation DepartmentEntityUsingDivisionKeyStatic = new DivisionRelations().DepartmentEntityUsingDivisionKey;

		/// <summary>CTor</summary>
		static StaticDivisionRelations()
		{
		}
	}
}

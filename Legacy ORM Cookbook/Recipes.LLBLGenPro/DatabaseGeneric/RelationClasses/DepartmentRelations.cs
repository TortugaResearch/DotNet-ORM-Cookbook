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
	/// <summary>Implements the relations factory for the entity: Department. </summary>
	public partial class DepartmentRelations
	{
		/// <summary>CTor</summary>
		public DepartmentRelations()
		{
		}

		/// <summary>Gets all relations of the DepartmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.DivisionEntityUsingDivisionKey);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between DepartmentEntity and DivisionEntity over the m:1 relation they have, using the relation between the fields:
		/// Department.DivisionKey - Division.DivisionKey
		/// </summary>
		public virtual IEntityRelation DivisionEntityUsingDivisionKey
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Division", false);
				relation.AddEntityFieldPair(DivisionFields.DivisionKey, DepartmentFields.DivisionKey);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DivisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DepartmentEntity", true);
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
	internal static class StaticDepartmentRelations
	{
		internal static readonly IEntityRelation DivisionEntityUsingDivisionKeyStatic = new DepartmentRelations().DivisionEntityUsingDivisionKey;

		/// <summary>CTor</summary>
		static StaticDepartmentRelations()
		{
		}
	}
}

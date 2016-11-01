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

using LLBLGenPro.OrmCookbook;
using LLBLGenPro.OrmCookbook.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGenPro.OrmCookbook.FactoryClasses
{
	/// <summary>Factory class for IEntityField2 instances, used in IEntityFields2 instances.</summary>
	public static partial class EntityFieldFactory
	{
		/// <summary>Creates a new IEntityField2 instance for usage in the EntityFields object for the entity related to the field index specified.</summary>
		/// <param name="fieldIndex">The field which IEntityField2 instance should be created</param>
		/// <returns>The IEntityField2 instance for the field specified in fieldIndex</returns>
		public static IEntityField2 Create(Enum fieldIndex)
		{
			return new EntityField2(FieldInfoProviderSingleton.GetInstance().GetFieldInfo(fieldIndex));
		}

		/// <summary>Creates a new IEntityField2 instance, which represents the field objectName.fieldName</summary>
		/// <param name="objectName">the name of the object the field belongs to, like CustomerEntity or OrdersTypedView</param>
		/// <param name="fieldName">the name of the field to create</param>
		public static IEntityField2 Create(string objectName, string fieldName)
        {
			return new EntityField2(FieldInfoProviderSingleton.GetInstance().GetFieldInfo(objectName, fieldName));
        }

		#region Included Code

		#endregion
	}
}

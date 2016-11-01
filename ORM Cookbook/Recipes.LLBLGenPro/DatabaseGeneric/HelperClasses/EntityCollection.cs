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
using System.ComponentModel;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using LLBLGenPro.OrmCookbook.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace LLBLGenPro.OrmCookbook.HelperClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>EntityCollection implementation which is used for backwards compatibility and for design time databinding. This EntityCollection is an EntityCollection(Of EntityBase2)
	/// </summary>
	[Serializable]
	public partial class EntityCollection : EntityCollectionNonGeneric
	{
		/// <summary>CTor</summary>
		public EntityCollection():base()
		{
		}

		/// <summary>CTor</summary>
		/// <param name="entityFactoryToUse">The entity factory object to use when this collection has to construct new objects.</param>
		public EntityCollection(IEntityFactory2 entityFactoryToUse):base(entityFactoryToUse)
		{
		}

		/// <summary>Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityCollection(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
		
		#region Custom EntityCollection code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCollectionCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Included Code

		#endregion
	}
	

	/// <summary>Generic entity collection class which replaces the original generated, non strongly typed EntityCollection variant.</summary>
	/// <remarks>Use the generated, non-generic EntityCollection class for design-time databinding for winforms, as winforms doesn't support 
	/// design time databinding (runtime-databinding works fine) with generic classes</remarks>
	[Serializable]
	public partial class EntityCollection<TEntity> : EntityCollectionBase2<TEntity>
		where TEntity : EntityBase2, IEntity2
	{
		/// <summary>CTor which determines the factory to use from the generic type argument, unless TEntity is an abstract entity. If possible use the ctor which accepts a factory</summary>
		public EntityCollection() : base( (IEntityFactory2)null )
		{
		}

		/// <summary>CTor</summary>
		/// <param name="entityFactoryToUse">The entity factory object to use when this collection has to construct new objects.</param>
		public EntityCollection( IEntityFactory2 entityFactoryToUse) : base( entityFactoryToUse )
		{
		}

		/// <summary>CTor</summary>
		/// <param name="initialContents">initial contents for this collection</param>
		public EntityCollection(IEnumerable<TEntity> initialContents ) : base( initialContents )
		{
		}

		/// <summary>Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityCollection( SerializationInfo info, StreamingContext context) : base( info, context )
		{
		}
		
		#region Custom EntityCollection code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCollectionCodeGeneric
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Included Code

		#endregion		
	}
}

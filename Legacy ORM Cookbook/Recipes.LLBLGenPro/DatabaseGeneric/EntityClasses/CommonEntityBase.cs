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
using System.Collections.Generic;
using LLBLGenPro.OrmCookbook;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
#if !CF
using System.Runtime.Serialization;
#endif
namespace LLBLGenPro.OrmCookbook.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Common base class which is the base class for all generated entities which aren't a subtype of another entity.</summary>
	[Serializable]
	public abstract partial class CommonEntityBase : EntityBase2
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		/// <summary>CTor</summary>
		protected CommonEntityBase()
		{
		}
		
		/// <summary> CTor</summary>
		protected CommonEntityBase(string name):base(name)
		{
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CommonEntityBase(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary>Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)</summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates the entity collection and stores it in destination if destination is null</summary>
		/// <typeparam name="T">type of the element to store in the collection</typeparam>
		/// <typeparam name="TFactory">The type of the factory to pass to the entitycollection ctor.</typeparam>
		/// <param name="navigatorName">Name of the property this collection is for.</param>
		/// <param name="setContainingEntityInfo">if set to <see langword="true"/> the collection is for an 1:n relationship, and the containing entity info has to be set</param>
		/// <param name="forMN">if set to <see langword="true"/> the collection is for an m:n relationship, otherwise for an 1:n relationship</param>
		/// <param name="destination">The destination member variable.</param>
		/// <returns>the collection referred to by destination if destination isn't null, otherwise the newly created collection (which is then stored in destination</returns>
		protected EntityCollection<T> GetOrCreateEntityCollection<T, TFactory>(string navigatorName, bool setContainingEntityInfo, bool forMN, ref EntityCollection<T> destination)
			where T:EntityBase2 , IEntity2
		{
			if(destination==null)
			{
				destination = new EntityCollection<T>(EntityFactoryCache2.GetEntityFactory(typeof(TFactory)));
				if(forMN)
				{
					((IEntityCollectionCore)destination).IsForMN = true;
				}
				else
				{
					if(setContainingEntityInfo)
					{
						destination.SetContainingEntityInfo(this, navigatorName);
					}
				}
				destination.ActiveContext = this.ActiveContext;
			}
			return destination;
		}

		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}

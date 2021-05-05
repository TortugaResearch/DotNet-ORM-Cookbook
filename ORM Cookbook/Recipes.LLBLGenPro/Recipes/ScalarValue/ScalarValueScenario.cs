using Recipes.ScalarValue;
using System;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.Linq;

namespace Recipes.LLBLGenPro.ScalarValue
{
	public class ScalarValueScenario : IScalarValueScenario
	{
		public int? GetDivisionKey(string divisionName)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// As the field in the projection isn't nullable, LLBLGen Pro will normally return the default value
				// for when the field is null. Here, however this gives a problem, so we have to
				// cast the field to int? to make FirstOrDefault return a nullable type.  
				// A workaround could have been to project to the type first and use that as a check, however that's 
				// less efficient. 
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionName == divisionName)
												.Select(d => d.DivisionKey as int?).FirstOrDefault();
			}
		}


		public string? GetDivisionName(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey == divisionKey)
												.Select(d => d.DivisionName).FirstOrDefault();
			}
		}


		public string? GetDivisionNameOrNull(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey == divisionKey)
												.Select(d => d.DivisionName).FirstOrDefault();
			}
		}


		public DateTimeOffset? GetLastReviewCycle(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey == divisionKey)
												.Select(d => d.LastReviewCycle).FirstOrDefault();
			}
		}


		public int? GetMaxEmployees(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey == divisionKey)
												.Select(d => d.MaxEmployees).FirstOrDefault();
			}
		}


		public DateTime GetModifiedDate(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey == divisionKey)
												.Select(d => d.ModifiedDate).FirstOrDefault();
			}
		}


		public decimal? GetSalaryBudget(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey == divisionKey)
												.Select(d => d.SalaryBudget).FirstOrDefault();
			}
		}


		public TimeSpan? GetStartTime(int divisionKey)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey == divisionKey)
												.Select(d => d.StartTime).FirstOrDefault();
			}
		}
	}
}
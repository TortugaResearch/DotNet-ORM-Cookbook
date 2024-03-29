﻿using Recipes.EntityFrameworkCore.Entities;
using Recipes.Upsert;
using System;
using System.Data;
using System.Linq;

namespace Recipes.EntityFrameworkCore.Upsert
{
	public class UpsertScenario : IUpsertScenario<Division>
	{
		private Func<OrmCookbookContext> CreateDbContext;

		public UpsertScenario(Func<OrmCookbookContext> dBContextFactory)
		{
			CreateDbContext = dBContextFactory;
		}

		public Division? GetByKey(int divisionKey)
		{
			using (var context = CreateDbContext())
				return context.Divisions.Find(divisionKey);
		}

		public int UpsertByName(Division division)
		{
			if (division == null)
				throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

			//update audit column
			division.CreatedDate = DateTime.UtcNow;
			division.ModifiedDate = DateTime.UtcNow;

			using (var context = CreateDbContext())
			{
				//check to see if the row already exists
				var actual = context.Divisions.Where(x => x.DivisionName == division.DivisionName).SingleOrDefault();
				if (actual == null) //Insert
				{
					context.Divisions.Add(division);
					context.SaveChanges();
					return division.DivisionKey;
				}
				else //Update
				{
					//Copy manually so we don't overwrite CreatedBy/CreatedDate
					actual.Departments = division.Departments;
					actual.DivisionId = division.DivisionId;
					actual.DivisionName = division.DivisionName;
					actual.FloorSpaceBudget = division.FloorSpaceBudget;
					actual.FteBudget = division.FteBudget;
					actual.LastReviewCycle = division.LastReviewCycle;
					actual.MaxEmployees = division.MaxEmployees;
					actual.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
					actual.ModifiedDate = division.ModifiedDate;
					actual.SalaryBudget = division.SalaryBudget;
					actual.StartTime = division.StartTime;
					actual.SuppliesBudget = division.SuppliesBudget;
					context.SaveChanges();
					return actual.DivisionKey;
				}
			}
		}

		public int UpsertByPrimaryKey(Division division)
		{
			if (division == null)
				throw new ArgumentNullException(nameof(division), $"{nameof(division)} is null.");

			//update audit column
			division.CreatedDate = DateTime.UtcNow;
			division.ModifiedDate = DateTime.UtcNow;

			using (var context = CreateDbContext())
			{
				//If DivisionKey is zero, we know this is a new row
				if (division.DivisionKey == 0) //Insert
				{
					context.Divisions.Add(division);
					context.SaveChanges();
					return division.DivisionKey;
				}
				else //Update
				{
					//This wouldn't be necessary if we were replacing all columns.
					var actual = context.Divisions.Find(division.DivisionKey);
					if (actual == null)
						throw new DataException("Record not found");

					//Copy manually so we don't overwrite CreatedBy/CreatedDate
					actual.Departments = division.Departments;
					actual.DivisionId = division.DivisionId;
					actual.DivisionName = division.DivisionName;
					actual.FloorSpaceBudget = division.FloorSpaceBudget;
					actual.FteBudget = division.FteBudget;
					actual.LastReviewCycle = division.LastReviewCycle;
					actual.MaxEmployees = division.MaxEmployees;
					actual.ModifiedByEmployeeKey = division.ModifiedByEmployeeKey;
					actual.ModifiedDate = division.ModifiedDate;
					actual.SalaryBudget = division.SalaryBudget;
					actual.StartTime = division.StartTime;
					actual.SuppliesBudget = division.SuppliesBudget;
					context.SaveChanges();
					return actual.DivisionKey;
				}
			}
		}
	}
}

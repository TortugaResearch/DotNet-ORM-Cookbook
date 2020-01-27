using Recipes.SingleColumn;
using System;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.Linq;
using System.Collections.Generic;

namespace Recipes.LLBLGenPro.SingleColumn
{
    public class SingleColumnScenario : ISingleColumnScenario
    {
        public List<int> GetDivisionKeys(int maxDivisionKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                // As the field in the projection isn't nullable, LLBLGen Pro will normally return the default value
                // for when the field is null. Here, however this gives a problem, so we have to
                // cast the field to int? to make FirstOrDefault return a nullable type.
                // A workaround could have been to project to the type first and use that as a check, however that's
                // less efficient.
                return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey <= maxDivisionKey)
                                                .Select(d => d.DivisionKey).ToList();
            }
        }

        public List<string> GetDivisionNames(int maxDivisionKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey <= maxDivisionKey)
                                                .Select(d => d.DivisionName).ToList();
            }
        }

        public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey <= maxDivisionKey)
                                                .Select(d => d.LastReviewCycle).ToList();
            }
        }

        public List<DateTime> GetModifiedDates(int maxDivisionKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey <= maxDivisionKey)
                                                .Select(d => d.ModifiedDate).ToList();
            }
        }

        public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey <= maxDivisionKey)
                                                .Select(d => d.SalaryBudget).ToList();
            }
        }

        public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey <= maxDivisionKey)
                                                .Select(d => d.StartTime).ToList();
            }
        }

        List<int?> ISingleColumnScenario.GetMaxEmployees(int maxDivisionKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Division.Where(d => d.DivisionKey <= maxDivisionKey)
                                                .Select(d => d.MaxEmployees).ToList();
            }
        }
    }
}
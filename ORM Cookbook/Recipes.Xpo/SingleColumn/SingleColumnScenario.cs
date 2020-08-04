﻿using Recipes.Xpo.Entities;
using Recipes.SingleColumn;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.SingleColumn
{
    public class SingleColumnScenario : ISingleColumnScenario
    {

        public List<int> GetDivisionKeys(int maxDivisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey <= maxDivisionKey)
                    .Select(d => d.DivisionKey).ToList();
        }

        public List<string> GetDivisionNames(int maxDivisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey <= maxDivisionKey)
                    .Select(d => d.DivisionName!).ToList();
        }

        public List<DateTimeOffset?> GetLastReviewCycles(int maxDivisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey <= maxDivisionKey)
                    .Select(d => d.LastReviewCycle).ToList();
        }

        public List<int?> GetMaxEmployees(int maxDivisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey <= maxDivisionKey)
                    .Select(d => d.MaxEmployees).ToList();
        }

        public List<DateTime> GetModifiedDates(int maxDivisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey <= maxDivisionKey)
                    .Select(d => d.ModifiedDate).ToList();
        }

        public List<decimal?> GetSalaryBudgets(int maxDivisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey <= maxDivisionKey)
                    .Select(d => d.SalaryBudget).ToList();
        }

        public List<TimeSpan?> GetStartTimes(int maxDivisionKey)
        {
            using (var uow = new UnitOfWork())
                return uow.Query<Division>().Where(d => d.DivisionKey <= maxDivisionKey)
                    .Select(d => d.StartTime).ToList();
        }
    }
}
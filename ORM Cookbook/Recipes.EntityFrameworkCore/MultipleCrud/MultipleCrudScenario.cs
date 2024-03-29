﻿using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.MultipleCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.EntityFrameworkCore.MultipleCrud
{
    public class MultipleCrudScenario : IMultipleCrudScenario<Employee>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public MultipleCrudScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public void DeleteBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var context = CreateDbContext())
            {
                foreach (var employee in employees)
                    context.Entry(employee).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

            using (var context = CreateDbContext())
            {
                foreach (var key in employeeKeys)
                    context.Entry(new Employee() { EmployeeKey = key }).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public IList<Employee> FindByLastName(string lastName)
        {
            using (var context = CreateDbContext())
                return context.Employees.Where(ec => ec.LastName == lastName).ToList();
        }

        public void InsertBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var context = CreateDbContext())
            {
                foreach (var employee in employees)
                    context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public IList<int> InsertBatchReturnKeys(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var context = CreateDbContext())
            {
                foreach (var employee in employees)
                    context.Employees.Add(employee);
                context.SaveChanges();
            }

            return employees.Select(x => x.EmployeeKey).ToList();
        }

        public IList<Employee> InsertBatchReturnRows(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var context = CreateDbContext())
            {
                foreach (var employee in employees)
                    context.Employees.Add(employee);
                context.SaveChanges();
            }

            return employees;
        }

        public void InsertBatchWithRefresh(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var context = CreateDbContext())
            {
                foreach (var employee in employees)
                    context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void UpdateBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var context = CreateDbContext())
            {
                foreach (var employee in employees)
                    context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

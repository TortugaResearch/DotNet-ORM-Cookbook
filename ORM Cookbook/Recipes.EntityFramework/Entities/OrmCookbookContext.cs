using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Recipes.EntityFramework.Entities
{
    public partial class OrmCookbookContext : DbContext
    {
        public OrmCookbookContext(string nameOrConnectionString, bool lazyLoadingEnabled)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
        }

#nullable disable //Assume that the DbContext constructor will populate these properties
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentDetail> DepartmentDetail { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeClassification> EmployeeClassification { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductLine> ProductLine { get; set; }
#nullable enable

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");

            modelBuilder.Entity<Division>()
                .Property(e => e.SalaryBudget)
                .HasPrecision(14, 4);

            modelBuilder.Entity<Division>()
                .Property(e => e.FteBudget)
                .HasPrecision(5, 1);

            modelBuilder.Entity<Division>()
                .Property(e => e.SuppliesBudget)
                .HasPrecision(14, 4);

            modelBuilder.Entity<Division>()
                .HasMany(e => e.Department)
                .WithRequired(e => e.Division!)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.OfficePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Division)
                .WithRequired(e => e.Employee!)
                .HasForeignKey(e => e.CreatedByEmployeeKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Division1)
                .WithRequired(e => e.Employee1!)
                .HasForeignKey(e => e.ModifiedByEmployeeKey)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeClassification>()
                .Property(e => e.EmployeeClassificationName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeClassification>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.EmployeeClassification!)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ShippingWeight)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductWeight)
                .HasPrecision(10, 4);

            modelBuilder.Entity<ProductLine>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.ProductLine!)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.OfficePhone)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.EmployeeClassificationName)
                .IsUnicode(false);
        }
    }
}

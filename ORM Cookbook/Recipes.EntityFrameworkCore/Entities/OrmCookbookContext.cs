using Microsoft.EntityFrameworkCore;
using System;

namespace Recipes.EntityFrameworkCore.Entities
{
    public partial class OrmCookbookContext : DbContext
    {
        public OrmCookbookContext()
        {
        }

        public OrmCookbookContext(DbContextOptions<OrmCookbookContext> options)
            : base(options)
        {
        }

        //Using "= null!;" to remove the compiler warning.
        //Assume that the DbContext constructor will populate these properties

        public virtual DbSet<Department> Department { get; set; } = null!;
        public virtual DbSet<DepartmentDetail> DepartmentDetail { get; set; } = null!;
        public virtual DbSet<Division> Division { get; set; } = null!;
        public virtual DbSet<Employee> Employee { get; set; } = null!;
        public virtual DbSet<EmployeeClassification> EmployeeClassification { get; set; } = null!;
        public virtual DbSet<EmployeeDetail> EmployeeDetail { get; set; } = null!;
        public virtual DbSet<Product> Product { get; set; } = null!;
        public virtual DbSet<ProductLine> ProductLine { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");

#nullable disable //Assume that the DbContext constructor will populate these properties

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.DepartmentName)
                    .HasName("UX_Department_DepartmentName")
                    .IsUnique();

                entity.HasOne(d => d.DivisionKeyNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.DivisionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_DivisionKey");
            });

            modelBuilder.Entity<DepartmentDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DepartmentDetail", "HR");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasIndex(e => e.DivisionName)
                    .HasName("UX_Division_DivisionName")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.DivisionId).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysutcdatetime())");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.CellPhone).IsUnicode(false);

                entity.Property(e => e.OfficePhone).IsUnicode(false);

                entity.HasOne(d => d.EmployeeClassificationKeyNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmployeeClassificationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmployeeClassificationKey");
            });

            modelBuilder.Entity<EmployeeClassification>(entity =>
            {
                entity.HasIndex(e => e.EmployeeClassificationName)
                    .HasName("UX_EmployeeClassification_EmployeeClassificationName")
                    .IsUnique();

                entity.Property(e => e.EmployeeClassificationName).IsUnicode(false);

                entity.Property(e => e.IsEmployee).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeeDetail", "HR");

                entity.Property(e => e.CellPhone).IsUnicode(false);

                entity.Property(e => e.EmployeeClassificationName).IsUnicode(false);

                entity.Property(e => e.OfficePhone).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.ProductLineKeyNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductLineKey)
                    .OnDelete(DeleteBehavior.Cascade) //This must be changed to support cascade
                    .HasConstraintName("FK_Product_ProductLineKey");
            });

            modelBuilder.Entity<ProductLine>(entity =>
            {
                entity.HasIndex(e => e.ProductLineName)
                    .HasName("UX_ProductLine_ProductLineName")
                    .IsUnique();
            });

            RegisterEntitiesForStoredProcedures(modelBuilder);

#nullable enable

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
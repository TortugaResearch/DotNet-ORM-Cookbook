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

#nullable disable //Assume that the DbContext constructor will populate these properties
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentDetail> DepartmentDetail { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeClassification> EmployeeClassification { get; set; }
#nullable enable

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.DepartmentName)
                    .HasName("UX_Department_DepartmentName")
                    .IsUnique();

                entity.HasOne(d => d.DivisionKeyNavigation)
                    .WithMany(p => p!.Department) //change from p.Department to p!.Department
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
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.CellPhone).IsUnicode(false);

                entity.Property(e => e.OfficePhone).IsUnicode(false);

                entity.HasOne(d => d.EmployeeClassificationKeyNavigation)
                    .WithMany(p => p!.Employee) //change from p.Department to p!.Department
                    .HasForeignKey(d => d.EmployeeClassificationKey)
                    .HasConstraintName("FK_Employee_EmployeeClassificationKey");
            });

            modelBuilder.Entity<EmployeeClassification>(entity =>
            {
                entity.HasKey(e => e.EmployeeClassificationKey)
                    .HasName("PK__Employee__F3E60B21EE040346");

                entity.Property(e => e.EmployeeClassificationName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentDetail> DepartmentDetail { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeClassification> EmployeeClassification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=OrmCookbook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentKey);

                entity.ToTable("Department", "HR");

                entity.HasIndex(e => e.DepartmentName)
                    .HasName("UX_Department_DepartmentName")
                    .IsUnique();

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30);

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

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DivisionName).HasMaxLength(30);
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => e.DivisionKey);

                entity.ToTable("Division", "HR");

                entity.HasIndex(e => e.DivisionName)
                    .HasName("UX_Division_DivisionName")
                    .IsUnique();

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey);

                entity.ToTable("Employee", "HR");

                entity.Property(e => e.CellPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.OfficePhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.EmployeeClassificationKeyNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmployeeClassificationKey)
                    .HasConstraintName("FK_Employee_EmployeeClassificationKey");
            });

            modelBuilder.Entity<EmployeeClassification>(entity =>
            {
                entity.HasKey(e => e.EmployeeClassificationKey)
                    .HasName("PK__Employee__F3E60B21EE040346");

                entity.ToTable("EmployeeClassification", "HR");

                entity.Property(e => e.EmployeeClassificationName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

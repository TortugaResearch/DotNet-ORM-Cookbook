using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities.Conventions;

namespace Recipes.EntityFrameworkCore.Entities;

public partial class OrmCookbookContext : DbContext
{
    public OrmCookbookContext(DbContextOptions<OrmCookbookContext> options, IDatabaseConventionConverter convention)
: base(options)
    {
        m_Convention = convention;
    }

    public OrmCookbookContext(DbContextOptions<OrmCookbookContext> options)
        : base(options)
    {
    }

    readonly IDatabaseConventionConverter? m_Convention;
    //Using "= null!;" to remove the compiler warning.
    //Assume that the DbContext constructor will populate these properties

    public virtual DbSet<Department> Departments { get; set; } = null!;
    public virtual DbSet<DepartmentDetail> DepartmentDetails { get; set; } = null!;
    public virtual DbSet<Division> Divisions { get; set; } = null!;
    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<EmployeeClassification> EmployeeClassifications { get; set; } = null!;
    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<ProductLine> ProductLines { get; set; } = null!;
    public virtual DbSet<SampleTable> SampleTables { get; set; } = null!;
    public virtual DbSet<Student> Students { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder == null)
            throw new ArgumentNullException(nameof(modelBuilder), $"{nameof(modelBuilder)} is null.");

#nullable disable //Assume that the DbContext constructor will populate these properties
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasOne(d => d.CreatedByEmployeeKeyNavigation)
                .WithMany(p => p.DepartmentCreatedByEmployeeKeyNavigations)
                .HasForeignKey(d => d.CreatedByEmployeeKey)
                .HasConstraintName("FK_Department_CreatedByEmployeeKey");

            entity.HasOne(d => d.DivisionKeyNavigation)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.DivisionKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Department_DivisionKey");

            entity.HasOne(d => d.ModifiedByEmployeeKeyNavigation)
                .WithMany(p => p.DepartmentModifiedByEmployeeKeyNavigations)
                .HasForeignKey(d => d.ModifiedByEmployeeKey)
                .HasConstraintName("FK_Department_ModifiedByEmployeeKey");
        });

        modelBuilder.Entity<DepartmentDetail>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("DepartmentDetail", "HR");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.Property(e => e.DivisionId).HasDefaultValueSql("(newsequentialid())");

            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.CreatedByEmployeeKeyNavigation)
                .WithMany(p => p.DivisionCreatedByEmployeeKeyNavigations)
                .HasForeignKey(d => d.CreatedByEmployeeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Division_CreatedByEmployeeKey");

            entity.HasOne(d => d.ModifiedByEmployeeKeyNavigation)
                .WithMany(p => p.DivisionModifiedByEmployeeKeyNavigations)
                .HasForeignKey(d => d.ModifiedByEmployeeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Division_ModifiedByEmployeeKey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.CellPhone).IsUnicode(false);

            entity.Property(e => e.OfficePhone).IsUnicode(false);

            entity.HasOne(d => d.EmployeeClassificationKeyNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeClassificationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_EmployeeClassificationKey");
        });

        modelBuilder.Entity<EmployeeClassification>(entity =>
        {
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
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductLineKey)
                .OnDelete(DeleteBehavior.Cascade) //This must be changed to support cascade
                .HasConstraintName("FK_Product_ProductLineKey");
        });

        modelBuilder.Entity<SampleTable>(entity => entity.Property(e => e.Id).ValueGeneratedNever());

        RegisterEntitiesForStoredProcedures(modelBuilder);
#nullable enable

        //Allow subclasses to override conventions
        OnModelCreatingPartial(modelBuilder);

        //Apply Conventions
        m_Convention?.SetConvention(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
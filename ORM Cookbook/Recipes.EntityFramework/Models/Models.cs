using System.Data.Entity;

namespace Recipes.EF.Models
{

    public partial class OrmCookbook : DbContext
    {
        public OrmCookbook()
            : base("name=OrmCookbook")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeClassification> EmployeeClassifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Division)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.OfficePhone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeClassification>()
                .Property(e => e.EmployeeClassificationName)
                .IsUnicode(false);
        }
    }
}

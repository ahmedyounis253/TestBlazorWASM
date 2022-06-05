

namespace TestBlazorWASM.Server
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions options ):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.id);
            modelBuilder.Entity<Employee > ().ToTable("Employee");
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeID).HasComputedColumnSql(
                "Upper(Concat(" +
                "SubString([Role],1,1) + " +
                "SubString([Name],1,1)+ " +
                "SubString([Name],Len([Name]),Len([Name]))" +
                ",[Age]*[id]/3))");
                         }
    
    
    public DbSet<Employee> Employees { get; set; }
    }
}

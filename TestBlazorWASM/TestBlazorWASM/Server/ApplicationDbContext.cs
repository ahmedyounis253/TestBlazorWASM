
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
                                                                               
        }
    
    
    public DbSet<Employee> Employees { get; set; }
    }
}

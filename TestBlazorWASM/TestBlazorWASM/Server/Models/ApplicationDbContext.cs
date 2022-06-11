
namespace TestBlazorWASM.Server
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration())
                        .ApplyConfiguration<Student>(new StudentConfiguration());
        }
    }
}

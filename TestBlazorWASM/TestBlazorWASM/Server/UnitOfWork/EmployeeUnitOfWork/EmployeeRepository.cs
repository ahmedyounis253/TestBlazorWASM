namespace TestBlazorWASM.Server
{
    public class EmployeeRepository : BaseNameRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

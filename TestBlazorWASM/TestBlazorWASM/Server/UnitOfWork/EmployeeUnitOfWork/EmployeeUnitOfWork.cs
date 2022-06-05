namespace TestBlazorWASM.Server
{
    public class EmployeeUnitOfWork : BaseNameUnitOfWork<Employee>, IEmployeeUnitOfWork
    {

        public EmployeeUnitOfWork(IEmployeeRepository employeeRepository) : base(employeeRepository) { }
    }
}

namespace TestBlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseNameController<Employee>
    {
        public EmployeesController(IEmployeeUnitOfWork unitOfWork) : base(unitOfWork) {
    
        }

    }
}

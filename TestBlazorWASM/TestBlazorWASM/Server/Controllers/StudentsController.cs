namespace TestBlazorWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseNameController<Student>
    {
        public StudentsController(IStudentUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}

namespace TestBlazorWASM.Server
{
    public class StudentRepository : BaseNameRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

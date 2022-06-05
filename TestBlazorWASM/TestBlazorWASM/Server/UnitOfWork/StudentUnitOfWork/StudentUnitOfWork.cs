namespace TestBlazorWASM.Server
{
    public class StudentUnitOfWork : BaseNameUnitOfWork<Student>, IStudentUnitOfWork
    {

        public StudentUnitOfWork(IStudentRepository studentRepository) : base(studentRepository) { }
    }
}

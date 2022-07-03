
namespace TestBlazorWASM.Shared
{
    public  class ClassRoom:BaseNameEntity
    {
        public Guid SubjectId { get; set; }
        public Subject? Subject { get; set; }


        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<ClassRoomStudent>? ClassRoomStudents { get; set; }

    }
}

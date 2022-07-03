
namespace TestBlazorWASM.Shared
{
    public class ClassRoomStudent:BaseEntity
    {
        public Guid ClassRoomId { get; set; }

        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

    }
}

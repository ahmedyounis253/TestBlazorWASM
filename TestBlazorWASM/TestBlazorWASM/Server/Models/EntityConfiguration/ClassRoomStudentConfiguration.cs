

namespace TestBlazorWASM.Server
{
    public class ClassRoomStudentConfiguration: IEntityTypeConfiguration<ClassRoomStudent>
    {
    public  void Configure(EntityTypeBuilder<ClassRoomStudent> builder)
        {

            builder.ToTable("ClassRoomsStudents");
            builder.HasKey(e => new { e.ClassRoomId, e.StudentId });
            builder.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId).HasConstraintName("Fk-ClassRoomStudent-student");

        }
    }
}

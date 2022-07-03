

namespace TestBlazorWASM.Server
{
    public class ClassRoomConfiguration: BaseNameEntityConfiguration<ClassRoom>, IEntityTypeConfiguration<ClassRoom>
    {
    public override void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            base.Configure(builder);

            builder.ToTable("ClassRooms");
            builder.HasOne(e => e.Subject).WithMany().HasForeignKey(e => e.SubjectId).HasConstraintName("Fk-ClassRoom-Subject");
            builder.HasOne(e => e.Teacher).WithMany().HasForeignKey(e => e.TeacherId).HasConstraintName("Fk-ClassRoom-Teacher");
            builder.HasMany(e => e.ClassRoomStudents).WithOne().HasForeignKey(e => e.ClassRoomId).HasConstraintName("Fk-ClassRoom-ClassRoom-Student");


        }
    }
}

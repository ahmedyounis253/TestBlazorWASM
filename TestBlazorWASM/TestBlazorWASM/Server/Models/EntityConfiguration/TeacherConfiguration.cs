

namespace TestBlazorWASM.Server
{
    public class TeacherConfiguration: BaseNameEntityConfiguration<Teacher>, IEntityTypeConfiguration<Teacher>
    {
    public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);

            builder.ToTable("Teachers");
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s=> s.Mobile).HasMaxLength(20);    

        }
    }
}



namespace TestBlazorWASM.Server
{
    public class StudentConfiguration: BaseNameEntityConfiguration<Student>, IEntityTypeConfiguration<Student>
    {
    public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.ToTable("Students");
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s=> s.Mobile).HasMaxLength(20);    

        }
    }
}

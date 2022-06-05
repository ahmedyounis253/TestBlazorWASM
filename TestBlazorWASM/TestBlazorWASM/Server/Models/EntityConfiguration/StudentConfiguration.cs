

namespace TestBlazorWASM.Server
{
    public class StudentConfiguration: BaseEntityonfiguration<Student>
    {
    public void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.ToTable("Students");
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Age).IsRequired();
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s=> s.Mobile).HasMaxLength(20);    

        }
    }
}

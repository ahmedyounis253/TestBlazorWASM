

namespace TestBlazorWASM.Server
{
    public class SubjectConfiguration: BaseNameEntityConfiguration<Subject>, IEntityTypeConfiguration<Subject>
    {
    public override void Configure(EntityTypeBuilder<Subject> builder)
        {
            base.Configure(builder);

            builder.ToTable("Subjects");

        }
    }
}

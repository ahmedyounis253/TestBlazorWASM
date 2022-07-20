

namespace TestBlazorWASM.Server
{
    public class NotificationMessageConfiguration: BaseEntityConfiguration<NotificationMessage>, IEntityTypeConfiguration<NotificationMessage>
    {
    public override void Configure(EntityTypeBuilder<NotificationMessage> builder)
        {
            base.Configure(builder);

            builder.ToTable("Messages");
            builder.Property(s => s.Message).IsRequired();
            builder.Property(s=> s.Message).HasMaxLength(5000);
            builder.Property(s => s.createdOn).HasDefaultValueSql("GETDATE()");

        }
    }
}

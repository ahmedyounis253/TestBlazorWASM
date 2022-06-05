
namespace TestBlazorWASM.Server
{
    public class EmployeeConfiguration: BaseEntityonfiguration<Employee>
    {
    public void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.ToTable("Employees");
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Mobile).HasMaxLength(20); 
            builder.Property(e => e.EmployeeID).HasComputedColumnSql(
                "Upper(Concat(" +
                "SubString([Role],1,1) + " +
                $",[Age]*{(new Random()).Next()}/3))");

        }
    }
}


using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace TestBlazorWASM.Shared;

public class CreatedAtTimeGenerator : ValueGenerator<DateTimeOffset>
{
    public override bool GeneratesTemporaryValues {get;}



    public override DateTimeOffset Next(EntityEntry entry)
    {
        return DateTimeOffset.UtcNow;

    }
}
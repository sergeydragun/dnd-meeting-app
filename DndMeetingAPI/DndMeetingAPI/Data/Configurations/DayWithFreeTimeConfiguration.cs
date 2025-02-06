namespace DndMeetingAPI.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class DayWithFreeTimeConfiguration : BaseEntityConfiguration<DayWithFreeTime>
{
    public override void Configure(EntityTypeBuilder<DayWithFreeTime> builder)
    {
        builder.HasMany(x => x.FreeTimes)
            .WithOne(x => x.DayWithFreeTime)
            .HasForeignKey(x => x.DayWithFreeTimeId);

        base.Configure(builder);
    }
}

namespace DndMeetingAPI.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class FreeTimeConfiguration : BaseEntityConfiguration<FreeTime>
{
    public override void Configure(EntityTypeBuilder<FreeTime> builder)
    {
        builder.HasQueryFilter(x => !x.Deleted);

        base.Configure(builder);
    }
}

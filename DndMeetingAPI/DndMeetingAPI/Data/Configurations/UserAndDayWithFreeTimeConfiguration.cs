namespace DndMeetingAPI.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class UserAndDayWithFreeTimeConfiguration : BaseEntityConfiguration<UsersAndDaysWithFreeTime>
{
    public override void Configure(EntityTypeBuilder<UsersAndDaysWithFreeTime> builder)
    {
        builder.HasOne(x => x.User)
            .WithMany(x => x.UsersAndDaysWithFreeTime)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.DayWithFreeTime)
            .WithMany(x => x.UsersAndDaysWithFreeTime)
            .HasForeignKey(x => x.DayWithFreeTimeId);

        base.Configure(builder);
    }
}

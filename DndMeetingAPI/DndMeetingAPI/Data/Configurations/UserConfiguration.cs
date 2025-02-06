namespace DndMeetingAPI.Data.Configurations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.FreeTimes)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        base.Configure(builder);
    }
}

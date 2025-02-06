namespace DndMeetingAPI.Types;

using Models;
using Resolvers;

public class FreeTimeObject : ObjectType<FreeTime>
{
    protected override void Configure(IObjectTypeDescriptor<FreeTime> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(x => x.Id)
            .ResolveNodeWith<FreeTimeResolver>(x => x.GetFreeTimeAsync(default!, default!, default!));

        descriptor
            .Field(x => x.StartTime);

        descriptor
            .Field(x => x.EndTime);

        descriptor
            .Field(x => x.UserId);

        descriptor
            .Field(x => x.DayWithFreeTimeId);

        descriptor
            .Field(x => x.User)
            .ResolveWith<FreeTimeResolver>(x => x.GetUserAsync(default!, default!, default!));

        descriptor
            .Field(x => x.DayWithFreeTime)
            .ResolveWith<FreeTimeResolver>(x => x.GetFreeDayAsync(default!, default!, default!));

    }
}

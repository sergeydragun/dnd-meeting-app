namespace DndMeetingAPI.Types;

using Models;
using Resolvers;

public class DayWithFreeTimeObject : ObjectType<DayWithFreeTime>
{
    protected override void Configure(IObjectTypeDescriptor<DayWithFreeTime> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(x => x.Id)
            .ResolveNodeWith<DayWithFreeTimeResolver>(x => x.GetDayWithFreeTimeAsync(default!, default!, default!));

        descriptor
            .Field(x => x.Date);

        descriptor
            .Ignore(x => x.UsersAndDaysWithFreeTime);

        descriptor
            .Field("users")
            .ResolveWith<DayWithFreeTimeResolver>(r => r.GetUsersAsync(default!, default!, default!))
            .Type<ListType<NonNullType<UserObject>>>();

        descriptor
            .Field(x => x.FreeTimes)
            .ResolveWith<DayWithFreeTimeResolver>(r => r.GetFreeTimesAsync(default!, default!, default!));
    }
}

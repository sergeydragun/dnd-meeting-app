namespace DndMeetingAPI.Types;

using Models;
using Resolvers;

public class UserObject : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor
            .Name("User")
            .Description("User that can choose his free time");

        descriptor
            .ImplementsNode()
            .IdField(x => x.Id)
            .ResolveNodeWith<UserResolver>(x => x.GetUserAsync(default!, default!, default!));

        descriptor
            .Field(x => x.Name)
            .Description("Name of the user");

        descriptor
            .Field(x => x.FreeTimes)
            .ResolveWith<UserResolver>(r => r.GetFreeTimesAsync(default!, default!, default!))
            .Type<ListType<NonNullType<FreeTimeObject>>>();

        descriptor
            .Field("daysWithFreeTime")
            .ResolveWith<UserResolver>(x => x.GetDaysWithFreeTimeAsync(default!, default!, default!))
            .Type<ListType<NonNullType<DayWithFreeTimeObject>>>();

        descriptor
            .Ignore(x => x.UsersAndDaysWithFreeTime);

    }
}

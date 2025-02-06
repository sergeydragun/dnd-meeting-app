namespace DndMeetingAPI.Types;

using Data;
using Models;
using Resolvers;

public class MutationObject : ObjectType<MutationResolver>
{
    protected override void Configure(IObjectTypeDescriptor<MutationResolver> descriptor)
    {
        descriptor
            .Name("Mutation")
            .Description("The mutation type, represents all updates we can make to our data.");

        descriptor
            .Field(x => x.AddUser(default!, default!, default!))
            .Description("Create a new user.")
            .Argument("userInput", x => x.Description("The user you want to create."));

        descriptor
            .Field(x => x.AddFreeDaysWithTimesAsync(default!, default!, default!))
            .Description("Create free day with time for user.")
            .Argument("freeDayWithTimesInput", x => x.Description("Day with free times you want to create."));

        descriptor
            .Field(x => x.RemoveFreeDayAsync(default!, default!, default!))
            .Description("remove free day from user.")
            .Argument("removeDayByUserInput", x => x.Description("Removing free days."));

        descriptor
            .Field(x => x.UpdateFreeDayAsync(default!, default!, default!))
            .Description("Update free day from user.")
            .Argument("updateFreeDayInput", x => x.Description("Updating days with free times."));

        descriptor
            .Field(x => x.CopyFreeTimesToUserDays(default!, default!, default!))
            .Description("Copy free time to user.")
            .Argument("copyFreeTimesInput", x => x.Description("Data you want to copy."));
    }
}

namespace DndMeetingAPI.Types;

using Data;
using Models;
using Resolvers;

public class QueryObject : ObjectType<QueryResolver>
{
    protected override void Configure(IObjectTypeDescriptor<QueryResolver> descriptor)
    {
        descriptor
            .Name("Query")
            .Description("The query type, represents all of the entry points into our object graph.");

        descriptor
            .Field(x => x.GetUsers(default!, default!))
            .Description("The users of the query.")
            .UsePaging()
            .UseFiltering()
            .UseSorting();

        descriptor
            .Field(x => x.GetUsersByIds(default!, default!,default))
            .Description("The users by ids.")
            .UsePaging()
            .UseFiltering()
            .UseSorting();

        descriptor
            .Field(x => x.GetUsersFreeTimesInDay(default!, default!, default!, default!))
            .Description("Users free times in one day.")
            .UsePaging()
            .UseFiltering()
            .UseSorting();
    }
}

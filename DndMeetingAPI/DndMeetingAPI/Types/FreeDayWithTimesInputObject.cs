namespace DndMeetingAPI.Types;

using Models;

public class FreeDayWithTimesInputObject : InputObjectType<FreeDayWithTimesInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<FreeDayWithTimesInput> descriptor)
    {
        descriptor
            .Name("FreeDayWithTimes")
            .Description("New free day with the with times by user");

        descriptor
            .Field(x => x.UserId)
            .Description("User Id");

        descriptor
            .Field(x => x.FreeTimes)
            .Type<NonNullType<ListType<FreeTimeInputObject>>>()
            .Description("Free times by this day");
    }
}

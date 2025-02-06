namespace DndMeetingAPI.Types;

using Models;

public class CopyFreeTimesInputObject : InputObjectType<CopyFreeTimesInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<CopyFreeTimesInput> descriptor)
    {
        descriptor
            .Name("CopyFreeTimes")
            .Description("Represents copy user's free times to other days");

        descriptor
            .Field(x => x.UserId)
            .Description("Represents the users whose times are copied");

        descriptor
            .Field(x => x.SourceDayId)
            .Description("Represents the source day whose times are copied");

        descriptor
            .Field(x => x.TargetDates)
            .Description("Represents the target days for which we will copy");
    }
}

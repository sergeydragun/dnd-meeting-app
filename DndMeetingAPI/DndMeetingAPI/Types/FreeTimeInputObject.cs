namespace DndMeetingAPI.Types;

using Models;

public class FreeTimeInputObject : InputObjectType<FreeTimeInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<FreeTimeInput> descriptor)
    {
        descriptor
            .Field(f => f.StartTime)
            .Description("The start time of the free time");

        descriptor
            .Field(f => f.EndTime)
            .Description("The end time of the free time");
    }
}

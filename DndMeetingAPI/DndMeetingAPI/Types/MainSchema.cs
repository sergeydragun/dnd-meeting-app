namespace DndMeetingAPI.Types;

public class MainSchema : Schema
{
    protected override void Configure(ISchemaTypeDescriptor descriptor) =>
        descriptor.Description("This is my schema description that can be accessed by introspection");
}

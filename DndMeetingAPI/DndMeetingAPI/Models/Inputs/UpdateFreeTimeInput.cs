namespace DndMeetingAPI.Models;

public class UpdateFreeTimeInput
{
    public Guid Id { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}

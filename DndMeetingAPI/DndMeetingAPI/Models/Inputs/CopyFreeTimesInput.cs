namespace DndMeetingAPI.Models;

public class CopyFreeTimesInput
{
    public Guid UserId { get; set; }
    public Guid SourceDayId { get; set; }
    public List<DateOnly> TargetDates { get; set; } = new();
}

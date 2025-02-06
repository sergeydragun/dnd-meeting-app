namespace DndMeetingAPI.Models;

public class FreeDayWithTimesInput
{
    public Guid UserId { get; set; }
    public DateOnly Date { get; set; }
    public List<FreeTimeInput> FreeTimes { get; set; } = new();
}

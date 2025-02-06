namespace DndMeetingAPI.Models;

public class RemoveDayByUserInput
{
    public Guid DayId { get; set; }
    public Guid UserId { get; set; }
}

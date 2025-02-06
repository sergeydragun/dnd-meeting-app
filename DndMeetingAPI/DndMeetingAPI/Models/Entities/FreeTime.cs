namespace DndMeetingAPI.Models;

public class FreeTime : BaseEntity
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public Guid UserId { get; set; }
    public Guid DayWithFreeTimeId { get; set; }
    public Boolean Deleted { get; set; }

    public User User { get; set; }
    public DayWithFreeTime DayWithFreeTime { get; set; }
}

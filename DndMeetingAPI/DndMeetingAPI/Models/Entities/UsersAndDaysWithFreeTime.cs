namespace DndMeetingAPI.Models;

public class UsersAndDaysWithFreeTime : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid DayWithFreeTimeId { get; set; }
    public Boolean Deleted { get; set; }

    public User User { get; set; }
    public DayWithFreeTime DayWithFreeTime { get; set; }
}

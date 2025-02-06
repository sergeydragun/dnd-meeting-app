namespace DndMeetingAPI.Models;

public class DayWithFreeTime : BaseEntity
{
    public DateOnly Date { get; set; }

    public List<UsersAndDaysWithFreeTime> UsersAndDaysWithFreeTime { get; set; } = null!;
    public List<FreeTime> FreeTimes { get; set; } = [];
}

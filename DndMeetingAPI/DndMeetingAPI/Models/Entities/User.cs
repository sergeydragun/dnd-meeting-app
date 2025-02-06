namespace DndMeetingAPI.Models;

public class User : BaseEntity
{
    public String Name { get; set; } = String.Empty;

    public List<UsersAndDaysWithFreeTime> UsersAndDaysWithFreeTime { get; set; } = [];
    public List<FreeTime> FreeTimes { get; set; } = [];
}

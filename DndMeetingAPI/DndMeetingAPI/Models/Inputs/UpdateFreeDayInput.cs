namespace DndMeetingAPI.Models;

public class UpdateFreeDayInput
{
    public Guid DayId { get; set; }
    public Guid UserId { get; set; }
    public List<Guid> RemoveFreeTimeIds { get; set; } = new();
    public List<UpdateFreeTimeInput> UpdateFreeTimes { get; set; } = new();
    public List<FreeTimeInput> NewFreeTimes { get; set; } = new();
}

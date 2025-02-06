namespace DndMeetingAPI.Resolvers;

using DataLoaders;
using Models;

public class FreeTimeResolver
{
    public Task<FreeTime> GetFreeTimeAsync(IFreeTimeDataLoader dataLoader, Guid id, CancellationToken cancellationToken = default)
       => dataLoader.LoadAsync(id, cancellationToken);

    public Task<User> GetUserAsync(
        [Parent] FreeTime freeTime,
        IUserDataLoader dataLoader,
        CancellationToken cancellationToken = default)
        => dataLoader.LoadAsync(freeTime.UserId, cancellationToken);

    public Task<DayWithFreeTime> GetFreeDayAsync(
        [Parent] FreeTime freeTime,
        IDayWithFreeTimeDataLoader dataLoader,
        CancellationToken cancellationToken = default)
        => dataLoader.LoadAsync(freeTime.DayWithFreeTimeId, cancellationToken);
}

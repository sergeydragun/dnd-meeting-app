namespace DndMeetingAPI.Resolvers;

using DataLoaders;
using Models;

public class DayWithFreeTimeResolver
{
    public Task<DayWithFreeTime?> GetDayWithFreeTimeAsync(
        IDayWithFreeTimeDataLoader dayWithFreeTimeDataLoader,
        Guid id,
        CancellationToken cancellationToken = default)
            => dayWithFreeTimeDataLoader.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<User>> GetUsersAsync(
        [Parent] DayWithFreeTime dayWithFreeTime,
        DaysWithFreeTimeAndUsersDataLoader daysWithFreeTimeDataLoader,
        CancellationToken cancellationToken = default
    )
        => await daysWithFreeTimeDataLoader.LoadAsync(dayWithFreeTime.Id, cancellationToken);

    public async Task<IEnumerable<FreeTime>> GetFreeTimesAsync(
        [Parent] DayWithFreeTime dayWithFreeTime,
        DaysWithFreeTimeAndFreeTimeDataLoader daysWithFreeTimeDataLoader,
        CancellationToken cancellationToken = default
    )
        => await daysWithFreeTimeDataLoader.LoadAsync(dayWithFreeTime.Id, cancellationToken);
}

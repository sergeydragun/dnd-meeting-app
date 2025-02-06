namespace DndMeetingAPI.DataLoaders;

using Data.Repositories;
using Models;

public class DaysWithFreeTimeAndUsersDataLoader : GroupedDataLoader<Guid, User>
{
    private readonly DayWithFreeTimeRepository _dayWithFreeTimeRepository;

    public DaysWithFreeTimeAndUsersDataLoader(
        DayWithFreeTimeRepository dayWithFreeTimeRepository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _dayWithFreeTimeRepository = dayWithFreeTimeRepository;
    }

    protected override async Task<ILookup<Guid, User>> LoadGroupedBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var dus = await _dayWithFreeTimeRepository.GetUsersInDayWithFreeTimeAsync(keys, cancellationToken);
        return dus.ToLookup(x => x.dayId, x => x.user);
    }
}

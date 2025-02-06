namespace DndMeetingAPI.DataLoaders;

using Data.Repositories;
using Models;

public class DaysWithFreeTimeAndFreeTimeDataLoader : GroupedDataLoader<Guid, FreeTime>
{
    private readonly FreeTimeRepository _freeTimeRepository;

    public DaysWithFreeTimeAndFreeTimeDataLoader(
        FreeTimeRepository freeTimeRepository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _freeTimeRepository = freeTimeRepository;
    }


    protected override async Task<ILookup<Guid, FreeTime>> LoadGroupedBatchAsync(IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var freeTimes = await _freeTimeRepository.GetFreeTimesByDays(keys, cancellationToken);
        return freeTimes.ToLookup(x => x.DayWithFreeTimeId);
    }
}

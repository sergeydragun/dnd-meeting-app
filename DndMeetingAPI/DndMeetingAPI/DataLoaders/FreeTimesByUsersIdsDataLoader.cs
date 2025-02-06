namespace DndMeetingAPI.DataLoaders;

using Data.Repositories;
using Models;

public class FreeTimesByUsersIdsDataLoader : GroupedDataLoader<Guid, FreeTime>
{
    private readonly FreeTimeRepository _repository;
    public FreeTimesByUsersIdsDataLoader(
        FreeTimeRepository freeTimeRepository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _repository = freeTimeRepository;
    }


    protected override async Task<ILookup<Guid, FreeTime>> LoadGroupedBatchAsync(IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var times = await _repository.GetFreeTimesByUsers(keys, cancellationToken);
        return times.ToLookup(x => x.UserId);
    }
}

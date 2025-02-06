namespace DndMeetingAPI.DataLoaders;

using Data.Repositories;
using Models;

public class FreeTimeDataLoader : BatchDataLoader<Guid, FreeTime>, IFreeTimeDataLoader
{
    private readonly FreeTimeRepository _freeTimeRepository;

    public FreeTimeDataLoader(FreeTimeRepository freeTimeRepository, IBatchScheduler batchScheduler, DataLoaderOptions options) : base(batchScheduler, options)
    {
        _freeTimeRepository = freeTimeRepository;
    }

    protected override async Task<IReadOnlyDictionary<Guid, FreeTime>> LoadBatchAsync(IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var  times = await _freeTimeRepository.GetEntitiesByIdsAsync(keys, cancellationToken);
        return times.ToDictionary(x => x.Id);
    }
}

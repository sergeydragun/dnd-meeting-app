namespace DndMeetingAPI.DataLoaders;

using Data.Repositories;
using Models;

public class DayWithFreeTimeDataLoader : BatchDataLoader<Guid, DayWithFreeTime>, IDayWithFreeTimeDataLoader
{
    private readonly DayWithFreeTimeRepository _repository;

    public DayWithFreeTimeDataLoader(
        DayWithFreeTimeRepository repository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options) : base(batchScheduler, options)
    {
        _repository = repository;
    }


    protected override async Task<IReadOnlyDictionary<Guid, DayWithFreeTime>> LoadBatchAsync(IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var days = await this._repository.GetEntitiesByIdsAsync(keys, cancellationToken);
        return days.ToDictionary(day => day.Id);
    }
}

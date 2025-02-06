namespace DndMeetingAPI.DataLoaders;

using Data.Repositories;
using Models;

public class UsersAndDaysWithFreeTimeDataLoader : GroupedDataLoader<Guid, DayWithFreeTime>
{
    private readonly UserRepository _userRepository;

    public UsersAndDaysWithFreeTimeDataLoader(UserRepository userRepository, IBatchScheduler batchScheduler, DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _userRepository = userRepository;
    }

    protected override async Task<ILookup<Guid, DayWithFreeTime>> LoadGroupedBatchAsync(IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        var uads = await this._userRepository.GetDaysWithFreeTimeByUsersIdsAsync(keys, cancellationToken);
        return uads.ToLookup(x => x.UserId, x => x.Day);
    }
}

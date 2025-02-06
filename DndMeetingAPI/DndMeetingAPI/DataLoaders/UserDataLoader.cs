namespace DndMeetingAPI.DataLoaders;

using Data.Repositories;
using Models;

public class UserDataLoader : BatchDataLoader<Guid, User>, IUserDataLoader
{
    private readonly UserRepository _userRepository;

    public UserDataLoader(UserRepository userRepository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options) : base(batchScheduler, options)
    {
        _userRepository = userRepository;
    }


    protected override async Task<IReadOnlyDictionary<Guid, User>> LoadBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken ct = default)
    {
        var users = await _userRepository.GetEntitiesByIdsAsync(keys, ct);
        return users.ToDictionary(u => u.Id);
    }
}

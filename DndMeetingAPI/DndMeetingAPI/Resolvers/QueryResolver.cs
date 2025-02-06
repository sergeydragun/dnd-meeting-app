namespace DndMeetingAPI.Resolvers;

using Data;
using Data.Repositories;
using DataLoaders;
using Models;

public class QueryResolver
{
    public Task<IQueryable<User>> GetUsers(
        [Service] UserRepository userRepository,
        CancellationToken cancellationToken) =>
           Task.FromResult(userRepository.GetAllQueryable());

    public Task<IReadOnlyList<User>> GetUsersByIds(
        IUserDataLoader userDataLoader,
        List<Guid> ids,
        CancellationToken cancellationToken)
            => userDataLoader.LoadAsync(ids, cancellationToken);

    public async Task<IReadOnlyList<FreeTime>> GetUsersFreeTimesInDay(
        [Service] FreeTimeRepository freeTimeRepository,
        List<Guid> usersIds,
        DateOnly dateOfTimes,
        CancellationToken cancellationToken
    )
        => await freeTimeRepository.GetUsersFreeTimesByDays(usersIds, dateOfTimes, cancellationToken);
}

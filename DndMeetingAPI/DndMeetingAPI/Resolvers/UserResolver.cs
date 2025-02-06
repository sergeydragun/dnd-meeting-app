namespace DndMeetingAPI.Resolvers;

using DataLoaders;
using Models;

public class UserResolver
{
    public Task<User> GetUserAsync(IUserDataLoader userDataLoader, Guid id, CancellationToken cancellationToken) =>
        userDataLoader.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<FreeTime>> GetFreeTimesAsync(
        [Parent] User user,
        FreeTimesByUsersIdsDataLoader freeTimesByUsersIdsDataLoader,
        CancellationToken cancellationToken)
    {
        return await freeTimesByUsersIdsDataLoader.LoadAsync(user.Id, cancellationToken);
    }

    public async Task<IEnumerable<DayWithFreeTime>> GetDaysWithFreeTimeAsync(
        [Parent] User user,
        UsersAndDaysWithFreeTimeDataLoader dayWithFreeTimeLoader,
        CancellationToken cancellationToken)
    {
        return await dayWithFreeTimeLoader.LoadAsync(user.Id, cancellationToken);
    }
}

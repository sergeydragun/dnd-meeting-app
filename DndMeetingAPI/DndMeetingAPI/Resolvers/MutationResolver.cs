namespace DndMeetingAPI.Resolvers;

using Data.Repositories;
using Mappers;
using Models;

public class MutationResolver
{
    public async Task<User> AddUser(
        [Service] UserRepository userRepository,
        UserInput userInput,
        CancellationToken cancellationToken
        )
    {
        var user = userInput.ToEntity();
        await userRepository.AddAsync(user, cancellationToken);
        return user;
    }

    public async Task<DayWithFreeTime> AddFreeDaysWithTimesAsync(
        [Service] DayWithFreeTimeRepository dayWithFreeTimeRepository,
        FreeDayWithTimesInput freeDayWithTimesInput,
        CancellationToken cancellationToken
    )
    {
        var dayWithFreeTime = freeDayWithTimesInput.ToEntity();
        await dayWithFreeTimeRepository.AddAsync(dayWithFreeTime, cancellationToken);
        return dayWithFreeTime;
    }

    public async Task<Boolean> RemoveFreeDayAsync(
        [Service] DayWithFreeTimeRepository dayWithFreeTimeRepository,
        RemoveDayByUserInput removeDayByUserInput,
        CancellationToken cancellationToken)
    {
        var result = await dayWithFreeTimeRepository.DeleteDayByUser(removeDayByUserInput.DayId, removeDayByUserInput.UserId, cancellationToken);
        return result;
    }

    public async Task<Boolean> UpdateFreeDayAsync(
        [Service] FreeTimeRepository freeTimeRepository,
        UpdateFreeDayInput updateFreeDayInput,
        CancellationToken cancellationToken
    )
    {
        await freeTimeRepository.DeleteFreeTimesByIds(updateFreeDayInput.RemoveFreeTimeIds, cancellationToken);

        var newFreeTimes = updateFreeDayInput.NewFreeTimes
            .Select(nt => nt.ToEntity(updateFreeDayInput.UserId, updateFreeDayInput.DayId));

        await freeTimeRepository.AddRangeAsync(newFreeTimes, cancellationToken);

        return await freeTimeRepository.UpdateFreeTimes(updateFreeDayInput.UpdateFreeTimes, cancellationToken);
    }

    public async Task<Boolean> CopyFreeTimesToUserDays(
        [Service] DayWithFreeTimeRepository dayWithFreeTimeRepository,
        CopyFreeTimesInput copyFreeTimesInput,
        CancellationToken cancellationToken
    )
    {
        Boolean result = await dayWithFreeTimeRepository.CopyForUserFromDay(
            copyFreeTimesInput.UserId,
            copyFreeTimesInput.SourceDayId,
            copyFreeTimesInput.TargetDates,
            cancellationToken);

        return result;
    }
}

namespace DndMeetingAPI.Mappers;

using Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class UserMapper
{
    [MapperIgnoreTarget(nameof(User.Id))]
    [MapperIgnoreTarget(nameof(User.UsersAndDaysWithFreeTime))]
    [MapperIgnoreTarget(nameof(User.FreeTimes))]
    public static partial User ToEntity(this UserInput input);
}

[Mapper]
public static partial class FreeDayWithTimesMapper
{
    [MapperIgnoreTarget(nameof(User.Id))]
    [MapperIgnoreTarget(nameof(FreeTime.DayWithFreeTime))]
    [MapperIgnoreTarget(nameof(FreeTime.User))]
    [MapperIgnoreTarget(nameof(FreeTime.Deleted))]
    public static partial FreeTime ToEntity(this FreeTimeInput input, Guid userId, Guid dayWithFreeTimeId);

    [MapperIgnoreTarget(nameof(User.Id))]
    [MapperIgnoreTarget(nameof(FreeTime.DayWithFreeTime))]
    [MapperIgnoreTarget(nameof(FreeTime.User))]
    [MapperIgnoreTarget(nameof(FreeTime.Deleted))]
    [MapperIgnoreTarget(nameof(FreeTime.DayWithFreeTimeId))]
    public static partial FreeTime ToEntity(this FreeTimeInput input, Guid userId);

    [MapperIgnoreTarget(nameof(DayWithFreeTime.Id))]
    [MapperIgnoreTarget(nameof(DayWithFreeTime.FreeTimes))]
    [MapperIgnoreSource(nameof(FreeDayWithTimesInput.FreeTimes))]
    [MapProperty(nameof(FreeDayWithTimesInput.UserId), nameof(DayWithFreeTime.UsersAndDaysWithFreeTime), Use = nameof(MapUsersAndDays))]
    private static partial DayWithFreeTime MapToEntity(this FreeDayWithTimesInput input);

    private static List<UsersAndDaysWithFreeTime> MapUsersAndDays(this Guid userId) =>
        [new() { UserId = userId }];

    [UserMapping(Default = true)]
    public static DayWithFreeTime ToEntity(this FreeDayWithTimesInput input)
    {
        var entity = input.MapToEntity();

        entity.FreeTimes = input.FreeTimes
            .Select(ft => ft.ToEntity(input.UserId))
            .ToList();

        return entity;
    }

    [MapperIgnoreTarget(nameof(FreeTime.Deleted))]
    [MapperIgnoreTarget(nameof(FreeTime.User))]
    [MapperIgnoreTarget(nameof(FreeTime.DayWithFreeTime))]
    public static partial FreeTime ToEntity(this UpdateFreeTimeInput input, Guid userId, Guid dayWithFreeTimeId);
}

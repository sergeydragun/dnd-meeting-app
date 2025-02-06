namespace DndMeetingAPI.Data.Repositories;

using Functions;
using Microsoft.EntityFrameworkCore;
using Models;

public class DayWithFreeTimeRepository : BaseEntityRepository<DayWithFreeTime>
{
    public DayWithFreeTimeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<(Guid dayId, User user)>> GetUsersInDayWithFreeTimeAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var du = await _context.DayWithFreeTimes
            .Include(d => d.UsersAndDaysWithFreeTime)
                .ThenInclude(u => u.User)
            .Where(d => ids.Contains(d.Id))
            .SelectMany(d => d.UsersAndDaysWithFreeTime
                .Select(uad => new {d.Id, uad.User}))
            .ToListAsync(cancellationToken);

        return du.Select(x => (x.Id, x.User)).ToList();
    }

    public async Task<Boolean> DeleteDayByUser(Guid dayId, Guid userId, CancellationToken cancellationToken = default)
    {
        var uads = await _context.UsersAndDaysWithFreeTimes
            .Where(uad => uad.User.Id == userId && uad.DayWithFreeTimeId == dayId)
            .ToListAsync(cancellationToken);

        foreach (var uad in uads)
        {
            uad.Deleted = true;
        }

        var freeTimes = await _context.FreeTimes
            .Where(ft => ft.User.Id == userId && ft.DayWithFreeTimeId == dayId)
            .ToListAsync(cancellationToken);

        foreach (var ft in freeTimes)
        {
            ft.Deleted = true;
        }

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Boolean> CopyForUserFromDay(
        Guid dayId, Guid userId,
        List<DateOnly> dates,
        CancellationToken cancellationToken = default)
    {
        var times = await _context.FreeTimes.Where(ft => ft.User.Id == userId && ft.DayWithFreeTimeId == dayId)
            .ToListAsync(cancellationToken);

        var existingDays = await _context.DayWithFreeTimes
            .Include(d => d.FreeTimes)
            .Include(d => d.UsersAndDaysWithFreeTime)
            .Where(d => dates.Contains(d.Date))
            .ToDictionaryAsync(x => x.Date, cancellationToken);

        var newDays = new List<DayWithFreeTime>();

        foreach (var date in dates)
        {
            var newFreeTimes = new List<FreeTime>();

            foreach (var ft in times)
            {
                newFreeTimes.Add(new()
                {
                    StartTime = ft.StartTime,
                    EndTime = ft.EndTime,
                    UserId = ft.UserId,
                });
            }

            if (existingDays.TryGetValue(date, out var extDay))
            {
                if (extDay.UsersAndDaysWithFreeTime.Any(uad => uad.User.Id == userId))
                {
                    foreach (var ft in extDay.FreeTimes)
                    {
                        ft.Deleted = true;
                    }
                }
                else
                {
                    extDay.UsersAndDaysWithFreeTime.Add(new()
                    {
                        UserId = userId
                    });
                }

                extDay.FreeTimes.AddRange(newFreeTimes);

                continue;
            }

            DayWithFreeTime newDay;

            newDays.Add(new()
            {
                Date = date,
                FreeTimes = newFreeTimes,
                UsersAndDaysWithFreeTime = [
                    new()
                    {
                        UserId = userId,
                    }
                ]
            });
        }

        await _context.AddRangeAsync(newDays);
        _context.UpdateRange(existingDays);

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}

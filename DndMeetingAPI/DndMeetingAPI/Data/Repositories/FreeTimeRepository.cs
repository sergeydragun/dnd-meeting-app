namespace DndMeetingAPI.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Models;

public class FreeTimeRepository : BaseEntityRepository<FreeTime>
{
    private readonly AppDbContext _context;
    public FreeTimeRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public Task<List<FreeTime>> GetFreeTimesByUsers(IEnumerable<Guid> userIds, CancellationToken cancellationToken = default)
    {
        return _context.FreeTimes.Where(x => userIds.Contains(x.UserId)).ToListAsync(cancellationToken);
    }

    public Task<List<FreeTime>> GetFreeTimesByDays(IEnumerable<Guid> daysIds, CancellationToken cancellationToken = default)
    {
        return _context.FreeTimes.Where(x => daysIds.Contains(x.DayWithFreeTimeId)).ToListAsync(cancellationToken);
    }

    public Task<List<FreeTime>> GetUsersFreeTimesByDays(IEnumerable<Guid> usersIds,
        DateOnly dateOfTimes,
        CancellationToken cancellationToken = default)
    {
        return this._context.FreeTimes
            .Include(ft => ft.DayWithFreeTime)
            .Where(ft => usersIds.Contains(ft.UserId) && ft.DayWithFreeTime.Date == dateOfTimes)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> DeleteFreeTimesByIds(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
    {
        var freeTimes = await _context.FreeTimes.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);

        foreach (var ft in freeTimes)
        {
            ft.Deleted = true;
        }

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<Boolean> UpdateFreeTimes(List<UpdateFreeTimeInput> updatingFreeTimes, CancellationToken cancellationToken = default)
    {
        var map = updatingFreeTimes.ToDictionary(x => x.Id, x => x);

        var freeTimes = await _context.FreeTimes
            .Where(ft => updatingFreeTimes.Any(x => x.Id == ft.Id))
            .ToListAsync(cancellationToken);

        foreach (var ft in freeTimes)
        {
            ft.StartTime = map[ft.Id].StartTime;
            ft.EndTime = map[ft.Id].EndTime;
        }

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}

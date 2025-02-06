namespace DndMeetingAPI.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Models;

public class UserRepository : BaseEntityRepository<User>
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
        : base(db)
    {
        _db = db;
    }

    public async Task<List<(Guid UserId, DayWithFreeTime Day)>> GetDaysWithFreeTimeByUsersIdsAsync(IEnumerable<Guid> userIds,
        CancellationToken cancellationToken)
    {
        var result = await _db.Users
            .Include(u => u.UsersAndDaysWithFreeTime)
            .ThenInclude(uad => uad.DayWithFreeTime)
            .Where(u => userIds.Contains(u.Id))
            .SelectMany(u => u.UsersAndDaysWithFreeTime
                .Select(uad => new { UserId = u.Id, Day = uad.DayWithFreeTime }))
            .ToListAsync(cancellationToken);

        return result.Select(u => (u.UserId, u.Day)).ToList();
    }
}

namespace DndMeetingAPI.Data;

using Configurations;
using Microsoft.EntityFrameworkCore;
using Models;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<DayWithFreeTime> DayWithFreeTimes { get; set; } = null!;
    public DbSet<FreeTime> FreeTimes { get; set; } = null!;

    public DbSet<UsersAndDaysWithFreeTime> UsersAndDaysWithFreeTimes { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DayWithFreeTimeConfiguration());
        modelBuilder.ApplyConfiguration(new FreeTimeConfiguration());
        modelBuilder.ApplyConfiguration(new UserAndDayWithFreeTimeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

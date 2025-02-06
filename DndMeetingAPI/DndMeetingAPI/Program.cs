namespace DndMeetingAPI;

using Data;
using Microsoft.EntityFrameworkCore;
using Types;

public class Program
{
    public static void Main(string[] args)
    {
        var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=app.db"));

        builder.Services.AddCustomValidators();
        builder.Services.AddCustomGraphQl(builder.Configuration);
        builder.Services.AddCustomRepositories();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
        });

        var app = builder.Build();

        app.UseRouting();

        app.UseCors(MyAllowSpecificOrigins);

        app.MapGraphQL();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
        }

        app.Run();
    }
}

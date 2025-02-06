namespace DndMeetingAPI;

using Data.Repositories;
using FluentValidation;
using Types;
using Validators;

public static class CustomServiceCollectionExtensions
{
    public static IServiceCollection AddCustomRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<DayWithFreeTimeRepository>()
            .AddScoped<FreeTimeRepository>()
            .AddScoped<UserRepository>();
    }

    public static IServiceCollection AddCustomValidators(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssemblyContaining<UserInputValidator>();
    }

    public static IServiceCollection AddCustomGraphQl(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddGraphQLServer()
            .InitializeOnStartup()
            .AddFiltering()
            .AddSorting()
            .AddGlobalObjectIdentification()
            .AddQueryFieldToMutationPayloads()
            .SetSchema<MainSchema>()
            .AddDndMeetingAPITypes()
            .TrimTypes()
            .AddFairyBread()
            .ModifyRequestOptions(
                o => o.IncludeExceptionDetails = true)
            .Services;
    }
}

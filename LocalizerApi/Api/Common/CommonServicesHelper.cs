using Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Common;

public static class CommonServicesHelper
{
    public static void AddCommonServices (this IServiceCollection services)
    {
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<ICurrentUserService, MockCurrentUserService>();
    }
}
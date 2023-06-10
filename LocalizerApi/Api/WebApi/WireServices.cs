using Application;
using Common;
using Database;
using Domain;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace WebApi;

public static class WireServices
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddCommonServices();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog();
        });
        
        TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly,
            typeof(Application.Sensor.SensorMappings).Assembly,
            typeof(Domain.Sensors.Sensor).Assembly);
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddSingleton<IMapper, ServiceMapper>();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterApplication();
            cfg.RegisterDomain();
        });
        services.AddDbContext<LocalizerContext>(
            options => options.UseInMemoryDatabase("TestDb")
            );
    }
}
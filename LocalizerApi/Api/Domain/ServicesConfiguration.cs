using Domain.Sensors;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class ServicesConfiguration
{
    public static void RegisterDomain(this MediatRServiceConfiguration cfg)
    {
        cfg.RegisterServicesFromAssemblyContaining<Sensor>();
    }
}
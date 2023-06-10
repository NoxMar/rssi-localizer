using Application.Contracts.Sensor.AddSensor;
using Application.Sensor;
using Application.Sensor.AddSensor;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServicesConfiguration
{
    public static void RegisterApplication(this MediatRServiceConfiguration cfg)
    {
        cfg.RegisterServicesFromAssemblyContaining<AddSensorCommand>();
        cfg.RegisterServicesFromAssemblyContaining<AddSensorCommandHandler>();
    }
}
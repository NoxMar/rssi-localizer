using Application.Contracts.Sensor;
using Application.Contracts.Sensor.AddSensor;
using Domain.Sensors;
using Mapster;

namespace Application.Sensor;

public class SensorMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddSensorCommandDto, SensorForCreation>();
        config.NewConfig<Domain.Sensors.Sensor, SensorAppDto>();
    }
}
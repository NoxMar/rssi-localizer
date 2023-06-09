using MediatR;

namespace Application.Contracts.Sensor.AddSensor;

public record AddSensorCommand(AddSensorCommandDto SensorToAdd) : IRequest<SensorAppDto>;
using Common.Sensor;

namespace Application.Contracts.Sensor.AddSensor;

public record AddSensorCommandDto(string Uuid, SensorType Type);
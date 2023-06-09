using Common.Sensor;

namespace Domain.Sensors;

public record SensorForCreation(
    string Uuid,
    SensorType Type);
using Common.Sensor;

namespace Domain.Contracts.Sensor;

using Common;
public record SensorForCreation(
    string Uuid,
    SensorType Type);
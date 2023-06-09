using Common.Sensor;

namespace Application.Contracts.Sensor;

public record SensorAppDto(Guid Id, string Uuid, SensorType Type);
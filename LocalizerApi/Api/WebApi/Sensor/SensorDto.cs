using Common.Sensor;

namespace WebApi.Sensor;

public record SensorDto
(
  Guid Id,
  string Uuid,
  SensorType Type
);
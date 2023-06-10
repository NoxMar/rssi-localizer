using Domain.Common;

namespace Domain.Sensors;

public record MeasurementTakenEvent(Guid SensorId, string SensorUuid, string DeviceUuid, int Rssi) : DomainEvent;
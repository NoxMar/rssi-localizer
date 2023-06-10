using Domain.Common;

namespace Domain.Sensors;

public record SensorCreatedEvent(Guid Id, string Uuid) : DomainEvent;
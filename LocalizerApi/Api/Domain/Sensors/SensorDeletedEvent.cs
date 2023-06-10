using Domain.Common;

namespace Domain.Sensors;

public record SensorDeletedEvent(Guid Id, string Uuid) : DomainEvent;
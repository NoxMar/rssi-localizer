namespace Domain.Contracts.Sensor;

public record SensorCreatedEvent(Guid Id, string Uuid) : DomainEvent;
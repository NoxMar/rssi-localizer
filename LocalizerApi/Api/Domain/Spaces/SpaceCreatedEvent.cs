using Domain.Common;

namespace Domain.Spaces;

public record SpaceCreatedEvent(Guid Id, string Name) : DomainEvent;
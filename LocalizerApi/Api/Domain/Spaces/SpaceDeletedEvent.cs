using Domain.Common;

namespace Domain.Spaces;

public record SpaceDeletedEvent(Guid Id) : DomainEvent;
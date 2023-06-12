using MediatR;

namespace Application.Contracts.Space.Remove;

public record RemoveSpaceCommand(Guid Id) : IRequest<bool>;
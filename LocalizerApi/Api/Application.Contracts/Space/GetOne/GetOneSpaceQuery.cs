using MediatR;

namespace Application.Contracts.Space.GetOne;

public record GetOneSpaceQuery(Guid Id) : IRequest<SpaceAppDto?>;
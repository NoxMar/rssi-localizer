using MediatR;

namespace Application.Contracts.Space.AddSpace;

public record AddSpaceCommand(AddSpaceCommandDto SpaceToAdd) : IRequest<SpaceAppDto?>;
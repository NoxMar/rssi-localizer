using MediatR;

namespace Application.Contracts.Sensor.RemoveByUuid;

public record RemoveByUuidCommand(string Uuid) : IRequest;
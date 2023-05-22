using MediatR;

namespace Api.Sensors;

public record DeleteSensorRequest(string Id) : IRequest<bool>;
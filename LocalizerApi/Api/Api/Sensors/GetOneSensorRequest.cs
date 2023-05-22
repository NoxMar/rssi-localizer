using MediatR;

namespace Api.Sensors;

public record  GetOneSensorRequest(string Id) : IRequest<SensorDto?>;
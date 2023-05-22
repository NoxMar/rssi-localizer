using MediatR;

namespace Api.Sensors;

public record GetAllSensorsRequest() : IRequest<List<SensorDto>>;
using MediatR;

namespace Api.Sensors;

public record CreateSensorRequest(SensorDto Sensor) : IRequest<bool>;
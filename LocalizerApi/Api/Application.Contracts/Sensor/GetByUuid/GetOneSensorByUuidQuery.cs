using MediatR;

namespace Application.Contracts.Sensor.GetByUuid;

public record GetOneSensorByUuidQuery(string Uuid) : IRequest<SensorAppDto?>;
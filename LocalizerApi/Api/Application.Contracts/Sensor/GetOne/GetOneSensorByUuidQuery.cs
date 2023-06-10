using MediatR;

namespace Application.Contracts.Sensor.GetOne;

public record GetOneSensorByUuidQuery(string Uuid) : IRequest<SensorAppDto?>;
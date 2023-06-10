using MediatR;

namespace Application.Contracts.Sensor.ConsumeMeasurement;

public record ConsumeMeasurementCommand(ConsumeMeasurementCommandDto ConsumeMeasurementDto) : IRequest;
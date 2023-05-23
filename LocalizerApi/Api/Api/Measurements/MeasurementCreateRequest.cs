using MediatR;

namespace Api.Measurements;

public record MeasurementCreateRequest(MeasurementCreateDto Measurement, string SensorId) : IRequest<bool>;
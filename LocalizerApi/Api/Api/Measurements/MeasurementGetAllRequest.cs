using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Api.Measurements;

public record MeasurementGetAllRequest([Required]string SensorId) : IRequest<List<MeasurementDto>>;
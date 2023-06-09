using System.ComponentModel.DataAnnotations;
using Common.Sensor;

namespace WebApi.Sensor;

public record SensorForCreationDto(string Uuid, SensorType Type);
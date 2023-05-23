using System.ComponentModel.DataAnnotations;

namespace Api.Measurements;

public record MeasurementCreateDto(
    [Required]
    [RegularExpression(@"^(?:[0-9A-Fa-f][0-9A-Fa-f]:){5}[0-9A-Fa-f][0-9A-Fa-f]$")]
    string DeviceUid,
    [Required]
    int Rssi);
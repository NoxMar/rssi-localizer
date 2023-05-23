using System.ComponentModel.DataAnnotations;

namespace Database.Entities;

public class Measurement
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(20)]
    public string DeviceUid { get; set; } = string.Empty;
    [Required]
    public int Rssi { get; set; }
    [Required]
    public Sensor CapturedBy { get; set; } = default!;
    [Required]
    public DateTime CapturedAtUtc { get; set; } = default!;
}
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    public string SensorId { get; set; } = string.Empty;
    [Required]
    public Sensor CapturedBy { get; set; } = default!;
    [Required]
    public DateTime CapturedAtUtc { get; set; } = default!;
}

internal class MeasurementConfigurator : IEntityTypeConfiguration<Measurement>
{
    public void Configure(EntityTypeBuilder<Measurement> builder)
    {
        builder
            .HasOne<Sensor>(m => m.CapturedBy)
            .WithMany(s => s.Measurements)
            .HasForeignKey(s => s.SensorId);
    }
}
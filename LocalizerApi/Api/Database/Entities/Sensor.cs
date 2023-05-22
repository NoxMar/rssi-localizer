using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Entities;

public class Sensor
{
    [Required]
    [MaxLength(24)]
    public string Id { get; set; }

    public SensorType? DeviceType { get; set; } = SensorType.Esp32Type1;
}

internal class SensorConfigurator : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder
            .Property(s => s.DeviceType)
            .HasConversion<string>();
    }
}
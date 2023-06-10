using Domain.Sensors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database;

public class SensorConfig : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.Property(s => s.Uuid)
            .IsRequired()
            .HasMaxLength(40);
        builder.HasIndex(s => s.Uuid)
            .IsUnique();
        builder.Property(s => s.Type)
            .IsRequired();
    }
}
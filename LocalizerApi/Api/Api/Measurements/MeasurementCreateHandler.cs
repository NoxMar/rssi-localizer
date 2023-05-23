using Database;
using Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Measurements;

public class MeasurementCreateHandler : IRequestHandler<MeasurementCreateRequest, bool>
{
    private readonly LocalizerContext _context;

    public MeasurementCreateHandler(LocalizerContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(MeasurementCreateRequest request, CancellationToken cancellationToken)
    {
        var sensor = await _context.Sensors.FirstOrDefaultAsync(s => s.Id == request.SensorId);
        if (sensor is null) return false;
        var measurement = new Measurement
        {
            Rssi = request.Measurement.Rssi,
            CapturedAtUtc = DateTime.UtcNow,
            CapturedBy = sensor,
            DeviceUid = request.Measurement.DeviceUid
        };
        await _context.Measurements.AddAsync(measurement, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken) == 1;
    }
}
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
        var measurement = new Measurement
        {
            Rssi = request.Measurement.Rssi,
            CapturedAtUtc = DateTime.UtcNow,
            SensorId = request.SensorId,
            DeviceUid = request.Measurement.DeviceUid
        };
        await _context.Measurements.AddAsync(measurement, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken) == 1;
    }
}
using Application.Contracts;
using Application.Contracts.Sensor.ConsumeMeasurement;
using Database;
using Domain.Sensors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sensor.ConsumeMeasurement;

public class ConsumeMeasurementCommandHandler : IRequestHandler<ConsumeMeasurementCommand>
{
    private readonly LocalizerContext _dbContext;

    public ConsumeMeasurementCommandHandler(LocalizerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(ConsumeMeasurementCommand request, CancellationToken cancellationToken)
    {
        var measurement = request.ConsumeMeasurementDto;
        var sensor = await _dbContext.Sensors
            .FirstOrDefaultAsync(s => s.Uuid == measurement.SensorUuid, 
                cancellationToken: cancellationToken);
        if (sensor == null)
        {
            throw new EntityNotFoundException(measurement.SensorUuid);
        }
        sensor.ConsumeMeasurement(new Measurement(measurement.DeviceUuid, measurement.Rssi));
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
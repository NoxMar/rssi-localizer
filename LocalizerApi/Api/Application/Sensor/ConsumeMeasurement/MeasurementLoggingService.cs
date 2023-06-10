using Domain.Sensors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Sensor.ConsumeMeasurement;

public class MeasurementLoggingService : INotificationHandler<MeasurementTakenEvent>
{
    private readonly ILogger<MeasurementLoggingService> _logger;

    public MeasurementLoggingService(ILogger<MeasurementLoggingService> logger)
    {
        _logger = logger;
    }


    public Task Handle(MeasurementTakenEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sensor {SensorUid} logged device {DeviceUid} with RSSI of {Rssi}", 
            notification.SensorUuid,
            notification.DeviceUuid,
            notification.Rssi);
        return Task.CompletedTask;
    }
}
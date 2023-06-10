namespace Application.Contracts.Sensor.ConsumeMeasurement;

public record ConsumeMeasurementCommandDto(
    string SensorUuid,
    string DeviceUuid,
    int Rssi);
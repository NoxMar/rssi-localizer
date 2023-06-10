namespace WebApi.Sensor;

public record MeasurementDto
(
    string DeviceUid,
    int Rssi
);
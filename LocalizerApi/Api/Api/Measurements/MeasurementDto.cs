using Api.Sensors;
using AutoMapper;
using Database.Entities;

namespace Api.Measurements;

public record MeasurementDto(
    int Id,
    string DeviceUid,
    int Rssi,
    string SensorId,
    DateTime CapturedAtUtc);


public class MeasurementDtoProfile : Profile
{
    public MeasurementDtoProfile()
    {
        CreateMap<Measurement, MeasurementDto>();
    }
}
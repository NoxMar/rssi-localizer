using AutoMapper;
using Database.Entities;

namespace Api.Sensors;

public record SensorDto (string Id, SensorType? DeviceType);

public class SensorDtoProfile : Profile
{
    public SensorDtoProfile()
    {
        CreateMap<SensorDto, Sensor>();
        CreateMap<Sensor, SensorDto>();
    }
}
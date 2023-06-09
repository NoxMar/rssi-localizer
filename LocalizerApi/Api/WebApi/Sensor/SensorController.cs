using Application.Contracts.Sensor.AddSensor;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Sensor;

[ApiController]
[Route("[controller]")]
public class SensorsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SensorsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<SensorDto> AddSensor([FromBody] SensorForCreationDto sensorForCreation)
    {
        var addSensorCommandDto = _mapper.Map<AddSensorCommandDto>(sensorForCreation);
        var addedSensor = await _mediator.Send( new AddSensorCommand(addSensorCommandDto));
        return _mapper.Map<SensorDto>(addedSensor);
    }
}
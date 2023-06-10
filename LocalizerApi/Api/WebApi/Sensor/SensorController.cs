using Application.Contracts;
using Application.Contracts.Sensor.AddSensor;
using Application.Contracts.Sensor.ConsumeMeasurement;
using Application.Contracts.Sensor.GetByUuid;
using Application.Contracts.Sensor.RemoveByUuid;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Exception = System.Exception;

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

    [HttpGet("{uuid:required}")]
    public async Task<IActionResult> GetOneByUuid(string uuid)
    {
        var sensor = await _mediator.Send(new GetOneSensorByUuidQuery(uuid));
        if (sensor == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<SensorDto>(sensor));
    }

    [HttpDelete("{uuid:required}")]
    public async Task<IActionResult> DeleteByUuid(string uuid)
    {
        try
        {
            await _mediator.Send(new RemoveByUuidCommand(uuid));
            return NoContent();
        }
        catch (EntityNotFoundException _)
        {
            return NotFound();
        }
    }

    [HttpPost("{uuid:required}/measurement")]
    public async Task<IActionResult> ConsumeMeasurement([FromRoute] string uuid, 
        [FromBody]MeasurementDto measurement)
    {
        var commandDto = new ConsumeMeasurementCommandDto(
            SensorUuid: uuid,
            DeviceUuid: measurement.DeviceUid,
            Rssi: measurement.Rssi);
        try
        {
            await _mediator.Send(new ConsumeMeasurementCommand(commandDto));
        }
        catch (EntityNotFoundException _)
        {
            return NotFound();
        }
        return NoContent();
    }
}
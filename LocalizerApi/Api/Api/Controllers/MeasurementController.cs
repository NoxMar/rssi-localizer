using Api.Measurements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class MeasurementController : ControllerBase
{
    private readonly IMediator _mediator;

    public MeasurementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("api/sensor/{sensorId}/measurement")]
    public async Task<IActionResult> Create(string sensorId, MeasurementCreateDto measurement)
    {
        bool added =  await _mediator.Send(new MeasurementCreateRequest(measurement, sensorId));
        return added ? NoContent() : BadRequest();
    }

    [HttpGet("api/sensor/{sensorId}/measurement")]
    public async Task<IActionResult> ReadAllBySensor(string sensorId)
    {
        return Ok(await _mediator.Send(new MeasurementGetAllRequest(sensorId)));
    }
}
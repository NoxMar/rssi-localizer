using Api.Sensors;
using Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SensorController : ControllerBase
{
    private readonly ILogger<SensorController> _logger;
    private readonly IMediator _mediator;

    public SensorController(ILogger<SensorController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ReadAll()
    {
        return Ok(await _mediator.Send(new GetAllSensorsRequest()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Read(string id)
    {
        var sensor = await _mediator.Send(new GetOneSensorRequest(id));
        return sensor != null ? Ok(sensor) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SensorDto sensor)
    {
        var added = await _mediator.Send(new CreateSensorRequest(sensor));
        return added ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _mediator.Send(new DeleteSensorRequest(id)) ? NoContent() : NotFound();
    }
}
using Application.Contracts.Space.AddSpace;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Space;

[ApiController]
[Route("[controller]")]
public class SpacesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SpacesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddSpace([FromBody] SpaceForCreationDto spaceForCreationDto)
    {
        var commandDto = _mapper.Map<AddSpaceCommandDto>(spaceForCreationDto);
        var space = await _mediator.Send(new AddSpaceCommand(commandDto));
        return space == null ? BadRequest() : Ok(_mapper.Map<SpaceDto>(space));
    }
}
using AutoMapper;
using Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Sensors;

public class GetAllSensorsHandler : IRequestHandler<GetAllSensorsRequest, List<SensorDto>>
{
    private readonly IMapper _mapper;
    private readonly LocalizerContext _context;

    public GetAllSensorsHandler(IMapper mapper, LocalizerContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<SensorDto>> Handle(GetAllSensorsRequest request, CancellationToken cancellationToken)
        => _mapper.Map<List<SensorDto>>(await _context
            .Sensors
            .ToListAsync(cancellationToken: cancellationToken));
}
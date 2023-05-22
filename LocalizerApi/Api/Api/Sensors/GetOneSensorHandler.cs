using AutoMapper;
using Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Sensors;

public class GetOneSensorHandler : IRequestHandler<GetOneSensorRequest, SensorDto?>
{
    private readonly LocalizerContext _localizerContext;
    private readonly IMapper _mapper;

    public GetOneSensorHandler(LocalizerContext localizerContext, IMapper mapper)
    {
        _localizerContext = localizerContext;
        _mapper = mapper;
    }

    public async Task<SensorDto?> Handle(GetOneSensorRequest request, CancellationToken cancellationToken)
    {
        var sensor = await _localizerContext
            .Sensors
            .SingleOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
        return _mapper.Map<SensorDto>(sensor);
    }
            
}
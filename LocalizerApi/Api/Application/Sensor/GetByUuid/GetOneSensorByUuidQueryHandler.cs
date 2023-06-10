using Application.Contracts.Sensor;
using Application.Contracts.Sensor.GetByUuid;
using Database;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sensor.GetByUuid;

public class GetOneSensorByUuidQueryHandler : IRequestHandler<GetOneSensorByUuidQuery, SensorAppDto?>
{
    private readonly LocalizerContext _dbContext;
    private readonly IMapper _mapper;

    public GetOneSensorByUuidQueryHandler(LocalizerContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<SensorAppDto?> Handle(GetOneSensorByUuidQuery request, CancellationToken cancellationToken)
    {
        var sensor = await _dbContext.Sensors
            .FirstOrDefaultAsync(s => s.Uuid == request.Uuid,
                cancellationToken: cancellationToken);
        return sensor == null ? null : _mapper.Map<SensorAppDto>(sensor);
    }
}
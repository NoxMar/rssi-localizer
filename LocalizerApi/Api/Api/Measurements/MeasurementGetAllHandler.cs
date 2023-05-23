using AutoMapper;
using Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Measurements;

public class MeasurementGetAllHandler : IRequestHandler<MeasurementGetAllRequest, List<MeasurementDto>>
{
    private IMapper _mapper;
    private LocalizerContext _context;

    public MeasurementGetAllHandler(IMapper mapper, LocalizerContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<MeasurementDto>> Handle(MeasurementGetAllRequest request, CancellationToken cancellationToken)
    {
        var measurements = await _context.Measurements
            .Where(m => m.SensorId == request.SensorId)
            .ToListAsync(cancellationToken: cancellationToken);
        return _mapper.Map<List<MeasurementDto>>(measurements);
    }
}


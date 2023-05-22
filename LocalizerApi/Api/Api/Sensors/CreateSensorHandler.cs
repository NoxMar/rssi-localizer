using AutoMapper;
using Database;
using Database.Entities;
using MediatR;

namespace Api.Sensors;

public class CreateSensorHandler : IRequestHandler<CreateSensorRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly LocalizerContext _context;

    public CreateSensorHandler(IMapper mapper, LocalizerContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(CreateSensorRequest request, CancellationToken cancellationToken)
    {
        await _context
            .Sensors
            .AddAsync(_mapper.Map<Sensor>(request.Sensor), cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken) != 0;
    }
}
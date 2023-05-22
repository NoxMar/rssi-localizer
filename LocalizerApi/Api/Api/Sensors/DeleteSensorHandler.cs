using AutoMapper;
using Database;
using Database.Entities;
using MediatR;

namespace Api.Sensors;

public class DeleteSensorHandler : IRequestHandler<DeleteSensorRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly LocalizerContext _context;

    public DeleteSensorHandler(IMapper mapper, LocalizerContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<bool> Handle(DeleteSensorRequest request, CancellationToken cancellationToken)
    {
        var sensorStub = new Sensor { Id = request.Id };
        _context.Sensors.Remove(sensorStub);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
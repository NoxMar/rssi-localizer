using Application.Contracts;
using Application.Contracts.Sensor.RemoveByUuid;
using Database;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sensor.RemoveByUuid;

public class RemoveByUuidCommandHandler : IRequestHandler<RemoveByUuidCommand>
{
    private readonly LocalizerContext _dbContext;

    public RemoveByUuidCommandHandler(LocalizerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(RemoveByUuidCommand request, CancellationToken cancellationToken)
    {
        var sensor = await _dbContext.Sensors
            .FirstOrDefaultAsync(s => s.Uuid == request.Uuid, cancellationToken: cancellationToken);
        if (sensor == null)
        {
            throw new EntityNotFoundException(request.Uuid);
        }

        sensor.Delete();
        _dbContext.Sensors.Remove(sensor);
        var rowsAffected = await _dbContext.SaveChangesAsync(cancellationToken: cancellationToken);
        if (rowsAffected < 1)
        {
            throw new EntityNotFoundException(request.Uuid);
        }
    }
}
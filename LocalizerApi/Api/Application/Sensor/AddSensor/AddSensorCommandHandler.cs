using Application.Contracts.Sensor;
using Application.Contracts.Sensor.AddSensor;
using Database;
using Domain.Sensors;
using MapsterMapper;
using MediatR;

namespace Application.Sensor.AddSensor;

public class AddSensorCommandHandler : IRequestHandler<AddSensorCommand, SensorAppDto>
{
    private IMapper _mapper;
    private LocalizerContext _dbContext;

    public AddSensorCommandHandler(IMapper mapper, LocalizerContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<SensorAppDto> Handle(AddSensorCommand request, CancellationToken cancellationToken)
    {
        var sensorForCreation = _mapper.Map<SensorForCreation>(request.SensorToAdd);
        var sensor = Domain.Sensors.Sensor.Create(sensorForCreation);
        _dbContext.Sensors.Add(sensor);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<SensorAppDto>(sensor);
    }
}
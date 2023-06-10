using Common.Sensor;
using Domain.Common;

namespace Domain.Sensors;

public class Sensor : BaseEntity
{
    public string Uuid { get; private set; } = string.Empty;
    public SensorType Type { get; private set; }

    public static Sensor Create(SensorForCreation toCreate)
    {
        var newSensor = new Sensor();
        newSensor.Uuid = toCreate.Uuid;
        newSensor.Type = toCreate.Type;

        newSensor.QueueDomainEvent(new SensorCreatedEvent(newSensor.Id, newSensor.Uuid));
        
        return newSensor;
    }

    public void Delete()
    {
        QueueDomainEvent(new SensorDeletedEvent(Id: Id, Uuid: Uuid));
    }
}
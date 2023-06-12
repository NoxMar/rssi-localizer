using Domain.Common;

namespace Domain.Spaces;

public class Space : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    private Space()
    {
        
    }
    
    public static Space Create(SpaceForCreation spaceForCreation)
    {
        var newSpace = new Space();
        newSpace.Name = spaceForCreation.Name;
        
        newSpace.QueueDomainEvent(new SpaceCreatedEvent(Id: newSpace.Id, Name: newSpace.Name));
        
        return newSpace;
    }

    public void Delete()
    {
        QueueDomainEvent(new SpaceDeletedEvent(Id));
    }
}
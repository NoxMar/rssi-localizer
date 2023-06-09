using Microsoft.EntityFrameworkCore;
using MediatR;

using Common.Services;
using Domain.Common;
using Domain.Sensors;

namespace Database;

public class LocalizerContext : DbContext
{
    private readonly IMediator _mediator;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ICurrentUserService _currentUserService;

    public DbSet<Sensor> Sensors { get; set; }

    public LocalizerContext(DbContextOptions<LocalizerContext> options, IMediator mediator, IDateTimeProvider dateTimeProvider, ICurrentUserService currentUserService) : base(options)
    {
        _mediator = mediator;
        _dateTimeProvider = dateTimeProvider;
        _currentUserService = currentUserService;
    }

    // ReSharper disable once RedundantOverriddenMember since this will be needed when adding any entity
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply configurations
        modelBuilder.ApplyConfiguration(new BaseEntityConfig());
        modelBuilder.ApplyConfiguration(new SensorConfig());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        UpdateAuditFields();
        var result = await base.SaveChangesAsync(cancellationToken);
        await _dispatchDomainEvents();
        return result;
    }
    
    private async Task _dispatchDomainEvents()
    {
        var domainEventEntities = ChangeTracker.Entries<BaseEntity>()
            .Select(po => po.Entity)
            .Where(po => po.DomainEvents.Any())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            var events = entity.DomainEvents.ToArray();
            entity.DomainEvents.Clear();
            foreach (var entityDomainEvent in events)
                await _mediator.Publish(entityDomainEvent);
        }
    }

    private void UpdateAuditFields()
    {
        var now = _dateTimeProvider.DateTimeUtcNow;
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.UpdateCreationProperties(now, _currentUserService.UserId);
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService.UserId);
                    break;
                
                case EntityState.Modified:
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService.UserId);
                    break;
                
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService.UserId);
                    entry.Entity.UpdateIsDeleted(true);
                    break;
            }
        }
    }
}
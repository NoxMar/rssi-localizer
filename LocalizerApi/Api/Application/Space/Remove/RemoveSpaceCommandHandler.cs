using Application.Contracts.Space.Remove;
using Database;
using MediatR;

namespace Application.Space.Remove;

public class RemoveSpaceCommandHandler : IRequestHandler<RemoveSpaceCommand, bool>
{
    private readonly LocalizerContext _dbContext;

    public RemoveSpaceCommandHandler(LocalizerContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(RemoveSpaceCommand request, CancellationToken cancellationToken)
    {
        var space = await _dbContext.Spaces.FindAsync(request.Id, cancellationToken);
        if (space is null)
        {
            return false;
        }
        space.Delete();
        _dbContext.Spaces.Remove(space);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
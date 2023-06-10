using Application.Contracts.Space;
using Application.Contracts.Space.AddSpace;
using Database;
using Domain.Spaces;
using MapsterMapper;
using MediatR;

namespace Application.Space;

public class AddSpaceCommandHandler : IRequestHandler<AddSpaceCommand, SpaceAppDto?>
{
    private readonly IMapper _mapper;
    private readonly LocalizerContext _dbContext;

    public AddSpaceCommandHandler(IMapper mapper, LocalizerContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<SpaceAppDto?> Handle(AddSpaceCommand request, CancellationToken cancellationToken)
    {
        var spaceForCreation = _mapper.Map<SpaceForCreation>(request.SpaceToAdd);
        var space = Domain.Spaces.Space.Create(spaceForCreation);
        _dbContext.Spaces.Add(space);

        var wasSaved = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
        return wasSaved ? _mapper.Map<SpaceAppDto>(space) : null;
    }
}
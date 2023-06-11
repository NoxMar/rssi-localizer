using Application.Contracts.Space;
using Application.Contracts.Space.GetOne;
using Database;
using MapsterMapper;
using MediatR;

namespace Application.Space.GetOne;

public class GetOneSpaceQueryHandler : IRequestHandler<GetOneSpaceQuery, SpaceAppDto?>
{
    private readonly LocalizerContext _dbContext;
    private readonly IMapper _mapper;

    public GetOneSpaceQueryHandler(LocalizerContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<SpaceAppDto?> Handle(GetOneSpaceQuery request, CancellationToken cancellationToken)
    {
        var space = await _dbContext.Spaces.FindAsync(request.Id);
        return space == null ? null : _mapper.Map<SpaceAppDto>(space);
    }
}
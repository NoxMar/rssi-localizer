using Application.Contracts.Space;
using Application.Contracts.Space.AddSpace;
using Domain.Spaces;
using Mapster;

namespace Application.Space;

public class SpaceMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddSpaceCommandDto, SpaceForCreation>();
        config.NewConfig<Domain.Spaces.Space, SpaceAppDto>();
    }
}
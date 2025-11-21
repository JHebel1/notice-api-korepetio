using AutoMapper;
using Notices.Domain.Entities;
using Shared.Contracts;

namespace Notices.Application.MappingProfiles;

public class MapContractsOnModels : Profile
{
    public MapContractsOnModels()
    {
        CreateMap<UserCreated, User>();
    }
}
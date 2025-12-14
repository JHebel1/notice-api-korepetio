using AutoMapper;
using Notices.Application.Commands.CreateNotice;
using Notices.Application.DTO;
using Notices.Domain.Entities;

namespace Notices.Application.MappingProfiles;

public class MapRequestsOnModels : Profile
{ 
    public MapRequestsOnModels()
    {
        CreateMap<CreateOfferDto, Offer>();
        CreateMap<CreateNoticeCommand, Notice>();
    }
}
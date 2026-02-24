using AutoMapper;
using Notices.Application.Commands.CreateNotice;
using Notices.Application.Commands.UpdateNotice;
using Notices.Domain.Entities;

namespace Notices.Application.MappingProfiles;

public class MapRequestsOnModels : Profile
{ 
    public MapRequestsOnModels()
    {
        CreateMap<CreateOfferDto, Offer>();
        CreateMap<CreateNoticeCommand, Notice>()
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["InternalUserId"])); 
        
        CreateMap<UpdateNoticeCommand, Notice>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.OwnerId, opt => opt.Ignore())
            .ForMember(x => x.CreatedAt, opt => opt.Ignore());

    }
}
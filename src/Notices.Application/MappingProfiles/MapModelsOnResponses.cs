using AutoMapper;
using Notices.Application.Responses.Notice;
using Notices.Domain.Common;
using Notices.Domain.Entities;
namespace Notices.Application.MappingProfiles;

public class MapModelsOnResponses : Profile
{
    public MapModelsOnResponses()
    {
        CreateMap<Subject, SubjectDto>()
            .ConvertUsing(src => new SubjectDto(
                (int)src,
                src.GetDisplayName()
                )
            );
        CreateMap<EducationLevel, EducationLevelDto>()
            .ConstructUsing(
                src => new EducationLevelDto(
                    (int)src, 
                    src.GetDisplayName()
                    )
                );    
        
        CreateMap<Offer, OfferDto>();
        CreateMap<Notice, NoticeResponse>()
            .ForMember(d => d.Subject, o => o.MapFrom(s => s.Subject));
    }
}

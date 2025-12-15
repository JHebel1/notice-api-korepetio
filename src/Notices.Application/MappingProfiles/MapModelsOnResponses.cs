using AutoMapper;
using Notices.Application.DTO;
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
            
        
        CreateMap<Offer, OfferDto>()
            .ConvertUsing(src => 
                new OfferDto(
                    new EducationLevelDto(
                        (int)src.EducationLevel,
                        src.EducationLevel.GetDisplayName()
                        ),
                    src.Price
                    )
            );
        CreateMap<Notice, NoticeResponse>()
            .ForMember(d => d.Subject, o => o.MapFrom(s => s.Subject));
    }
}

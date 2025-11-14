using AutoMapper;
using Notices.Application.Responses.Notice;
using Notices.Domain.Entities;
namespace Notices.Application.MappingProfiles;

public class MapModelsOnResponses : Profile
{
    public MapModelsOnResponses()
    {
        CreateMap<Notice, NoticeResponse>();
    }
}

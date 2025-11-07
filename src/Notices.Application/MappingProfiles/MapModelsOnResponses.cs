using AutoMapper;
using Notices.Domain.Entities;
using Notices.Model.Responses.Notice;
namespace Notices.Application.MappingProfiles;

public class MapModelsOnResponses : Profile
{
    public MapModelsOnResponses()
    {
        CreateMap<Notice, NoticeResponse>();
    }
}

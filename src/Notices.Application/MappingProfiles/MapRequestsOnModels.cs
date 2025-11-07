using AutoMapper;
using Notices.Domain.Entities;
using Notices.Model.Requests.Notice;

namespace Notices.Application.MappingProfiles;

public class MapRequestsOnModels : Profile
{
    public MapRequestsOnModels()
    {
        CreateMap<NoticeRequest, Notice>();
    }
}
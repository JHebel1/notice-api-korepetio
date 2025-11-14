using MediatR;
using AutoMapper;
using Notices.Domain.Entities;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Commands.CreateNotice;

public class CreateNoticeCommandHandler(INoticeRepository noticeRepository, IMapper mapper) : IRequestHandler<CreateNoticeCommand, Guid>
{
    public async Task<Guid> Handle(CreateNoticeCommand command, CancellationToken cancellationToken)
    {
        var notice = mapper.Map<Notice>(command);
        await noticeRepository.AddAsync(notice, cancellationToken);
        
        return notice.Id;
    }
}
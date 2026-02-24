using AutoMapper;
using MediatR;
using Notices.Application.Responses.Notice;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Commands.RenewNotice;

public class RenewNoticeCommandHandler(INoticeRepository noticeRepository, IUserRepository userRepository, IMapper mapper)
:IRequestHandler<RenewNoticeCommand, NoticeResponse>
{
    public async Task<NoticeResponse> Handle(RenewNoticeCommand command, CancellationToken cancellationToken)
    {
        var internalUserId = await userRepository.GetUserIdByIdentityProviderId(command.KeycloakId, cancellationToken);

        var commandUserId =  await noticeRepository.GetNoticeOwnerIdByNoticeId(command.NoticeId, cancellationToken);
        
        if (internalUserId != commandUserId)
        {
            throw new UnauthorizedAccessException("Access denied");
        }
        var notice = await noticeRepository.RenewNotice(command.NoticeId, cancellationToken);
        
        return mapper.Map<NoticeResponse>(notice);
    }
}
using AutoMapper;
using MediatR;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Commands.DeleteNotice;

public class DeleteNoticeCommandHandler(INoticeRepository noticeRepository, IUserRepository userRepository, IMapper mapper)
: IRequestHandler<DeleteNoticeCommand, bool>
{
    public async Task<bool> Handle(DeleteNoticeCommand command, CancellationToken cancellationToken)
    {
        var internalUserId = await userRepository.GetUserIdByIdentityProviderId(command.KeycloakId, cancellationToken);

        var commandUserId =  await noticeRepository.GetNoticeOwnerIdByNoticeId(command.NoticeId, cancellationToken);
        
        if (internalUserId != commandUserId)
        {
            throw new UnauthorizedAccessException("Access denied");
        }
        
        return await noticeRepository.DeleteAsync(command.NoticeId, cancellationToken);
    }
}
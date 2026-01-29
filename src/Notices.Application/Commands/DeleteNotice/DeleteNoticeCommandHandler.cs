using System.Net;
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
        if (internalUserId == Guid.Empty)
        {
            throw new KeyNotFoundException("User with this internal id doesn't exist.");
        }
        
        var commandUserId =  await noticeRepository.GetNoticeOwnerIdByNoticeId(command.NoticeId, cancellationToken);
        if (commandUserId == Guid.Empty)
        {
            throw new KeyNotFoundException("User with this id doesn't exist.");
        }
        
        if (internalUserId != commandUserId)
        {
            throw new UnauthorizedAccessException("Access denied");
        }
        return await noticeRepository.SetStatusDeleted(command.NoticeId, cancellationToken);
    }
}
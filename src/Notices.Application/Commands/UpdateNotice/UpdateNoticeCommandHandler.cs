using AutoMapper;
using MediatR;
using Notices.Application.Responses.Notice;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Commands.UpdateNotice;

public class UpdateNoticeCommandHandler(INoticeRepository noticeRepository, IUserRepository userRepository, IMapper mapper)
: IRequestHandler<UpdateNoticeCommand, NoticeResponse>
{
    public async Task<NoticeResponse> Handle(UpdateNoticeCommand command, CancellationToken cancellationToken)
    {
        var internalUserId = await userRepository.GetUserIdByIdentityProviderId(command.IdentityProviderId, cancellationToken);
        
        if (internalUserId == Guid.Empty)
        {
            throw new KeyNotFoundException("User with this internal id doesn't exist.");
        }

        var notice = await noticeRepository.GetNoticeById(command.NoticeId, cancellationToken);
        if (notice == null)
        {
            throw new KeyNotFoundException("Notice not found");
        }

        if (notice.OwnerId != internalUserId)
        {
            throw new UnauthorizedAccessException("Access denied");
        }

        mapper.Map(command, notice);
        await noticeRepository.SaveChangesAsync(cancellationToken);
        return mapper.Map<NoticeResponse>(notice);
    }
}
using MediatR;
using AutoMapper;
using Notices.Domain.Entities;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Commands.CreateNotice;

public class CreateNoticeCommandHandler(INoticeRepository noticeRepository, IUserRepository userRepository, IMapper mapper) : IRequestHandler<CreateNoticeCommand, Guid>
{
    public async Task<Guid> Handle(CreateNoticeCommand command, CancellationToken cancellationToken)
    {
        var internalUserId = await userRepository.GetUserIdByIdentityProviderId(command.IdentityProviderId, cancellationToken);
        
        if (internalUserId == null)
        {
            throw new KeyNotFoundException("User with this internal id doesn't exist.");
        }
        
        var notice = mapper.Map<Notice>(command, opt => opt.Items["InternalUserId"] = internalUserId);;
        
        await noticeRepository.AddAsync(notice, cancellationToken);
        
        return notice.Id;
    }
}
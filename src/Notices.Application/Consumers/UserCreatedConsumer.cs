using MassTransit;
using Shared.Contracts;
using AutoMapper;
using Notices.Domain.Entities;
using Notices.Domain.RepositoryInterfaces;

namespace Notices.Application.Consumers;

public class UserCreatedConsumer(IMapper mapper, IUserRepository userRepository) : IConsumer<UserCreated>
{
    public async Task Consume(ConsumeContext<UserCreated> context)
    {
        var msg = context.Message;

        var user = mapper.Map<User>(msg);
        
        await userRepository.AddAsync(user);
        
        await Task.CompletedTask;
    }
}
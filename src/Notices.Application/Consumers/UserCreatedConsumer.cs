using MassTransit;
using Shared.Contracts;
using AutoMapper;
using Notices.Domain.Entities;

namespace Notices.Application.Consumers;

public class UserCreatedConsumer(IMapper mapper) : IConsumer<UserCreated>
{
    public async Task Consume(ConsumeContext<UserCreated> context)
    {
        var msg = context.Message;
        
        var user = mapper.Map<User>(msg);
        
        Console.WriteLine(user);
        
        await Task.CompletedTask;
    }
}
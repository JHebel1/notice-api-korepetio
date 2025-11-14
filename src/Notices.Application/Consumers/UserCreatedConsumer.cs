using MassTransit;
using Shared.Contracts;

namespace Notices.Application.Consumers;

public class UserCreatedConsumer : IConsumer<UserCreated>
{
    public async Task Consume(ConsumeContext<UserCreated> context)
    {
        var msg = context.Message;
        
        Console.WriteLine(msg);
        
        await Task.CompletedTask;
    }
}
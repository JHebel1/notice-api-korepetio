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
        Console.WriteLine("_____________");
        Console.WriteLine(msg.UserId);
        Console.WriteLine("_____________");
        Console.WriteLine(user.Id);
        Console.WriteLine("_____________");

        var id = await userRepository.AddAsync(user);
        
        Console.WriteLine(id);
        
        await Task.CompletedTask;
    }
}